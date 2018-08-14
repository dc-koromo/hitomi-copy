/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

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

namespace Hitomi_Copy_4.Hitomi
{
    public class HitomiData
    {
        private static readonly Lazy<HitomiData> instance = new Lazy<HitomiData>(() => new HitomiData());
        public static HitomiData Instance => instance.Value;
        
        public static int number_of_gallery_jsons = 20;

        public static string tag_json_uri = @"https://ltn.hitomi.la/tags.json";
        public static string gallerie_json_uri(int no) => $"https://ltn.hitomi.la/galleries{no}.json";

        public static string hidden_data_url = @"https://github.com/dc-koromo/hitomi-downloader-2/releases/download/hiddendata/hiddendata.json";

        public HitomiTagdata tagdata = new HitomiTagdata();
        public List<HitomiMetadata> metadata_collection;
        public Dictionary<string, string> thumbnail_collection;

        #region Metadata
        private async Task downloadMetadata(int no)
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);
            var data = await client.GetStringAsync(gallerie_json_uri(no));
            if (data.Trim() == "") return;
            lock (metadata_collection)
                metadata_collection.AddRange(JsonConvert.DeserializeObject<IEnumerable<HitomiMetadata>>(data));
        }

        public async Task DownloadMetadata()
        {
            ServicePointManager.DefaultConnectionLimit = 1048576;
            metadata_collection = new List<HitomiMetadata>();
            await Task.WhenAll(Enumerable.Range(0, number_of_gallery_jsons).Select(no => downloadMetadata(no)));

            if (!Settings.Instance.GetModel().AutoSync)
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "metadata.json")))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, metadata_collection);
                }
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

            if (!Settings.Instance.GetModel().AutoSync)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "hiddendata.json")))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, articles);
                }
            }

            HashSet<string> overlap = new HashSet<string>();
            metadata_collection.ForEach(x => overlap.Add(x.ID.ToString()));
            foreach (var article in articles)
            {
                if (overlap.Contains(article.Magic)) continue;
                metadata_collection.Add(HitomiLegalize.ArticleToMetadata(article));
                if (!thumbnail_collection.ContainsKey(article.Magic))
                    thumbnail_collection.Add(article.Magic, article.Thumbnail);
            }
        }

        #endregion

        #region Exist Check
        public bool CheckMetadataExist()
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "metadata.json"));
        }

        public bool CheckHiddendataExist()
        {
            return File.Exists(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "hiddendata.json"));
        }
        #endregion

        #region Data Etc
        public void SortMetadata()
        {
            metadata_collection.Sort((a, b) => b.ID.CompareTo(a.ID));
        }

        public void SortTagdata()
        {
            tagdata.artist.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            tagdata.tag.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            tagdata.female.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            tagdata.male.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            tagdata.group.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            tagdata.character.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            tagdata.series.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            tagdata.type.Sort((a, b) => b.Item2.CompareTo(a.Item2));
        }

        public async Task Synchronization()
        {
            metadata_collection.Clear();
            thumbnail_collection.Clear();
            await Task.Run(() => DownloadMetadata());
            await Task.Run(() => DownloadHiddendata());
            await Task.Run(() => RebuildTagData());
            await Task.Run(() => SortMetadata());
            await Task.Run(() => SortTagdata());
        }
        #endregion

        #region TagData
        private void Add(Dictionary<string, int> dic, string key)
        {
            if (dic.ContainsKey(key))
                dic[key] += 1;
            else
                dic.Add(key, 1);
        }

        public void RebuildTagData()
        {
            tagdata.artist?.Clear();
            tagdata.tag?.Clear();
            tagdata.female?.Clear();
            tagdata.male?.Clear();
            tagdata.group?.Clear();
            tagdata.character?.Clear();
            tagdata.series?.Clear();
            tagdata.type?.Clear();

            HashSet<string> language = new HashSet<string>();

            foreach (var metadata in metadata_collection)
            {
                if (metadata.Language != null)
                {
                    string lang = metadata.Language.Trim();
                    if (lang != "" && !language.Contains(metadata.Language))
                        language.Add(metadata.Language);
                }
            }

            tagdata.language = language.Select(x => new Tuple<string, int>(x, 0)).ToList();
            tagdata.language.Sort((a, b) => a.Item1.CompareTo(b.Item1));

            Dictionary<string, int> artist = new Dictionary<string, int>();
            Dictionary<string, int> tag = new Dictionary<string, int>();
            Dictionary<string, int> female = new Dictionary<string, int>();
            Dictionary<string, int> male = new Dictionary<string, int>();
            Dictionary<string, int> group = new Dictionary<string, int>();
            Dictionary<string, int> character = new Dictionary<string, int>();
            Dictionary<string, int> series = new Dictionary<string, int>();
            Dictionary<string, int> type = new Dictionary<string, int>();

            foreach (var metadata in metadata_collection)
            {
                string lang = metadata.Language;
                if (metadata.Language == null) lang = "N/A";
                if (Settings.Instance.GetModel().Language != "ALL" &&
                    Settings.Instance.GetModel().Language != lang) continue;
                if (metadata.Artists != null) metadata.Artists.ToList().ForEach(x => Add(artist, x));
                if (metadata.Tags != null) metadata.Tags.ToList().ForEach(x => { if (x.StartsWith("female:")) Add(female, x); else if (x.StartsWith("male:")) Add(male, x); else Add(tag, x); });
                if (metadata.Groups != null) metadata.Groups.ToList().ForEach(x => Add(group, x));
                if (metadata.Characters != null) metadata.Characters.ToList().ForEach(x => Add(character, x));
                if (metadata.Parodies != null) metadata.Parodies.ToList().ForEach(x => Add(series, x));
                if (metadata.Type != null) Add(type, metadata.Type);
            }

            tagdata.artist = artist.Select(x => new Tuple<string, int> (x.Key, x.Value)).ToList();
            tagdata.tag = tag.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
            tagdata.female = female.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
            tagdata.male = male.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
            tagdata.group = group.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
            tagdata.character = character.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
            tagdata.series = series.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
            tagdata.type = type.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();
        }
        #endregion

        #region Autocomplete Helper
        public List<Tuple<string, int>> GetArtistList(string startswith)
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            foreach (var tagdata in tagdata.artist)
                if (tagdata.Item1.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { Tuple<string, int> data = new Tuple<string, int>(tagdata.Item1.ToLower().Replace(' ', '_'), tagdata.Item2); result.Add(data); }
            return result;
        }

        public List<Tuple<string, int>> GetTagList(string startswith)
        {
            List<Tuple<string, int>> target = new List<Tuple<string, int>>();
            target.AddRange(tagdata.female);
            target.AddRange(tagdata.male);
            target.AddRange(tagdata.tag);
            target.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            foreach (var tagdata in target)
                if (tagdata.Item1.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { Tuple<string, int> data = new Tuple<string, int>(tagdata.Item1.ToLower().Replace(' ', '_'), tagdata.Item2); result.Add(data); }
            return result;
        }

        public List<Tuple<string, int>> GetGroupList(string startswith)
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            foreach (var tagdata in tagdata.group)
                if (tagdata.Item1.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { Tuple<string, int> data = new Tuple<string, int>(tagdata.Item1.ToLower().Replace(' ', '_'), tagdata.Item2); result.Add(data); }
            return result;
        }

        public List<Tuple<string, int>> GetSeriesList(string startswith)
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            foreach (var tagdata in tagdata.series)
                if (tagdata.Item1.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { Tuple<string, int> data = new Tuple<string, int>(tagdata.Item1.ToLower().Replace(' ', '_'), tagdata.Item2); result.Add(data); }
            return result;
        }

        public List<Tuple<string, int>> GetCharacterList(string startswith)
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            foreach (var tagdata in tagdata.character)
                if (tagdata.Item1.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { Tuple<string, int> data = new Tuple<string, int>(tagdata.Item1.ToLower().Replace(' ', '_'), tagdata.Item2); result.Add(data); }
            return result;
        }

        public List<Tuple<string, int>> GetTypeList(string startswith)
        {
            List<Tuple<string, int>> result = new List<Tuple<string, int>>();
            foreach (var tagdata in tagdata.type)
                if (tagdata.Item1.ToLower().Replace(' ', '_').StartsWith(startswith.ToLower()))
                { Tuple<string, int> data = new Tuple<string, int>(tagdata.Item1.ToLower().Replace(' ', '_'), tagdata.Item2); result.Add(data); }
            return result;
        }

        public List<string> GetLanguageList()
        {
            List<string> result = new List<string>();
            foreach (var lang in tagdata.language)
                result.Add(lang.Item1);
            return result;
        }
        #endregion
    }
}
