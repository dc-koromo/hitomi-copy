/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hitomi_Copy_2.Analysis
{
    public class HitomiAnalysis
    {
        private static readonly Lazy<HitomiAnalysis> instance = new Lazy<HitomiAnalysis>(() => new HitomiAnalysis());
        public static HitomiAnalysis Instance => instance.Value;

        List<HitomiAnalysisArtist> datas = new List<HitomiAnalysisArtist>();

        public List<Tuple<string, double, string>> Rank;

        public bool FilterArtists = false;
        public bool UserDefined = false;
        public bool MustInclude = false;
        public List<Tuple<string, int>> CustomAnalysis = new List<Tuple<string, int>>();

        public HitomiAnalysis()
        {
            Dictionary<string, List<HitomiMetadata>> artists = new Dictionary<string, List<HitomiMetadata>>();
            foreach (var metadata in HitomiData.Instance.metadata_collection)
                if (metadata.Artists != null)
                    foreach (var artist in metadata.Artists)
                        if (artists.ContainsKey(artist))
                            artists[artist].Add(metadata);
                        else
                            artists.Add(artist, new List<HitomiMetadata>() { metadata });

            foreach (var pair in artists)
                datas.Add(new HitomiAnalysisArtist(pair.Key, pair.Value));
        }

        public void Update()
        {
            HitomiAnalysisArtist user;
            if (!UserDefined)
                user = new HitomiAnalysisArtist(HitomiLog.Instance.GetEnumerator());
            else
                user = new HitomiAnalysisArtist(CustomAnalysis);

            ///////////////////////////////

            Dictionary<string, Tuple<double, HitomiAnalysisArtist>> score = new Dictionary<string, Tuple<double, HitomiAnalysisArtist>>();
            bool xi = HitomiSetting.Instance.GetModel().UsingXiAanlysis;
            foreach (var pair in user.GetDictionary())
            {
                foreach (var data in datas)
                {
                    if (!xi)
                    {
                        if (data.IsExsit(pair.Key))
                            if (score.ContainsKey(data.Aritst))
                                score[data.Aritst] = new Tuple<double, HitomiAnalysisArtist>(score[data.Aritst].Item1 + pair.Value * data.GetRate(pair.Key), score[data.Aritst].Item2);
                            else
                                score.Add(data.Aritst, new Tuple<double, HitomiAnalysisArtist>(pair.Value * data.GetRate(pair.Key), data));
                    }
                    else
                    {
                        if (data.IsExsit(pair.Key))
                        {
                            if (score.ContainsKey(data.Aritst))
                                score[data.Aritst] = new Tuple<double, HitomiAnalysisArtist>(score[data.Aritst].Item1 + -Math.Pow(Math.Abs(pair.Value - data.GetRate(pair.Key)), 2) * pair.Value, score[data.Aritst].Item2);
                            else
                                score.Add(data.Aritst, new Tuple<double, HitomiAnalysisArtist>(-Math.Pow(Math.Abs(pair.Value - data.GetRate(pair.Key)), 2) * pair.Value, data));
                        }
                    }
                }
            }

            if (xi)
            {
                foreach (var pair in user.GetDictionary())
                {
                    foreach (var data in datas)
                    {
                        if (!data.IsExsit(pair.Key) && score.ContainsKey(data.Aritst))
                            score[data.Aritst] = new Tuple<double, HitomiAnalysisArtist>(score[data.Aritst].Item1 + -pair.Value * pair.Value * pair.Value, score[data.Aritst].Item2);
                    }
                }
            }

            ///////////////////////////////

            var list = score.ToList();

            if (xi)
            {
                double min_score = 0.0;
                foreach (var tuple in list)
                {
                    min_score = Math.Min(min_score, tuple.Value.Item1);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = new KeyValuePair<string, Tuple<double, HitomiAnalysisArtist>>(list[i].Key, new Tuple<double, HitomiAnalysisArtist>((list[i].Value.Item1 - min_score) * 100, list[i].Value.Item2));
                }
            }

            ///////////////////////////////

            if (FilterArtists)
            {
                Dictionary<string, int> artists_galleris_count_log = new Dictionary<string, int>();

                foreach (var artist in HitomiLog.Instance.GetEnumerator().Where(data => data.Artists != null).SelectMany(data => data.Artists))
                {
                    if (artists_galleris_count_log.ContainsKey(artist))
                        artists_galleris_count_log[artist] += 1;
                    else
                        artists_galleris_count_log.Add(artist, 1);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (artists_galleris_count_log.ContainsKey(list[i].Key))
                    {
                        float mul = 1 - (float)artists_galleris_count_log[list[i].Key] / list[i].Value.Item2.MetadataCount;
                        list[i] = new KeyValuePair<string, Tuple<double, HitomiAnalysisArtist>>(list[i].Key, new Tuple<double, HitomiAnalysisArtist>(list[i].Value.Item1 * mul, list[i].Value.Item2));
                    }
                }
            }

            ///////////////////////////////

            if (MustInclude)
            {
                int count = CustomAnalysis.Count;
                for (int i = 0; i < list.Count; i++)
                {
                    if (CustomAnalysis.Any(x => !list[i].Value.Item2.IsExsit(x.Item1)))
                        list.RemoveAt(i--);
                }
            }

            ///////////////////////////////

            list.Sort((p1, p2) => p2.Value.Item1.CompareTo(p1.Value.Item1));

            if (Rank != null) Rank.Clear();
            else Rank = new List<Tuple<string, double, string>>();
            
            foreach (var item in list)
            {
                Rank.Add(new Tuple<string, double, string>(item.Key, item.Value.Item1, item.Value.Item2.GetDetail(user)));
            }
        }
    }
}
