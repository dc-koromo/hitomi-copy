/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

using Newtonsoft.Json;
using System;
using System.IO;

namespace Hitomi_Copy_4
{
    public class SettingsModel
    {
        // 일반 세팅
        [JsonProperty]
        public int Thread;
        [JsonProperty]
        public bool WaitInfinite;
        [JsonProperty]
        public int WaitTimeout;
        [JsonProperty]
        public bool SaveJson;
        [JsonProperty]
        public bool UsingLog;

        // 히토미 세팅
        [JsonProperty]
        public string HitomiPath;
        [JsonProperty]
        public string Language;
        [JsonProperty]
        public bool AutoSync;
        [JsonProperty]
        public bool UsingFuzzy;
        [JsonProperty]
        public bool UsingOptimization;

        // 마루마루 세팅
        [JsonProperty]
        public string MarumaruPath;

    }

    public class Settings
    {
        private static readonly Lazy<Settings> instance = new Lazy<Settings>(() => new Settings());
        public static Settings Instance => instance.Value;
        string setting_path = $"{Environment.CurrentDirectory}\\setting.json";

        SettingsModel model;

        public Settings()
        {
            if (File.Exists(setting_path)) model = JsonConvert.DeserializeObject<SettingsModel>(File.ReadAllText(setting_path));
            if (model == null)
            {
                model = new SettingsModel();
                model.HitomiPath = AppDomain.CurrentDomain.BaseDirectory + @"\Hitomi\{Artists}\[{Id}] {Title}\";
                model.MarumaruPath = AppDomain.CurrentDomain.BaseDirectory + @"\Marumaru\{Title}\";
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

        public ref SettingsModel GetModel()
        {
            return ref model;
        }
    }
}
