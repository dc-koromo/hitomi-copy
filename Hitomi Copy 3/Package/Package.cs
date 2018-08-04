/* Copyright (C) 2018. Hitomi Parser Developers */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Hitomi_Copy_3.Package
{
    public class PackageElementModel
    {
        [JsonProperty]
        public string Name;
        [JsonProperty]
        public string Nickname;
        [JsonProperty]
        public string Description;
        [JsonProperty]
        public string ImageLink;
        [JsonProperty]
        public DateTime LatestUpdate;
        [JsonProperty]
        public List<Tuple<string, string>> Artists;
        [JsonProperty]
        public List<Tuple<string, string>> Articles;
        [JsonProperty]
        public List<Tuple<string, string>> Etc;
    }

    public class PackageModel
    {
        [JsonProperty]
        public int PackageCount;
        [JsonProperty]
        public DateTime LatestUpdate;
        [JsonProperty]
        public List<PackageElementModel> Elements;
    }

    public class Package
    {
        private static readonly Lazy<Package> instance = new Lazy<Package>(() => new Package());
        public static Package Instance => instance.Value;
        public const string package_link = "";

        PackageModel model;

        public Package()
        {
            model = new PackageModel();
        }
        
        public void UpdatePackage()
        {
            LogEssential.Instance.PushLog(() => $"[Package] Download package lists...");
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string raw = wc.DownloadString(package_link);
            LogEssential.Instance.PushLog(() => $"[Package] Completes downloading!");
            model = JsonConvert.DeserializeObject<PackageModel> (raw);
        }

        public PackageModel GetModel() => model;
        public bool IsDownloaded() => model != null;
    }
}
