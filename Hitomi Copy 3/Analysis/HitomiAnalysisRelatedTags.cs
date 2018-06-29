/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hitomi_Copy_3.Analysis
{
    public class HitomiAnalysisRelatedTags
    {
        private static readonly Lazy<HitomiAnalysisRelatedTags> instance = new Lazy<HitomiAnalysisRelatedTags>(() => new HitomiAnalysisRelatedTags());
        public static HitomiAnalysisRelatedTags Instance => instance.Value;

        public Dictionary<string, List<Tuple<string, double>>> result = new Dictionary<string, List<Tuple<string, double>>>();

        public List<KeyValuePair<string, List<int>>> tags_list;
        public List<Tuple<string, string, double>> results = new List<Tuple<string, string, double>>();

        public bool IncludeFemaleMaleOnly = false;
        public double Threshold = 0.1;

        public HitomiAnalysisRelatedTags()
        {
            Dictionary<string, List<int>> tags_dic = new Dictionary<string, List<int>>();

            foreach (var data in HitomiData.Instance.metadata_collection)
            {
                if (data.Tags != null)
                {
                    foreach (var tag in data.Tags)
                    {
                        if (IncludeFemaleMaleOnly && !tag.StartsWith("female:") && !tag.StartsWith("male:")) continue;
                        if (tags_dic.ContainsKey(tag))
                            tags_dic[tag].Add(data.ID);
                        else
                            tags_dic.Add(tag, new List<int> { data.ID });
                    }
                }
            }

            tags_list = tags_dic.ToList();

            tags_list.ForEach(x => x.Value.Sort());
            tags_list.Sort((a, b) => a.Value.Count.CompareTo(b.Value.Count));
        }

        private int manually_intersect(List<int> a, List<int> b)
        {
            int intersect = 0;
            int i = 0, j = 0;
            for (; i < a.Count && j < b.Count;)
            {
                if (a[i] == b[j])
                {
                    intersect++;
                    i++;
                    j++;
                }
                else if (a[i] < b[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return intersect;
        }
        
        public List<Tuple<string, string, double>> Intersect(int i)
        {
            List<Tuple<string, string, double>> result = new List<Tuple<string, string, double>>();
            
            for (int j = i + 1; j < tags_list.Count; j++)
            {
                int intersect = manually_intersect(tags_list[i].Value, tags_list[j].Value);
                int i_size = tags_list[i].Value.Count;
                int j_size = tags_list[j].Value.Count;
                double rate = (double)(intersect) / (i_size + j_size - intersect);
                if (rate >= Threshold)
                result.Add(new Tuple<string, string, double>(tags_list[i].Key, tags_list[j].Key,
                    rate));
            }

            return result;
        }
        
        public void Merge()
        {
            foreach (var tuple in results)
            {
                if (result.ContainsKey(tuple.Item1))
                    result[tuple.Item1].Add(new Tuple<string, double>(tuple.Item2, tuple.Item3));
                else
                    result.Add(tuple.Item1, new List<Tuple<string, double>> { new Tuple<string, double>(tuple.Item2, tuple.Item3) });
                if (result.ContainsKey(tuple.Item2))
                    result[tuple.Item2].Add(new Tuple<string, double>(tuple.Item1, tuple.Item3));
                else
                    result.Add(tuple.Item2, new List<Tuple<string, double>> { new Tuple<string, double>(tuple.Item1, tuple.Item3) });
            }
            tags_list.Clear();
            results.Clear();
            File.WriteAllText("rt.txt", LogEssential.SerializeObject(result));
        }
    }
}
