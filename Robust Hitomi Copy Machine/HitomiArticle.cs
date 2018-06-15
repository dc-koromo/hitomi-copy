﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using System.Collections.Generic;

namespace Robust_Hitomi_Copy_Machine
{
    public class HitomiArticle
    {
        string[] artists;
        string[] characters;
        string[] groups;
        string language;
        string[] series;
        string[] tags;
        bool tags_kor = false;
        string types;

        string thumbnail;
        string magic_number;
        string title;

        List<string> images_link;

        public string[] Artists { get { return artists; } set { artists = value; } }
        public string[] Characters { get { return characters; } set { characters = value; } }
        public string[] Groups { get { return groups; } set { groups = value; } }
        public string Language { get { return language; } set { language = value; } }
        public string[] Series { get { return series; } set { series = value; } }
        public string[] Tags { get { return tags; } set { tags = value; } }
        public bool TagsKor { get { return tags_kor; } set { tags_kor = value; } }
        public string Types { get { return types; } set { types = value; } }
        public bool ManualPathOrdering { get; set; }
        public string ManualAdditionalPath { get; set; }

        public string Thumbnail { get { return thumbnail; } set { thumbnail = value; } }
        public string Magic { get { return magic_number; } set { magic_number = value; } }
        public string Title { get { return title; } set { title = value; } }

        public List<string> ImagesLink { get { return images_link; } set { images_link = value; } }
    }
}
