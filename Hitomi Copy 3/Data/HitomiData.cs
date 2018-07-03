/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy_2;
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

        public static string hidden_data_url = @"https://github.com/dc-koromo/hitomi-downloader-2/releases/download/hiddendata/hiddendata.json";

        public HitomiTagdataCollection tagdata_collection;
        public List<HitomiMetadata> metadata_collection;
        public Dictionary<string, string> thumbnail_collection;

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

        public async Task DownloadHiddendata()
        {
            thumbnail_collection = new Dictionary<string, string>();
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);
            var data = await client.GetStringAsync(hidden_data_url);

            List<HitomiArticle> articles = JsonConvert.DeserializeObject<List<HitomiArticle>>(data);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "hiddendata.json")))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, articles);
            }

            HashSet<string> overlap = new HashSet<string>();
            metadata_collection.ForEach(x => overlap.Add(x.ID.ToString()));
            foreach (var article in articles)
            {
                if (overlap.Contains(article.Magic)) continue;
                metadata_collection.Add(HitomiCommon.ArticleToMetadata(article));
                if (!thumbnail_collection.ContainsKey(article.Magic))
                    thumbnail_collection.Add(article.Magic, article.Thumbnail);
            }
            SortMetadata();
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

        public void LoadHiddendataJson()
        {
            thumbnail_collection = new Dictionary<string, string>();
            if (CheckHiddendataExist())
            {
                List<HitomiArticle> articles = JsonConvert.DeserializeObject<List<HitomiArticle>>(File.ReadAllText(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "hiddendata.json")));
                HashSet<string> overlap = new HashSet<string>();
                metadata_collection.ForEach(x => overlap.Add(x.ID.ToString()));
                foreach (var article in articles)
                {
                    if (overlap.Contains(article.Magic)) continue;
                    metadata_collection.Add(HitomiCommon.ArticleToMetadata(article));
                    if (!thumbnail_collection.ContainsKey(article.Magic))
                        thumbnail_collection.Add(article.Magic, article.Thumbnail);
                }
                SortMetadata();
            }
        }

        public bool CheckMetadataExist()
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "metadata.json"));
        }

        public bool CheckHiddendataExist()
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "hiddendata.json"));
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

        #region TagData Rebuilding
        
        private void Add(Dictionary<string, int> dic, string key)
        {
            if (dic.ContainsKey(key))
                dic[key] += 1;
            else
                dic.Add(key, 1);
        }

        public void RebuildTagData()
        {
            tagdata_collection.artist.Clear();
            tagdata_collection.tag.Clear();
            tagdata_collection.female.Clear();
            tagdata_collection.male.Clear();
            tagdata_collection.group.Clear();
            tagdata_collection.character.Clear();
            tagdata_collection.series.Clear();

            Dictionary<string, int> artist = new Dictionary<string, int>();
            Dictionary<string, int> tag = new Dictionary<string, int>();
            Dictionary<string, int> female = new Dictionary<string, int>();
            Dictionary<string, int> male = new Dictionary<string, int>();
            Dictionary<string, int> group = new Dictionary<string, int>();
            Dictionary<string, int> character = new Dictionary<string, int>();
            Dictionary<string, int> series = new Dictionary<string, int>();
            
            foreach (var metadata in metadata_collection)
            {
                if (metadata.Artists != null) metadata.Artists.ToList().ForEach(x => Add(artist,x));
                if (metadata.Tags != null) metadata.Tags.ToList().ForEach(x => { if (x.StartsWith("female:")) Add(female, x); else if (x.StartsWith("male:")) Add(male, x); else Add(tag, x); });
                if (metadata.Groups != null) metadata.Groups.ToList().ForEach(x => Add(group, x));
                if (metadata.Characters != null) metadata.Characters.ToList().ForEach(x => Add(character, x));
                if (metadata.Parodies != null) metadata.Parodies.ToList().ForEach(x => Add(series, x));
            }

            tagdata_collection.artist = artist.Select(x => new HitomiTagdata() { Tag = x.Key, Count = x.Value }).ToList();
            tagdata_collection.tag = tag.Select(x => new HitomiTagdata() { Tag = x.Key, Count = x.Value }).ToList();
            tagdata_collection.female = female.Select(x => new HitomiTagdata() { Tag = x.Key, Count = x.Value }).ToList();
            tagdata_collection.male = male.Select(x => new HitomiTagdata() { Tag = x.Key, Count = x.Value }).ToList();
            tagdata_collection.group = group.Select(x => new HitomiTagdata() { Tag = x.Key, Count = x.Value }).ToList();
            tagdata_collection.character = character.Select(x => new HitomiTagdata() { Tag = x.Key, Count = x.Value }).ToList();
            tagdata_collection.series = series.Select(x => new HitomiTagdata() { Tag = x.Key, Count = x.Value }).ToList();

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
        #endregion

        public async Task Synchronization()
        {
            LogEssential.Instance.PushLog(() => "Start Synchronization...");
            metadata_collection.Clear();
            thumbnail_collection.Clear();
            await Task.Run(() => DownloadTagdata());
            await Task.Run(() => DownloadMetadata());
            await Task.Run(() => DownloadHiddendata());
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
