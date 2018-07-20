/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Hitomi_Copy_2
{
    public class HitomiSettingModel
    {
        [JsonProperty]
        public string Path;
        [JsonProperty]
        public string MarumaruPath;
        [JsonProperty]
        public string[] ExclusiveTag;
        [JsonProperty]
        public bool Zip;
        [JsonProperty]
        public int MaximumThumbnailShow;
        [JsonProperty]
        public int Thread;
        [JsonProperty]
        public string Language;
        [JsonProperty]
        public bool WaitInfinite;
        [JsonProperty]
        public int WaitTimeout;
        [JsonProperty]
        public bool SaveJson;
        [JsonProperty]
        public int RecommendPerScroll;
        [JsonProperty]
        public int TextMatchingAccuracy;
        [JsonProperty]
        public string[] UninterestednessArtists;
        [JsonProperty]
        public bool RecommendNMultipleWithLength;
        [JsonProperty]
        public bool RecommendLanguageALL;
        [JsonProperty]
        public bool ReplaceArtistsWithTitle;
        [JsonProperty]
        public bool UsingLog;
        [JsonProperty]
        public bool DetailedLog;
        [JsonProperty]
        public bool RecommendAutoRemove;
        [JsonProperty]
        public bool DetailedSearchResult;
        [JsonProperty]
        public bool UsingExHentaiBaseOpener;
        [JsonProperty]
        public bool UsingDriver;
        [JsonProperty]
        public int LatestNotice;
        [JsonProperty]
        public bool UsingXiAanlysis;
        [JsonProperty]
        public bool UsingOnlyFMTagsOnAnalysis;
        [JsonProperty]
        public string[] CustomAutoComplete;
        [JsonProperty]
        public bool AutoSync;
        [JsonProperty]
        public bool OpenWithFinder; // series tag character listing
        [JsonProperty]
        public int LoadPreviewMaximum;
        [JsonProperty]
        public bool ShowPageCount;
        [JsonProperty]
        public int AutoCompleteShowCount;
    }

    public class HitomiSetting
    {
        private static readonly Lazy<HitomiSetting> instance = new Lazy<HitomiSetting>(() => new HitomiSetting());
        public static HitomiSetting Instance => instance.Value;
        string log_path = $"{Environment.CurrentDirectory}\\setting.json";

        HitomiSettingModel model;

        public HitomiSetting()
        {
            if (File.Exists(log_path)) model = JsonConvert.DeserializeObject<HitomiSettingModel>(File.ReadAllText(log_path));
            if (model == null)
            {
                model = new HitomiSettingModel();
                model.Path = @"C:\Hitomi\{Artists}\[{Id}] {Title}\";
                model.MarumaruPath = AppDomain.CurrentDomain.BaseDirectory;
                model.ExclusiveTag = new string[] { "female:mother", "male:anal", "male:guro", "female:guro", "male:snuff", "female:snuff" };
                model.Zip = false;
                model.MaximumThumbnailShow = 1000;
                model.Thread = Environment.ProcessorCount * 3;
                model.Language = "korean";
                model.WaitInfinite = false;
                model.WaitTimeout = 10000;
                model.SaveJson = true;
                model.RecommendPerScroll = 10;
                model.TextMatchingAccuracy = 5;
                model.RecommendNMultipleWithLength = false;
                model.RecommendLanguageALL = false;
                model.ReplaceArtistsWithTitle = false;
                model.UsingLog = false;
                model.DetailedLog = false;
                model.RecommendAutoRemove = false;
                model.DetailedSearchResult = false;
                model.UsingExHentaiBaseOpener = false;
                model.UsingDriver = false;
                model.LatestNotice = 0;
                model.UsingXiAanlysis = false;
                model.UsingOnlyFMTagsOnAnalysis = false;
                model.CustomAutoComplete = new string[] { "recent:0-25" };
                model.AutoSync = false;
                model.OpenWithFinder = true;
                model.LoadPreviewMaximum = 500;
                model.ShowPageCount = false;
                model.AutoCompleteShowCount = 30;
                Save();
            }
            else
            {
                if (String.IsNullOrEmpty(model.Path)) model.Path = @"C:\Hitomi\{Artists}\[{Id}] {Title}\";
                if (String.IsNullOrEmpty(model.MarumaruPath)) model.MarumaruPath = AppDomain.CurrentDomain.BaseDirectory;
                if (model.MaximumThumbnailShow < 10) model.MaximumThumbnailShow = 1000;
                if (model.Thread < 5) model.Thread = 32;
                if (model.Thread > 64) model.Thread = 64;
                if (HitomiData.Instance.metadata_collection != null && !HitomiData.Instance.GetLanguageList().Contains(model.Language) && model.Language != "N/A" && model.Language != "ALL")
                    model.Language = "korean";
                if (model.WaitTimeout == 0 && model.WaitInfinite == false)
                    { model.WaitInfinite = true; model.WaitTimeout = 10000; }
                if (model.RecommendPerScroll < 10)
                    model.RecommendPerScroll = 10;
                if (model.TextMatchingAccuracy > 20 || model.TextMatchingAccuracy < 2)
                    model.TextMatchingAccuracy = 5;
                if (model.CustomAutoComplete == null)
                    model.CustomAutoComplete = new string[] { "recent:0-25" };
                if (model.LoadPreviewMaximum <= 0)
                    model.LoadPreviewMaximum = 500;
                if (model.AutoCompleteShowCount < 30)
                    model.AutoCompleteShowCount = 30;
                Save();
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(model, Formatting.Indented);
            using (var fs = new StreamWriter(new FileStream(log_path, FileMode.Create, FileAccess.Write)))
            {
                fs.Write(json);
            }
        }
        
        public ref HitomiSettingModel GetModel()
        {
            return ref model;
        }
        
    }
}
