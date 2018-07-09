/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Hitomi_Copy_2
{
    public class HitomiLogModel
    {
        [JsonProperty]
        public string Id;
        [JsonProperty]
        public string Title;
        [JsonProperty]
        public string[] Artists;
        [JsonProperty]
        public string[] Tags;
        [JsonProperty]
        public DateTime Time;
    }

    public class HitomiLog
    {
        private static readonly Lazy<HitomiLog> instance = new Lazy<HitomiLog>(() => new HitomiLog());
        public static HitomiLog Instance => instance.Value;
        string log_path = $"{Environment.CurrentDirectory}\\log.json";

        List<HitomiLogModel> model;

        public HitomiLog()
        {
            if (File.Exists(log_path)) model = JsonConvert.DeserializeObject<List<HitomiLogModel>>(File.ReadAllText(log_path));
            if (model == null) model = new List<HitomiLogModel>();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(model, Formatting.Indented);
            using (var fs = new StreamWriter(new FileStream(log_path, FileMode.Create, FileAccess.Write)))
            {
                fs.Write(json);
            }
        }

        public void AddArticle(HitomiArticle article)
        {
            HitomiLogModel mm = new HitomiLogModel();
            mm.Id = article.Magic;
            mm.Title = article.Title;
            mm.Artists = article.Artists;
            mm.Tags = article.Tags;
            mm.Time = DateTime.Now;
            model.Add(mm);
        }

        public IEnumerable<HitomiLogModel> GetEnumerator()
        {
            return model;
        }

        public List<HitomiLogModel> GetList()
        {
            return model;
        }
    }
}
