﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hitomi_Copy_2
{
    public class HitomiCommon
    {
        public static HitomiArticle MetadataToArticle(HitomiMetadata metadata)
        {
            HitomiArticle article = new HitomiArticle();
            article.Artists = metadata.Artists;
            article.Characters = metadata.Characters;
            article.Groups = metadata.Groups;
            article.Language = metadata.Language;
            article.Magic = metadata.ID.ToString();
            article.OriginalTitle = metadata.Name;
            article.Series = metadata.Parodies;
            article.Tags = metadata.Tags;
            article.Title = metadata.Name;
            article.Types = metadata.Type;
            return article;
        }

        public static HitomiMetadata ArticleToMetadata(HitomiArticle article)
        {
            HitomiMetadata metadata = new HitomiMetadata();
            metadata.Artists = article.Artists;
            metadata.Characters = article.Characters;
            metadata.Groups = article.Groups;
            metadata.ID = Convert.ToInt32(article.Magic);
            metadata.Language = LegalizeLanguage(article.Language);
            metadata.Name = article.Title;
            metadata.Parodies = article.Series;
            metadata.Tags = article.Tags.Select(x => LegalizeTag(x)).ToArray();
            metadata.Type = article.Types;
            return metadata;
        }

        public static string LegalizeTag(string tag)
        {
            if (tag.Trim().EndsWith("♀")) return "female:" + tag.Trim('♀').Trim();
            if (tag.Trim().EndsWith("♂")) return "male:" + tag.Trim('♂').Trim();
            return tag.Trim();
        }

        public static string LegalizeLanguage(string lang)
        {
            switch (lang)
            {
                case "한국어": return "korean";
                case "日本語": return "japanese";
                case "English": return "english";
                case "Español": return "spanish";
                case "ไทย": return "thai";
                case "Deutsch": return "german";
                case "中文": return "chinese";
                case "Português": return "portuguese";
                case "Français": return "french";
                case "Tagalog": return "tagalog";
                case "Русский": return "russian";
                case "Italiano": return "italian";
                case "polski": return "polish";
                case "tiếng việt": return "vietnamese";
                case "magyar": return "hungarian";
                case "Čeština": return "czech";
                case "Bahasa Indonesia": return "indonesian";
                case "العربية": return "arabic";
            }

            return lang;
        }

        public class CompareMetadata : IComparer<HitomiMetadata>
        {
            public int Compare(HitomiMetadata x, HitomiMetadata y)
            {
                return y.ID.CompareTo(x.ID);
            }
        }

        public static HitomiMetadata? GetMetadataFromMagic(string magic)
        {
            HitomiMetadata tmp = new HitomiMetadata() { ID = Convert.ToInt32(magic) };
            var pos = HitomiData.Instance.metadata_collection.BinarySearch(tmp, new CompareMetadata());
            if (pos < 0) return null;
            return HitomiData.Instance.metadata_collection[pos];
        }
    }
}
