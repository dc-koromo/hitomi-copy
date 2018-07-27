/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using Hitomi_Copy_2.Analysis;
using Hitomi_Copy_3.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class InfoDetail : Form
    {
        string type;
        string contents;
        HitomiPortableAnalysis hpa = new HitomiPortableAnalysis();

        public InfoDetail(string type, string contents)
        {
            InitializeComponent();

            this.type = type;
            this.contents = contents.Replace('_', ' ');
        }

        private async void InfoDetail_LoadAsync(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(lvArtists);
            ColumnSorter.InitListView(lvCharacters);
            ColumnSorter.InitListView(lvSeries);

            Text += $"{type} : {contents}";

            Dictionary<string, int> series = new Dictionary<string, int>();
            Dictionary<string, int> characters = new Dictionary<string, int>();
            Dictionary<string, int> tags = new Dictionary<string, int>();
            
            foreach (var metadata in HitomiData.Instance.metadata_collection)
            {
                string lang = metadata.Language;
                if (metadata.Language == null) lang = "N/A";
                if (HitomiSetting.Instance.GetModel().Language != "ALL" &&
                    HitomiSetting.Instance.GetModel().Language != lang) continue;

                if ((type == "작가" && metadata.Artists?.Contains(contents) == true) ||
                    (type == "그룹" && metadata.Groups?.Contains(contents) == true))
                {
                    if (metadata.Parodies != null)
                        foreach (var artist in metadata.Parodies)
                            if (series.ContainsKey(artist))
                                series[artist] += 1;
                            else
                                series.Add(artist, 1);

                    if (metadata.Characters != null)
                        foreach (var character in metadata.Characters)
                            if (characters.ContainsKey(character))
                                characters[character] += 1;
                            else
                                characters.Add(character, 1);

                    if (metadata.Tags != null)
                        foreach (var tag in metadata.Tags)
                            if (tags.ContainsKey(tag))
                                tags[tag] += 1;
                            else
                                tags.Add(tag, 1);
                }
            }

            var series_list = series.ToList();
            series_list.Sort((a, b) => b.Value.CompareTo(a.Value));
            var characters_list = characters.ToList();
            characters_list.Sort((a, b) => b.Value.CompareTo(a.Value));

            hpa.CustomAnalysis = tags.Select(x => new Tuple<string, int>(x.Key, x.Value)).ToList();

            for (int i = 0; i < series_list.Count; i++)
            {
                lvSeries.Items.Add(new ListViewItem(new string[]
                {
                    (i + 1).ToString(),
                    series_list[i].Key,
                    series_list[i].Value.ToString()
                }));
            }

            for (int i = 0; i < characters_list.Count; i++)
            {
                lvCharacters.Items.Add(new ListViewItem(new string[]
                {
                    (i + 1).ToString(),
                    characters_list[i].Key,
                    characters_list[i].Value.ToString()
                }));
            }

            await Task.Run(() => hpa.Update());

            List<ListViewItem> lvi = new List<ListViewItem>();
            for (int i = 0; i < hpa.Rank.Count; i++)
            {
                lvi.Add(new ListViewItem(new string[] {
                    (i + 1).ToString(),
                    hpa.Rank[i].Item1,
                    HitomiAnalysis.Instance.ArtistCount[hpa.Rank[i].Item1].ToString(),
                    hpa.Rank[i].Item2.ToString(),
                    hpa.Rank[i].Item3
                }));
            }
            this.Post(() => lvArtists.Items.AddRange(lvi.ToArray()));
        }

        private void lvSeries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSeries.SelectedItems.Count == 1)
            {
                (new frmFinder("series:" + lvSeries.SelectedItems[0].SubItems[1].Text.Replace(' ', '_'))).Show();
            }
        }

        private void lvCharacters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCharacters.SelectedItems.Count == 1)
            {
                (new frmFinder("character:" + lvCharacters.SelectedItems[0].SubItems[1].Text.Replace(' ', '_'))).Show();
            }
        }

        private void lvArtists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvArtists.SelectedItems.Count > 0)
            {
                (new frmArtistInfo(this, lvArtists.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            HitomiAnalysis.Instance.UserDefined = true;
            HitomiAnalysis.Instance.CustomAnalysis = hpa.CustomAnalysis;
            (Application.OpenForms[0] as frmMain).UpdateNewStatistics();
        }
    }
}
