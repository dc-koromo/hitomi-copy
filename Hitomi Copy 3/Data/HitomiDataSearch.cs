﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hitomi_Copy.Data
{
    public class HitomiDataSearch
    {
        private static bool IsIntersect(string[] target, List<string> source)
        {
            bool[] check = new bool[source.Count];
            for (int i = 0; i < source.Count; i++)
                foreach (string e in target)
                    if (e.ToLower().Replace(' ', '_') == source[i].ToLower())
                    {
                        check[i] = true;
                        break;
                    }
            return check.All((x => x));
        }

        private static void IntersectCountSplit(string[] target, List<string> source, ref bool[] check)
        {
            if (target != null)
            {
                for (int i = 0; i < source.Count; i++)
                    foreach (string e in target)
                        if (e.ToLower().Split(' ').Contains(source[i].ToLower()))
                        {
                            check[i] = true;
                            break;
                        }
            }
        }

        public static List<HitomiMetadata> GetSubsetOf(int start, int count)
        {
            List<HitomiMetadata> result = new List<HitomiMetadata>();
            List<string> x_tag = HitomiSetting.Instance.GetModel().ExclusiveTag.ToList();
            foreach (var v in HitomiData.Instance.metadata_collection)
            {
                string lang = v.Language;
                if (v.Language == null) lang = "N/A";
                if (HitomiSetting.Instance.GetModel().Language != "ALL" &&
                    HitomiSetting.Instance.GetModel().Language != lang) continue;
                if (v.Tags != null)
                {
                    int intersec_count = 0;
                    foreach (var tag in x_tag)
                    {
                        foreach (var vtag in v.Tags)
                            if (vtag.ToLower().Replace(' ', '_') == tag.ToLower())
                            { intersec_count++; break; }
                        if (intersec_count > 0) break;
                    }
                    if (intersec_count > 0) continue;
                }
                if (start > 0) { start--; continue; }
                result.Add(v);
                if (--count == 0)
                    break;
            }
            return result;
        }

        public static async Task<List<HitomiMetadata>> Search3(HitomiDataQuery query)
        {
            int number = Environment.ProcessorCount;
            int term = HitomiData.Instance.metadata_collection.Count / number;

            List<Task<List<HitomiMetadata>>> arr_task = new List<Task<List<HitomiMetadata>>>();
            for (int i = 0; i < number; i++)
            {
                int k = i;
                if (k != number - 1)
                    arr_task.Add(new Task<List<HitomiMetadata>>(() => search_internal(query, k * term, k * term + term)));
                else
                    arr_task.Add(new Task<List<HitomiMetadata>>(() => search_internal(query, k * term, HitomiData.Instance.metadata_collection.Count)));
            }
            
            Parallel.ForEach(arr_task, task => task.Start());
            await Task.WhenAll(arr_task);
            
            List<HitomiMetadata> result = new List<HitomiMetadata>();
            for (int i = 0; i < number; i++)
            {
                result.AddRange(arr_task[i].Result);
            }
            result.Sort((a, b) => b.ID - a.ID);

            return result;
        }

        private static List<HitomiMetadata> search_internal(HitomiDataQuery query, int starts, int ends)
        {
            List<HitomiMetadata> result = new List<HitomiMetadata>();
            for (int i = starts; i < ends; i++)
            {
                var v = HitomiData.Instance.metadata_collection[i];
                if (query.Common.Contains(v.ID.ToString()))
                {
                    result.Add(v);
                    continue;
                }
                string lang = v.Language;
                if (v.Language == null) lang = "N/A";
                if (HitomiSetting.Instance.GetModel().Language != "ALL" &&
                    HitomiSetting.Instance.GetModel().Language != lang) continue;
                if (query.TagExclude != null)
                {
                    if (v.Tags != null)
                    {
                        int intersec_count = 0;
                        foreach (var tag in query.TagExclude)
                        {
                            foreach (var vtag in v.Tags)
                                if (vtag.ToLower().Replace(' ', '_') == tag.ToLower())
                                { intersec_count++; break; }
                            if (intersec_count > 0) break;
                        }
                        if (intersec_count > 0) continue;
                    }
                }
                bool[] check = new bool[query.Common.Count];
                if (query.Common != null)
                {
                    IntersectCountSplit(v.Name.Split(' '), query.Common, ref check);
                    IntersectCountSplit(v.Tags, query.Common, ref check);
                    IntersectCountSplit(v.Artists, query.Common, ref check);
                    IntersectCountSplit(v.Groups, query.Common, ref check);
                    IntersectCountSplit(v.Parodies, query.Common, ref check);
                    IntersectCountSplit(v.Characters, query.Common, ref check);
                }
                bool connect = false;
                if (check.Length == 0) { check = new bool[1]; check[0] = true; }
                if (check[0] && v.Artists != null && query.Artists != null) { check[0] = IsIntersect(v.Artists, query.Artists); connect = true; } else if (query.Artists != null) check[0] = false;
                if (check[0] && v.Tags != null && query.TagInclude != null) { check[0] = IsIntersect(v.Tags, query.TagInclude); connect = true; } else if (query.TagInclude != null) check[0] = false;
                if (check[0] && v.Groups != null && query.Groups != null) { check[0] = IsIntersect(v.Groups, query.Groups); connect = true; } else if (query.Groups != null) check[0] = false;
                if (check[0] && v.Parodies != null && query.Series != null) { check[0] = IsIntersect(v.Parodies, query.Series); connect = true; } else if (query.Series != null) check[0] = false;
                if (check[0] && v.Characters != null && query.Characters != null) { check[0] = IsIntersect(v.Characters, query.Characters); connect = true; } else if (query.Characters != null) check[0] = false;
                if (check.All((x => x)) && ((query.Common.Count == 0 && connect) || query.Common.Count > 0))
                    result.Add(v);
            }

            // required
            result.Sort((a, b) => b.ID - a.ID);
            return result;
        }
    }
}
