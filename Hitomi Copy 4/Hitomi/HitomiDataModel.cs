/* Copyright (C) 2018. Hitomi Parser Developers */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Hitomi_Copy_4.Hitomi
{
    public struct HitomiTagdata
    {
        public List<Tuple<string, int>> language { get; set; }
        public List<Tuple<string, int>> female { get; set; }
        public List<Tuple<string, int>> series { get; set; }
        public List<Tuple<string, int>> character { get; set; }
        public List<Tuple<string, int>> artist { get; set; }
        public List<Tuple<string, int>> group { get; set; }
        public List<Tuple<string, int>> tag { get; set; }
        public List<Tuple<string, int>> male { get; set; }
        public List<Tuple<string, int>> type { get; set; }
    }

    public struct HitomiMetadata
    {
        [JsonProperty(PropertyName = "a")]
        public string[] Artists { get; set; }
        [JsonProperty(PropertyName = "g")]
        public string[] Groups { get; set; }
        [JsonProperty(PropertyName = "p")]
        public string[] Parodies { get; set; }
        [JsonProperty(PropertyName = "t")]
        public string[] Tags { get; set; }
        [JsonProperty(PropertyName = "c")]
        public string[] Characters { get; set; }
        [JsonProperty(PropertyName = "l")]
        public string Language { get; set; }
        [JsonProperty(PropertyName = "n")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
    }
}
