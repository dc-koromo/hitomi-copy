/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_3;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy.Data
{
    public class HitomiData
    {
        private static readonly Lazy<HitomiData> instance = new Lazy<HitomiData>(() => new HitomiData());
        public static HitomiData Instance => instance.Value;

        public static int max_number_of_results = 10;
        public static int number_of_gallery_jsons = 20;
        
        public static string tag_json_uri = @"https://ltn.hitomi.la/tags.json";
        public static string gallerie_json_uri(int no)=> $"https://ltn.hitomi.la/galleries{no}.json";

        public HitomiTagdataCollection tagdata_collection;
        public List<HitomiMetadata> metadata_collection;

        #region Metadata
        public async Task DownloadMetadata()
        {
            ServicePointManager.DefaultConnectionLimit = 128;
            metadata_collection = new List<HitomiMetadata>();
            await Task.WhenAll(Enumerable.Range(0, number_of_gallery_jsons).Select(no => downloadMetadata(no)));
            SortMetadata();

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "metadata.json")))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, metadata_collection);
            }
        }

        public void SortMetadata()
        {
            metadata_collection.Sort((a, b) => b.ID.CompareTo(a.ID));
        }

        private async Task downloadMetadata(int no)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);
            var data = await client.GetStringAsync(gallerie_json_uri(no));
            if (data.Trim() == "") {
                LogEssential.Instance.PushLog(() => $"[Download Metadata] Error : '{gallerie_json_uri(no)}' is empty database!");
                return;
            }
            lock (metadata_collection)
            metadata_collection.AddRange(JsonConvert.DeserializeObject<IEnumerable<HitomiMetadata>>(data));
        }
        
        public void LoadMetadataJson()
        {
            if (CheckMetadataExist())
                metadata_collection = JsonConvert.DeserializeObject<List<HitomiMetadata>>(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "metadata.json")));
        }

        public bool CheckMetadataExist()
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "metadata.json"));
        }
        #endregion

        #region Metadata Testing
        public void LoadMetadataJson(string path)
        {
            metadata_collection.AddRange( JsonConvert.DeserializeObject<List<HitomiMetadata>>(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), path))));
        }
        #endregion

        #region TagData
        public async Task DownloadTagdata()
        {
            HttpClient client = new HttpClient();
            var data = await client.GetStringAsync(tag_json_uri);
            tagdata_collection = JsonConvert.DeserializeObject<HitomiTagdataCollection>(data);
            List<HitomiTagdata> female_data = new List<HitomiTagdata>();
            tagdata_collection.female.ForEach((a) => {HitomiTagdata tag_data = new HitomiTagdata(); tag_data.Tag = "female:" + a.Tag; tag_data.Count = a.Count; female_data.Add(tag_data);});
            List<HitomiTagdata> male_data = new List<HitomiTagdata>();
            tagdata_collection.male.ForEach((a) => { HitomiTagdata tag_data = new HitomiTagdata(); tag_data.Tag = "male:" + a.Tag; tag_data.Count = a.Count; male_data.Add(tag_data); });
            tagdata_collection.female = female_data;
            tagdata_collection.male = male_data;
            SortTagdata();

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            
            using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "tagdata.json")))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, tagdata_collection);
            }
        }

        public void SortTagdata()
        {
            tagdata_collection.artist.Sort((a, b) => b.Count.CompareTo(a.Count));
            tagdata_collection.tag.Sort((a, b) => b.Count.CompareTo(a.Count));
            tagdata_collection.female.Sort((a, b) => b.Count.CompareTo(a.Count));
            tagdata_collection.male.Sort((a, b) => b.Count.CompareTo(a.Count));
            tagdata_collection.group.Sort((a, b) => b.Count.CompareTo(a.Count));
            tagdata_collection.character.Sort((a, b) => b.Count.CompareTo(a.Count));
            tagdata_collection.series.Sort((a, b) => b.Count.CompareTo(a.Count));
        }

        public void LoadTagdataJson()
        {
            if (CheckTagdataExist())
            {
                tagdata_collection = JsonConvert.DeserializeObject<HitomiTagdataCollection>(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "tagdata.json")));
                SortTagdata();
            }
        }

        public bool CheckTagdataExist()
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "tagdata.json"));
        }
        #endregion

        public async Task Synchronization()
        {
            LogEssential.Instance.PushLog(() => "Start Synchronization...");
            metadata_collection.Clear();
            await Task.Run(() => DownloadTagdata());
            await Task.Run(() => DownloadMetadata());
            await Task.Run(() => SortTagdata());
            LogEssential.Instance.PushLog(() => "End Synchronization");
            LogEssential.Instance.PushLog(() => $"Sync Report : {metadata_collection.Count} {tagdata_collection.female.Count}");
        }

        #region Autocomplete Helper
        public List<HitomiTagdata> GetArtistList(string startswith)
        {
            List<HitomiTagdata> result = new List<HitomiTagdata>();
            foreach (var tagdata in tagdata_collection.artist)
                if (tagdata.Tag.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { HitomiTagdata data = new HitomiTagdata(); data.Tag = tagdata.Tag.ToLower().Replace(' ', '_'); data.Count = tagdata.Count; result.Add(data); }
            return result;
        }

        public List<HitomiTagdata> GetTagList(string startswith)
        {
            List<HitomiTagdata> target = new List<HitomiTagdata>();
            target.AddRange(tagdata_collection.female);
            target.AddRange(tagdata_collection.male);
            target.AddRange(tagdata_collection.tag);
            target.Sort((a, b) => b.Count.CompareTo(a.Count));
            List<HitomiTagdata> result = new List<HitomiTagdata>();
            foreach (var tagdata in target)
                if (tagdata.Tag.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { HitomiTagdata data = new HitomiTagdata(); data.Tag = tagdata.Tag.ToLower().Replace(' ', '_'); data.Count = tagdata.Count; result.Add(data); }
            return result;
        }

        public List<HitomiTagdata> GetGroupList(string startswith)
        {
            List<HitomiTagdata> result = new List<HitomiTagdata>();
            foreach (var tagdata in tagdata_collection.group)
                if (tagdata.Tag.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { HitomiTagdata data = new HitomiTagdata(); data.Tag = tagdata.Tag.ToLower().Replace(' ', '_'); data.Count = tagdata.Count; result.Add(data); }
            return result;
        }

        public List<HitomiTagdata> GetSeriesList(string startswith)
        {
            List<HitomiTagdata> result = new List<HitomiTagdata>();
            foreach (var tagdata in tagdata_collection.series)
                if (tagdata.Tag.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { HitomiTagdata data = new HitomiTagdata(); data.Tag = tagdata.Tag.ToLower().Replace(' ', '_'); data.Count = tagdata.Count; result.Add(data); }
            return result;
        }

        public List<HitomiTagdata> GetCharacterList(string startswith)
        {
            List<HitomiTagdata> result = new List<HitomiTagdata>();
            foreach (var tagdata in tagdata_collection.character)
                if (tagdata.Tag.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { HitomiTagdata data = new HitomiTagdata(); data.Tag = tagdata.Tag.ToLower().Replace(' ', '_'); data.Count = tagdata.Count; result.Add(data); }
            return result;
        }

        public List<string> GetLanguageList()
        {
            List<string> result = new List<string>();
            foreach (var lang in tagdata_collection.language)
                result.Add(lang.Tag);
            return result;
        }
        #endregion
    }
}
