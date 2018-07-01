/* Copyright (C) 2018. Hitomi Parser Developers */

using Newtonsoft.Json;
using System;
using System.IO;

namespace Hitomi_Copy_3.MM
{
    public class MMArticleDataModel
    {
        [JsonProperty]
        public string Title;
        [JsonProperty]
        public string ArticleUrl;
        [JsonProperty]
        public string ThumbnailUrl;
        [JsonProperty]
        public string[] DownloadUrlList;
        [JsonProperty]
        public DateTime LatestDownload;
    }

    public class MMSettingModel
    {
        [JsonProperty]
        public MMArticleDataModel[] Articles;
    }

    public class MMSetting
    {
        private static readonly Lazy<MMSetting> instance = new Lazy<MMSetting>(() => new MMSetting());
        public static MMSetting Instance => instance.Value;
        string setting_path = $"{Environment.CurrentDirectory}\\mmsetting.json";

        MMSettingModel model;

        public MMSetting()
        {
            if (File.Exists(setting_path)) model = JsonConvert.DeserializeObject<MMSettingModel>(File.ReadAllText(setting_path));
            if (model == null)
            {
                model = new MMSettingModel();
                model.Articles = null;
                Save();
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(model, Formatting.Indented);
            using (var fs = new StreamWriter(new FileStream(setting_path, FileMode.Create, FileAccess.Write)))
            {
                fs.Write(json);
            }
        }

        public ref MMSettingModel GetModel()
        {
            return ref model;
        }

    }
}