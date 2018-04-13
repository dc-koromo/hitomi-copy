﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Hitomi_Copy_2.Analysis
{
    public class HitomiAnalysisTrendElement
    {
        public string name;
        public List<Point> points;
    }

    public class HitomiAnalysisTrend
    {
        private static readonly Lazy<HitomiAnalysisTrend> instance = new Lazy<HitomiAnalysisTrend>(() => new HitomiAnalysisTrend());
        public static HitomiAnalysisTrend Instance => instance.Value;
        
        public const int interval = 5000;
        
        public List<HitomiAnalysisTrendElement> samples = new List<HitomiAnalysisTrendElement>();

        List<KeyValuePair<int, List<HitomiMetadata>>> datas;

        public HitomiAnalysisTrend()
        {
            Dictionary<int, List<HitomiMetadata>> sorted_gallery_number = new Dictionary<int, List<HitomiMetadata>>();

            int max_id = 0;
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (max_id < metadata.ID)
                    max_id = metadata.ID;
            
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (sorted_gallery_number.ContainsKey(max_id-(max_id-metadata.ID) / interval * interval))
                    sorted_gallery_number[max_id - (max_id - metadata.ID) / interval * interval].Add(metadata);
                else
                    sorted_gallery_number.Add(max_id - (max_id - metadata.ID) / interval * interval, new List<HitomiMetadata>() { metadata });

            datas = sorted_gallery_number.ToList();
            datas.Sort((p1, p2) => p1.Key.CompareTo(p2.Key));

            UpdateGalleryVariation();
        }

        #region Gallery
        public void UpdateGalleryVariation()
        {
            samples.Clear();
            HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
            e.name = "업로드 변동";
            e.points = new List<Point>();
            
            foreach (var data in datas)
                e.points.Add(new Point(data.Key, data.Value.Count));

            samples.Add(e);
        }

        public void UpdataGalleryIncrements()
        {
            samples.Clear();
            HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
            e.name = "업로드 수";
            e.points = new List<Point>();

            int nujuk = 0;
            foreach (var data in datas)
            {
                nujuk += data.Value.Count;
                e.points.Add(new Point(data.Key, nujuk));
            }

            samples.Add(e);
        }
        #endregion

        #region Tag

        public void UpdateTagIncrements()
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> tag_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Tags != null)
                    foreach (var tag in metadata.Tags)
                        if (!tag_list.ContainsKey(tag))
                            tag_list.Add(tag, new Dictionary<int, int>());

            foreach (var data in datas)
                foreach (var metadata in data.Value)
                    if (metadata.Tags != null)
                        foreach (var tag in metadata.Tags)
                            if (tag_list[tag].ContainsKey(data.Key))
                                tag_list[tag][data.Key] += 1;
                            else
                                tag_list[tag].Add(data.Key, 1);
            
            foreach (var tag in tag_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = tag.Key;
                e.points = new List<Point>();
                int nujuk = 0;

                foreach (var pair in tag.Value)
                {
                    nujuk += pair.Value;
                    e.points.Add(new Point(pair.Key, nujuk));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => b.points.Last().Y.CompareTo(a.points.Last().Y));
            samples.RemoveRange(30, samples.Count - 30);
        }

        public void UpdateTagKoreanIncrements()
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> tag_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Tags != null)
                    foreach (var tag in metadata.Tags)
                        if (!tag_list.ContainsKey(tag))
                            tag_list.Add(tag, new Dictionary<int, int>());

            foreach (var data in datas)
                foreach (var metadata in data.Value)
                    if (metadata.Language == "korean" && metadata.Tags != null)
                        foreach (var tag in metadata.Tags)
                            if (tag_list[tag].ContainsKey(data.Key))
                                tag_list[tag][data.Key] += 1;
                            else
                                tag_list[tag].Add(data.Key, 1);

            foreach (var tag in tag_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = tag.Key;
                e.points = new List<Point>();
                int nujuk = 0;

                foreach (var pair in tag.Value)
                {
                    nujuk += pair.Value;
                    e.points.Add(new Point(pair.Key, nujuk));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => b.points.Last().Y.CompareTo(a.points.Last().Y));
            samples.RemoveRange(30, samples.Count - 30);
        }

        public void UpdateTagKoreanVariation()
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> tag_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Tags != null)
                    foreach (var tag in metadata.Tags)
                        if (!tag_list.ContainsKey(tag))
                            tag_list.Add(tag, new Dictionary<int, int>());

            foreach (var data in datas)
                if (data.Key > 1125000)
                foreach (var metadata in data.Value)
                    if (metadata.Language == "korean" && metadata.Tags != null)
                        foreach (var tag in metadata.Tags)
                            if (tag_list[tag].ContainsKey(data.Key))
                                tag_list[tag][data.Key] += 1;
                            else
                                tag_list[tag].Add(data.Key, 1);

            foreach (var tag in tag_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = tag.Key;
                e.points = new List<Point>();

                foreach (var pair in tag.Value)
                {
                    e.points.Add(new Point(pair.Key, pair.Value));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => {
                int bb = 0;
                if (b.points.Count >= 1) bb = b.points.Last().Y;
                if (b.points.Count > 1)
                    for (int i = 0; i < b.points.Count - 2 && i < 5; i++)
                        bb += b.points[b.points.Count - i - 2].Y;
                int aa = 0;
                if (a.points.Count >= 1) aa = a.points.Last().Y;
                if (a.points.Count > 1)
                    for (int i = 0; i < a.points.Count - 2 && i < 5; i++)
                        aa += a.points[a.points.Count - i - 2].Y;

                //return b.points.Last().Y.CompareTo(a.points.Last().Y);
                return bb.CompareTo(aa);
                });
            samples.RemoveRange(20, samples.Count - 20);
        }
        #endregion

        #region Artists
        public void UpdateArtistsIncremetns(bool specifictag = false, string tag = "")
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> artist_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Artists != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                    foreach (var artist in metadata.Artists)
                        if (!artist_list.ContainsKey(artist))
                            artist_list.Add(artist, new Dictionary<int, int>());

            foreach (var data in datas)
                foreach (var metadata in data.Value)
                    if (metadata.Artists != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                        foreach (var artist in metadata.Artists)
                            if (artist_list[artist].ContainsKey(data.Key))
                                artist_list[artist][data.Key] += 1;
                            else
                                artist_list[artist].Add(data.Key, 1);

            foreach (var artist in artist_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = artist.Key;
                e.points = new List<Point>();
                int nujuk = 0;

                foreach (var pair in artist.Value)
                {
                    nujuk += pair.Value;
                    e.points.Add(new Point(pair.Key, nujuk));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => b.points.Last().Y.CompareTo(a.points.Last().Y));
            if (samples.Count > 100) samples.RemoveRange(100, samples.Count - 100);
        }

        public void UpdateArtistsKoreanIncremetns(bool specifictag = false, string tag = "")
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> artist_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Artists != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                    foreach (var artist in metadata.Artists)
                        if (!artist_list.ContainsKey(artist))
                            artist_list.Add(artist, new Dictionary<int, int>());

            foreach (var data in datas)
                foreach (var metadata in data.Value)
                    if (metadata.Language == "korean" && metadata.Artists != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                        foreach (var artist in metadata.Artists)
                            if (artist_list[artist].ContainsKey(data.Key))
                                artist_list[artist][data.Key] += 1;
                            else
                                artist_list[artist].Add(data.Key, 1);

            foreach (var artist in artist_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = artist.Key;
                e.points = new List<Point>();
                int nujuk = 0;

                foreach (var pair in artist.Value)
                {
                    nujuk += pair.Value;
                    e.points.Add(new Point(pair.Key, nujuk));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => b.points.Last().Y.CompareTo(a.points.Last().Y));
            if (samples.Count > 100) samples.RemoveRange(100, samples.Count - 100);
        }

        public void UpdateArtistsKoreanVariation()
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> artist_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Artists != null)
                    foreach (var artist in metadata.Artists)
                        if (!artist_list.ContainsKey(artist))
                            artist_list.Add(artist, new Dictionary<int, int>());

            foreach (var data in datas)
                if (data.Key > 1125000)
                    foreach (var metadata in data.Value)
                        if (metadata.Language == "korean" && metadata.Artists != null)
                            foreach (var artist in metadata.Artists)
                                if (artist_list[artist].ContainsKey(data.Key))
                                    artist_list[artist][data.Key] += 1;
                                else
                                    artist_list[artist].Add(data.Key, 1);

            foreach (var artist in artist_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = artist.Key;
                e.points = new List<Point>();

                foreach (var pair in artist.Value)
                {
                    e.points.Add(new Point(pair.Key, pair.Value));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => {
                int bb = 0;
                if (b.points.Count >= 1) bb = b.points.Last().Y;
                if (b.points.Count > 1)
                    for (int i = 0; i < b.points.Count - 2 && i < 5; i++)
                        bb += b.points[b.points.Count - i - 2].Y;
                int aa = 0;
                if (a.points.Count >= 1) aa = a.points.Last().Y;
                if (a.points.Count > 1)
                    for (int i = 0; i < a.points.Count - 2 && i < 5; i++)
                        aa += a.points[a.points.Count - i - 2].Y;
                
                return bb.CompareTo(aa);
            });
            samples.RemoveRange(20, samples.Count - 20);
        }
        #endregion

        #region Group
        public void UpdateGroupsKoreanIncremetns(bool specifictag = false, string tag = "")
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> group_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Groups != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                    foreach (var group in metadata.Groups)
                        if (!group_list.ContainsKey(group))
                            group_list.Add(group, new Dictionary<int, int>());

            foreach (var data in datas)
                foreach (var metadata in data.Value)
                    if (metadata.Language == "korean" && metadata.Groups != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                        foreach (var group in metadata.Groups)
                            if (group_list[group].ContainsKey(data.Key))
                                group_list[group][data.Key] += 1;
                            else
                                group_list[group].Add(data.Key, 1);

            foreach (var group in group_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = group.Key;
                e.points = new List<Point>();
                int nujuk = 0;

                foreach (var pair in group.Value)
                {
                    nujuk += pair.Value;
                    e.points.Add(new Point(pair.Key, nujuk));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => b.points.Last().Y.CompareTo(a.points.Last().Y));
            if (samples.Count > 100) samples.RemoveRange(100, samples.Count - 100);
        }

        public void UpdateGroupsKoreanVariation()
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> group_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Groups != null)
                    foreach (var group in metadata.Groups)
                        if (!group_list.ContainsKey(group))
                            group_list.Add(group, new Dictionary<int, int>());

            foreach (var data in datas)
                if (data.Key > 1125000)
                    foreach (var metadata in data.Value)
                        if (metadata.Language == "korean" && metadata.Groups != null)
                            foreach (var group in metadata.Groups)
                                if (group_list[group].ContainsKey(data.Key))
                                    group_list[group][data.Key] += 1;
                                else
                                    group_list[group].Add(data.Key, 1);

            foreach (var group in group_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = group.Key;
                e.points = new List<Point>();

                foreach (var pair in group.Value)
                {
                    e.points.Add(new Point(pair.Key, pair.Value));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => {
                int bb = 0;
                if (b.points.Count >= 1) bb = b.points.Last().Y;
                if (b.points.Count > 1)
                    for (int i = 0; i < b.points.Count - 2 && i < 5; i++)
                        bb += b.points[b.points.Count - i - 2].Y;
                int aa = 0;
                if (a.points.Count >= 1) aa = a.points.Last().Y;
                if (a.points.Count > 1)
                    for (int i = 0; i < a.points.Count - 2 && i < 5; i++)
                        aa += a.points[a.points.Count - i - 2].Y;

                return bb.CompareTo(aa);
            });
            samples.RemoveRange(20, samples.Count - 20);
        }
        #endregion

        #region Series
        public void UpdateSeriesKoreanIncremetns(bool specifictag = false, string tag = "")
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> series_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Parodies != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                    foreach (var series in metadata.Parodies)
                        if (!series_list.ContainsKey(series))
                            series_list.Add(series, new Dictionary<int, int>());

            foreach (var data in datas)
                foreach (var metadata in data.Value)
                    if (metadata.Language == "korean" && metadata.Parodies != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                        foreach (var series in metadata.Parodies)
                            if (series_list[series].ContainsKey(data.Key))
                                series_list[series][data.Key] += 1;
                            else
                                series_list[series].Add(data.Key, 1);

            foreach (var series in series_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = series.Key;
                e.points = new List<Point>();
                int nujuk = 0;

                foreach (var pair in series.Value)
                {
                    nujuk += pair.Value;
                    e.points.Add(new Point(pair.Key, nujuk));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => b.points.Last().Y.CompareTo(a.points.Last().Y));
            if (samples.Count > 100) samples.RemoveRange(100, samples.Count - 100);
        }

        public void UpdateSeriesKoreanVariation()
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> series_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Parodies != null)
                    foreach (var series in metadata.Parodies)
                        if (!series_list.ContainsKey(series))
                            series_list.Add(series, new Dictionary<int, int>());

            foreach (var data in datas)
                if (data.Key > 1125000)
                    foreach (var metadata in data.Value)
                        if (metadata.Language == "korean" && metadata.Parodies != null)
                            foreach (var series in metadata.Parodies)
                                if (series_list[series].ContainsKey(data.Key))
                                    series_list[series][data.Key] += 1;
                                else
                                    series_list[series].Add(data.Key, 1);

            foreach (var series in series_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = series.Key;
                e.points = new List<Point>();

                foreach (var pair in series.Value)
                {
                    e.points.Add(new Point(pair.Key, pair.Value));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => {
                int bb = 0;
                if (b.points.Count >= 1) bb = b.points.Last().Y;
                if (b.points.Count > 1)
                    for (int i = 0; i < b.points.Count - 2 && i < 5; i++)
                        bb += b.points[b.points.Count - i - 2].Y;
                int aa = 0;
                if (a.points.Count >= 1) aa = a.points.Last().Y;
                if (a.points.Count > 1)
                    for (int i = 0; i < a.points.Count - 2 && i < 5; i++)
                        aa += a.points[a.points.Count - i - 2].Y;

                return bb.CompareTo(aa);
            });
            samples.RemoveRange(20, samples.Count - 20);
        }
        #endregion

        #region Characters
        public void UpdateCharactersKoreanIncremetns(bool specifictag = false, string tag = "")
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> character_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Characters != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                    foreach (var character in metadata.Characters)
                        if (!character_list.ContainsKey(character))
                            character_list.Add(character, new Dictionary<int, int>());

            foreach (var data in datas)
                foreach (var metadata in data.Value)
                    if (metadata.Language == "korean" && metadata.Characters != null && (!specifictag || (metadata.Tags != null && metadata.Tags.Contains(tag))))
                        foreach (var character in metadata.Characters)
                            if (character_list[character].ContainsKey(data.Key))
                                character_list[character][data.Key] += 1;
                            else
                                character_list[character].Add(data.Key, 1);

            foreach (var character in character_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = character.Key;
                e.points = new List<Point>();
                int nujuk = 0;

                foreach (var pair in character.Value)
                {
                    nujuk += pair.Value;
                    e.points.Add(new Point(pair.Key, nujuk));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => b.points.Last().Y.CompareTo(a.points.Last().Y));
            if (samples.Count > 100) samples.RemoveRange(100, samples.Count - 100);
        }

        public void UpdateCharactersKoreanVariation()
        {
            samples.Clear();

            Dictionary<string, Dictionary<int, int>> character_list = new Dictionary<string, Dictionary<int, int>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Language == "korean" && metadata.Characters != null)
                    foreach (var series in metadata.Characters)
                        if (!character_list.ContainsKey(series))
                            character_list.Add(series, new Dictionary<int, int>());

            foreach (var data in datas)
                if (data.Key > 1125000)
                    foreach (var metadata in data.Value)
                        if (metadata.Language == "korean" && metadata.Characters != null)
                            foreach (var series in metadata.Characters)
                                if (character_list[series].ContainsKey(data.Key))
                                    character_list[series][data.Key] += 1;
                                else
                                    character_list[series].Add(data.Key, 1);

            foreach (var series in character_list)
            {
                HitomiAnalysisTrendElement e = new HitomiAnalysisTrendElement();
                e.name = series.Key;
                e.points = new List<Point>();

                foreach (var pair in series.Value)
                {
                    e.points.Add(new Point(pair.Key, pair.Value));
                }
                samples.Add(e);
            }

            samples.Sort((a, b) => {
                int bb = 0;
                if (b.points.Count >= 1) bb = b.points.Last().Y;
                if (b.points.Count > 1)
                    for (int i = 0; i < b.points.Count - 2 && i < 5; i++)
                        bb += b.points[b.points.Count - i - 2].Y;
                int aa = 0;
                if (a.points.Count >= 1) aa = a.points.Last().Y;
                if (a.points.Count > 1)
                    for (int i = 0; i < a.points.Count - 2 && i < 5; i++)
                        aa += a.points[a.points.Count - i - 2].Y;

                return bb.CompareTo(aa);
            });
            samples.RemoveRange(20, samples.Count - 20);
        }
        #endregion
    }
}
