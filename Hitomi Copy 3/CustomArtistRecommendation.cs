/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using Hitomi_Copy_2.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class CustomArtistRecommendation : Form
    {
        public CustomArtistRecommendation()
        {
            InitializeComponent();
        }

        private void CustomArtistRecommendation_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(lvCustomTag);
            ColumnSorter.InitListView(lvArtists);
            
            Dictionary<string, int> tags_map = new Dictionary<string, int>();

            if (!HitomiAnalysis.Instance.UserDefined)
            {
                foreach (var log in HitomiLog.Instance.GetEnumerator().Where(log => log.Tags != null))
                {
                    foreach (var tag in log.Tags)
                    {
                        if (HitomiSetting.Instance.GetModel().UsingOnlyFMTagsOnAnalysis &&
                            !tag.StartsWith("female:") && !tag.StartsWith("male:")) continue;
                        if (tags_map.ContainsKey(HitomiCommon.LegalizeTag(tag)))
                            tags_map[HitomiCommon.LegalizeTag(tag)] += 1;
                        else
                            tags_map.Add(HitomiCommon.LegalizeTag(tag), 1);
                    }
                }
            }

            var list = tags_map.ToList();
            if (HitomiAnalysis.Instance.UserDefined)
                list = HitomiAnalysis.Instance.CustomAnalysis.Select(x => new KeyValuePair<string, int>(x.Item1, x.Item2)).ToList();
            list.Sort((a, b) => b.Value.CompareTo(a.Value));

            List<ListViewItem> lvil = new List<ListViewItem>();
            foreach (var item in list)
                lvil.Add(new ListViewItem(new string[] { item.Key, item.Value.ToString() }));
            lvCustomTag.Items.Clear();
            lvCustomTag.Items.AddRange(lvil.ToArray());
            
            lvil.Clear();
            var list2 = HitomiAnalysis.Instance.Rank.ToList();
            for (int i = 0; i < list2.Count; i++)
            {
                lvil.Add(new ListViewItem(new string[] {
                    (i + 1).ToString(),
                    list2[i].Item1,
                    HitomiAnalysis.Instance.ArtistCount[list2[i].Item1].ToString(),
                    list2[i].Item2.ToString(),
                    list2[i].Item3
                }));
            }
            lvArtists.Items.Clear();
            lvArtists.Items.AddRange(lvil.ToArray());
        }

        private void lvCustomTag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (ListViewItem eachItem in lvCustomTag.SelectedItems)
                    lvCustomTag.Items.Remove(eachItem);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                foreach (ListViewItem eachItem in lvCustomTag.Items)
                    eachItem.Selected = true;
            }
        }

        private void bUpdate_ClickAsync(object sender, EventArgs e)
        {
            HitomiAnalysis.Instance.UserDefined = true;
            HitomiAnalysis.Instance.CustomAnalysis.Clear();
            
            foreach (var lvi in lvCustomTag.Items.OfType<ListViewItem>())
                HitomiAnalysis.Instance.CustomAnalysis.Add(new Tuple<string, int>(lvi.SubItems[0].Text, Convert.ToInt32(lvi.SubItems[1].Text)));
            
            (Application.OpenForms[0] as frmMain).UpdateNewStatistics();

            List<ListViewItem> lvil = new List<ListViewItem>();
            var list2 = HitomiAnalysis.Instance.Rank.ToList();
            for (int i = 0; i < list2.Count; i++)
            {
                lvil.Add(new ListViewItem(new string[] {
                    (i + 1).ToString(),
                    list2[i].Item1,
                    HitomiAnalysis.Instance.ArtistCount[list2[i].Item1].ToString(),
                    list2[i].Item2.ToString(),
                    list2[i].Item3
                }));
            }
            lvArtists.Items.Clear();
            lvArtists.Items.AddRange(lvil.ToArray());
        }

        private void bAddTag_Click(object sender, EventArgs e)
        {
            CARTag frm = new CARTag(this);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void bAddArtistTag_Click(object sender, EventArgs e)
        {
            CARArtist frm = new CARArtist(this);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private int GetTagScoreBasedOnOption(int old, int _new)
        {
            if (opAdd.Checked == true) return old + _new;
            if (opMul.Checked == true && old != 0) return old * _new;
            return _new;
        }
        
        public void RequestAddTags(string tags, string score)
        {
            foreach (var ttag in tags.Trim().Split(' '))
            {
                string tag = ttag.Replace('_', ' ');
                if (!lvCustomTag.Items.OfType<ListViewItem>().ToList().Any(x => {
                    if (x.SubItems[0].Text == tag)
                        x.SubItems[1].Text = GetTagScoreBasedOnOption(Convert.ToInt32(x.SubItems[1].Text), Convert.ToInt32(score)).ToString();
                    return x.SubItems[0].Text == tag; }))
                {
                    lvCustomTag.Items.Add(new ListViewItem(new string[] { tag, score }));
                }
            }
        }

        public void RequestAddArtists(string artists, string score)
        {
            Dictionary<string, int> tags = new Dictionary<string, int>();

            foreach (var artist in artists.Trim().Split(' '))
            {
                foreach (var data in HitomiData.Instance.metadata_collection)
                {
                    if (!HitomiSetting.Instance.GetModel().RecommendLanguageALL)
                    {
                        string lang = data.Language;
                        if (data.Language == null) lang = "N/A";
                        if (HitomiSetting.Instance.GetModel().Language != "ALL" &&
                            HitomiSetting.Instance.GetModel().Language != lang) continue;
                    }
                    if (data.Artists != null && data.Tags != null && data.Artists.Contains(artist.Replace('_', ' ')))
                    {
                        foreach (var tag in data.Tags)
                        {
                            if (tags.ContainsKey(tag))
                                tags[tag] = tags[tag] + 1;
                            else
                                tags.Add(tag, 1);
                        }
                    }
                }
            }

            var list = tags.ToList();
            list.Sort((a, b) => b.Value.CompareTo(a.Value));

            foreach (var tag in list)
            {
                if (!lvCustomTag.Items.OfType<ListViewItem>().ToList().Any(x => {
                    if (x.SubItems[0].Text == tag.Key)
                        x.SubItems[1].Text = GetTagScoreBasedOnOption(Convert.ToInt32(x.SubItems[1].Text), tag.Value * Convert.ToInt32(score)).ToString();
                    return x.SubItems[0].Text == tag.Key;
                }))
                {
                    lvCustomTag.Items.Add(new ListViewItem(new string[] { tag.Key, (tag.Value * Convert.ToInt32(score)).ToString() }));
                }
            }
        }

        public void RequestLoadCustomTags(string index)
        {
            int ix = HitomiBookmark.Instance.GetModel().CustomTags.Count - Convert.ToInt32(index);

            List<ListViewItem> lvil = new List<ListViewItem>();
            foreach (var item in HitomiBookmark.Instance.GetModel().CustomTags[ix].Item2)
                lvil.Add(new ListViewItem(new string[] { item.Item1, item.Item2.ToString() }));
            lvCustomTag.Items.Clear();
            lvCustomTag.Items.AddRange(lvil.ToArray());

        }

        private void lvArtists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvArtists.SelectedItems.Count > 0)
            {
                (new frmArtistInfo(this, lvArtists.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void bBookmark_Click(object sender, EventArgs e)
        {
            HitomiAnalysis.Instance.CustomAnalysis.Clear();

            foreach (var lvi in lvCustomTag.Items.OfType<ListViewItem>())
                HitomiAnalysis.Instance.CustomAnalysis.Add(new Tuple<string, int>(lvi.SubItems[0].Text, Convert.ToInt32(lvi.SubItems[1].Text)));

            if (tbName.Text.Trim() != "")
            {
                HitomiBookmark.Instance.GetModel().CustomTags.Add(new Tuple<string, List<Tuple<string, int>>, DateTime>(tbName.Text.Trim(), HitomiAnalysis.Instance.CustomAnalysis, DateTime.Now));
                HitomiBookmark.Instance.Save();
                tbName.Text = "";
                MessageBox.Show("북마크에 추가되었습니다!", "Hitomi Copy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("북마크 이름이 비어있습니다.", "Hitomi Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            (new CARBookmark(this)).Show();
        }
    }
}
