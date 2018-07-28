/* Copyright (C) 2018. Hitomi Parser Developers */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hitomi_Copy_3
{
    public class HitomiBookmarkModel
    {
        [JsonProperty]
        public List<Tuple<string, DateTime, string>> Artists;
        [JsonProperty]
        public List<Tuple<string, DateTime>> Groups;
        [JsonProperty]
        public List<Tuple<string, DateTime>> Articles;
        [JsonProperty]
        public List<Tuple<string, DateTime>> Tags;
        [JsonProperty]
        public List<Tuple<string, DateTime>> Characters;
        [JsonProperty]
        public List<Tuple<string, DateTime>> Series;
        [JsonProperty]
        public List<Tuple<string, List<Tuple<string, int>>, DateTime>> CustomTags;
    }
    
    public class HitomiBookmark
    {
        private static readonly Lazy<HitomiBookmark> instance = new Lazy<HitomiBookmark>(() => new HitomiBookmark());
        public static HitomiBookmark Instance => instance.Value;
        string bk_path = $"{Environment.CurrentDirectory}\\bookmark.json";
        string bkbu_path = $"{Environment.CurrentDirectory}\\bookmark_backup.json";

        HitomiBookmarkModel model;

        public HitomiBookmark()
        {
            if (File.Exists(bk_path))
            {
                File.Copy(bk_path, bkbu_path, true);
                model = JsonConvert.DeserializeObject<HitomiBookmarkModel>(File.ReadAllText(bk_path));
            }
            if (model == null) model = new HitomiBookmarkModel();
            if (model.Artists == null) model.Artists = new List<Tuple<string, DateTime, string>>();
            if (model.Groups == null) model.Groups = new List<Tuple<string, DateTime>>();
            if (model.Articles == null) model.Articles = new List<Tuple<string, DateTime>>();
            if (model.Tags == null) model.Tags = new List<Tuple<string, DateTime>>();
            if (model.Characters == null) model.Characters = new List<Tuple<string, DateTime>>();
            if (model.Series == null) model.Series = new List<Tuple<string, DateTime>>();
            if (model.CustomTags == null) model.CustomTags = new List<Tuple<string, List<Tuple<string, int>>, DateTime>>();
            Save();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(model, Formatting.Indented);
            using (var fs = new StreamWriter(new FileStream(bk_path, FileMode.Create, FileAccess.Write)))
            {
                fs.Write(json);
            }
        }

        public ref HitomiBookmarkModel GetModel()
        {
            return ref model;
        }
    }
}
