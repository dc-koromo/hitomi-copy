﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy
{
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
        }
        
        private void frmStatistics_Load(object sender, EventArgs e)
        {
            ColumnInit();
            
            Task.Run(() => RankingProcess());
            Task.Run(() => UpdateHistory());
        }

        private void ColumnInit()
        {
            ColumnSorter.InitListView(lvRankArtists);
            ColumnSorter.InitListView(lvRankCharacters);
            ColumnSorter.InitListView(lvRankGroup);
            ColumnSorter.InitListView(lvRankSeries);
            ColumnSorter.InitListView(lvRankTag);
            ColumnSorter.InitListView(lvHistory);
        }
        
        private void RankingProcess()
        {
            Dictionary<string, int> rank_tag = new Dictionary<string, int>();
            Dictionary<string, int> rank_artists = new Dictionary<string, int>();
            Dictionary<string, int> rank_series = new Dictionary<string, int>();
            Dictionary<string, int> rank_characters = new Dictionary<string, int>();
            Dictionary<string, int> rank_group = new Dictionary<string, int>();

            var hitomi_data = HitomiData.Instance.metadata_collection;
            foreach (var metadata in hitomi_data)
            {
                if (metadata.Language != "korean") continue;
                if (metadata.Tags != null)
                    metadata.Tags.ToList().ForEach((tag) => { if (rank_tag.ContainsKey(tag)) rank_tag[tag] += 1; else rank_tag.Add(tag, 1); });
                if (metadata.Artists != null)
                    metadata.Artists.ToList().ForEach((artist) => { if (rank_artists.ContainsKey(artist)) rank_artists[artist] += 1; else rank_artists.Add(artist, 1); });
                if (metadata.Parodies != null)
                    metadata.Parodies.ToList().ForEach((series) => { if (rank_series.ContainsKey(series)) rank_series[series] += 1; else rank_series.Add(series, 1); });
                if (metadata.Characters != null)
                    metadata.Characters.ToList().ForEach((character) => { if (rank_characters.ContainsKey(character)) rank_characters[character] += 1; else rank_characters.Add(character, 1); });
                if (metadata.Groups != null)
                    metadata.Groups.ToList().ForEach((group) => { if (rank_group.ContainsKey(group)) rank_group[group] += 1; else rank_group.Add(group, 1); });
            }

            var l1 = rank_tag.ToList();
            l1.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            var l2 = rank_artists.ToList();
            l2.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            var l3 = rank_series.ToList();
            l3.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            var l4 = rank_characters.ToList();
            l4.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            var l5 = rank_group.ToList();
            l5.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            AddTo(lvRankTag, l1);
            AddTo(lvRankArtists, l2);
            AddTo(lvRankSeries, l3);
            AddTo(lvRankCharacters, l4);
            AddTo(lvRankGroup, l5);
        }

        private void AddTo(ListView lv, List<KeyValuePair<string,int>> result)
        {
            List<ListViewItem> lvil = new List<ListViewItem>();
            for (int i = 0; i < result.Count; i++)
            {
                lvil.Add(new ListViewItem(new string[]
                {
                    (i+1).ToString(),
                    result[i].Key,
                    result[i].Value.ToString()
                }));
            }
            AddToRank(lv, lvil.ToArray());
        }
        private void AddToRank(ListView lv, ListViewItem[] items)
        {
            if (lv.InvokeRequired)
            {
                Invoke(new Action<ListView,ListViewItem[]>(AddToRank), new object[] { lv, items });
                return;
            }
            lv.Items.AddRange(items);
        }

        private void UpdateHistory()
        {
            List<HitomiMetadata> result = new List<HitomiMetadata>();
            var hitomi_data = HitomiData.Instance.metadata_collection;
            foreach (var elem in HitomiLog.Instance.GetEnumerator().Reverse())
            {
                foreach (var data in hitomi_data)
                {
                    if (elem.Id == data.ID.ToString())
                    {
                        result.Add(data);
                        break;
                    }
                }
            }
            HitomiLog.Instance.Save();

            List<ListViewItem> lvil = new List<ListViewItem>();
            for (int i = 0; i < result.Count; i++)
            {
                lvil.Add(new ListViewItem(new string[]
                {
                    result[i].ID.ToString(),
                    result[i].Name,
                    result[i].Type,
                    string.Join(",", result[i].Artists ?? Enumerable.Empty<string>()),
                    string.Join(",", result[i].Groups ?? Enumerable.Empty<string>()),
                    string.Join(",", result[i].Parodies ?? Enumerable.Empty<string>()),
                    string.Join(",", result[i].Characters ?? Enumerable.Empty<string>()),
                    string.Join(",", result[i].Tags ?? Enumerable.Empty<string>())
                }));
            }
            AddToHistory(lvil.ToArray());

        }
        private void AddToHistory(ListViewItem[] items)
        {
            if (lvHistory.InvokeRequired)
            {
                Invoke(new Action<ListViewItem[]>(AddToHistory), new object[] { items });
                return;
            }
            lvHistory.Items.AddRange(items);
        }

        private void lvHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvHistory.SelectedItems.Count > 0)
            {
                var hitomi_data = HitomiData.Instance.metadata_collection;
                foreach (var metadata in hitomi_data)
                {
                    if (metadata.ID.ToString() == lvHistory.SelectedItems[0].SubItems[0].Text)
                    {
                        (new frmGalleryInfo(this, metadata)).Show();
                        return;
                    }
                }
            }
        }

        private void lvRankArtists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRankArtists.SelectedItems.Count > 0)
            {
                (new frmArtistInfo(this, lvRankArtists.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void lvRankGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRankGroup.SelectedItems.Count > 0)
            {
                (new frmGroupInfo(this, lvRankGroup.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void lvRankTag_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRankTag.SelectedItems.Count > 0)
            {
                (new frmTagInfo(this, lvRankTag.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }
        
        private void lvRankSeries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRankSeries.SelectedItems.Count > 0)
            {
                (new frmSeriesInfo(this, lvRankSeries.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void lvRankCharacters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvRankCharacters.SelectedItems.Count > 0)
            {
                (new frmCharacterInfo(this, lvRankCharacters.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }
        
        private void bApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, int> my_tag_rank = new Dictionary<string, int>();
                string[] split = tbFilter.Text.Split(' ');
                try
                {
                    for (int i = 0; i < split.Length; i += 2)
                        my_tag_rank.Add(split[i], Convert.ToInt32(split[i + 1]));
                }
                catch { }

                var tag_rank_list = my_tag_rank.ToList();
                tag_rank_list.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

                var hitomi_data = HitomiData.Instance.metadata_collection;
                Dictionary<string, Dictionary<string, int>> artists_tag_count = new Dictionary<string, Dictionary<string, int>>();
                foreach (var metadata in hitomi_data)
                {
                    if (metadata.Language != "korean") continue;
                    if (metadata.Artists == null || metadata.Tags == null || metadata.Artists.Length == 0) continue;
                    if (!artists_tag_count.ContainsKey(metadata.Artists[0]))
                        artists_tag_count.Add(metadata.Artists[0], new Dictionary<string, int>());
                    foreach (var tag in metadata.Tags)
                    {
                        if (!artists_tag_count[metadata.Artists[0]].ContainsKey(tag))
                            artists_tag_count[metadata.Artists[0]].Add(tag, 1);
                        else
                            artists_tag_count[metadata.Artists[0]][tag] += 1;
                    }
                }

                var myList = artists_tag_count.ToList();
                var artist_tag_rank = new List<Tuple<string, KeyValuePair<string, int>[]>>();
                for (int i = 0; i < myList.Count; i++)
                {
                    artist_tag_rank.Add(new Tuple<string, KeyValuePair<string, int>[]>(myList[i].Key, myList[i].Value.OrderBy(key => key.Value).ToArray()));
                }

                List<Tuple<string, int, string>> result = new List<Tuple<string, int, string>>();
                for (int i = 0; i < artist_tag_rank.Count; i++)
                {
                    List<Tuple<string, int>> tag_score = new List<Tuple<string, int>>();
                    int score = artist_tag_rank[i].Item2.Last().Value * tag_rank_list[0].Value;
                    tag_score.Add(new Tuple<string, int>(tag_rank_list[0].Key, artist_tag_rank[i].Item2.Last().Value * tag_rank_list[0].Value));
                    for (int j = artist_tag_rank[i].Item2.Count() - 1; j >= 0; j--)
                    {
                        for (int k = 1; k < tag_rank_list.Count; k++)
                        {
                            if (artist_tag_rank[i].Item2[j].Key == tag_rank_list[k].Key)
                            {
                                score += artist_tag_rank[i].Item2[j].Value * tag_rank_list[k].Value;
                                tag_score.Add(new Tuple<string, int>(tag_rank_list[k].Key, artist_tag_rank[i].Item2[j].Value * tag_rank_list[k].Value));
                            }
                        }
                    }
                    var tag_score_list = tag_score.ToList();
                    tag_score_list.Sort((pair1, pair2) => pair2.Item2.CompareTo(pair1.Item2));
                    StringBuilder builder = new StringBuilder();
                    for (int j = 0; j < tag_score_list.Count; j++)
                        builder.Append($"{tag_score_list[j].Item1}({tag_score_list[j].Item2}),");
                    result.Add(new Tuple<string, int, string>(artist_tag_rank[i].Item1, score, builder.ToString()));
                }

                result.Sort((pair1, pair2) => pair2.Item2.CompareTo(pair1.Item2));

                List<ListViewItem> lvil = new List<ListViewItem>();
                for (int i = 0; i < result.Count && i < 500; i++)
                {
                    lvil.Add(new ListViewItem(new string[]
                    {
                    (i+1).ToString(),
                    result[i].Item1,
                    result[i].Item2.ToString(),
                    result[i].Item3
                    }));
                }
                AddToArtistSearch(lvil.ToArray());
            } catch { }
        }

        private void AddToArtistSearch(ListViewItem[] items)
        {
            if (lvSearch.InvokeRequired)
            {
                Invoke(new Action<ListViewItem[]>(AddToArtistSearch), new object[] { items });
                return;
            }
            lvSearch.Items.Clear();
            lvSearch.Items.AddRange(items);
        }

        private void lvSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSearch.SelectedItems.Count > 0)
            {
                (new frmArtistInfo(this, lvSearch.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bApplyFilter.PerformClick();
        }
    }
}