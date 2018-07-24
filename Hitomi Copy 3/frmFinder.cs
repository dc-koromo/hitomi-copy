/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmFinder : Form
    {
        string search = "";

        public frmFinder()
        {
            InitializeComponent();
        }

        public frmFinder(string search)
        {
            InitializeComponent();

            this.search = search;
        }

        private void frmFinder_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(lvHistory);

            if (search != "")
            {
                tbSearch.Text = search;
                bSearch.PerformClick();
            }
        }
        
        #region 검색창
        public int global_position = 0;
        public string global_text = "";
        public bool selected_part = false;

        private int GetCaretWidthFromTextBox(int pos)
        {
            return TextRenderer.MeasureText(tbSearch.Text.Substring(0, pos), tbSearch.WaterMarkFont).Width;
        }
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                bSearch.PerformClick();
            else if (e.KeyData == Keys.Escape)
            {
                listBox1.Hide();
                tbSearch.Focus();
            }
            else
            {
                if (listBox1.Visible)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        listBox1.SelectedIndex = 0;
                        listBox1.Focus();
                    }
                    else if (e.KeyCode == Keys.Up)
                    {
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                        listBox1.Focus();
                    }
                }

                if (selected_part)
                {
                    selected_part = false;
                    if (e.KeyCode != Keys.Back)
                    {
                        tbSearch.SelectionStart = global_position;
                        tbSearch.SelectionLength = 0;
                    }
                }

            }
        }

        private void tbSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) return;
            int position = tbSearch.SelectionStart;
            while (position > 0 && tbSearch.Text[position - 1] != ' ')
                position -= 1;

            string word = "";
            for (int i = position; i < tbSearch.Text.Length; i++)
            {
                if (tbSearch.Text[i] == ' ') break;
                word += tbSearch.Text[i];
            }

            if (word == "") { listBox1.Visible = false; return; }

            List<HitomiTagdata> match = new List<HitomiTagdata>();
            if (word.Contains(":"))
            {
                if (word.StartsWith("artist:"))
                {
                    word = word.Substring("artist:".Length);
                    position += "artist:".Length;
                    match = HitomiData.Instance.GetArtistList(word);
                }
                else if (word.StartsWith("tag:"))
                {
                    word = word.Substring("tag:".Length);
                    position += "tag:".Length;
                    match = HitomiData.Instance.GetTagList(word);
                }
                else if (word.StartsWith("tagx:"))
                {
                    word = word.Substring("tagx:".Length);
                    position += "tagx:".Length;
                    match = HitomiData.Instance.GetTagList(word);
                }
                else if (word.StartsWith("character:"))
                {
                    word = word.Substring("character:".Length);
                    position += "character:".Length;
                    match = HitomiData.Instance.GetCharacterList(word);
                }
                else if (word.StartsWith("group:"))
                {
                    word = word.Substring("group:".Length);
                    position += "group:".Length;
                    match = HitomiData.Instance.GetGroupList(word);
                }
                else if (word.StartsWith("series:"))
                {
                    word = word.Substring("series:".Length);
                    position += "series:".Length;
                    match = HitomiData.Instance.GetSeriesList(word);
                }
                else if (word.StartsWith("type:"))
                {
                    word = word.Substring("type:".Length);
                    position += "type:".Length;
                    match = HitomiData.Instance.GetTypeList(word);
                }
            }

            string[] match_target = {
                "artist:",
                "character:",
                "group:",
                "recent:",
                "series:",
                "tag:",
                "tagx:",
                "type:"
            };

            List<HitomiTagdata> data_col = (from ix in match_target where ix.StartsWith(word) select new HitomiTagdata { Tag = ix }).ToList();
            if (HitomiSetting.Instance.GetModel().CustomAutoComplete != null)
                data_col.AddRange(from ix in HitomiSetting.Instance.GetModel().CustomAutoComplete where ix.StartsWith(word) select new HitomiTagdata { Tag = ix });
            if (data_col.Count > 0)
                match.AddRange(data_col);
            match.AddRange(HitomiData.Instance.GetTotalList(word));

            if (match != null && match.Count > 0)
            {
                listBox1.Visible = true;
                listBox1.Items.Clear();
                for (int i = 0; i < HitomiSetting.Instance.GetModel().AutoCompleteShowCount && i < match.Count; i++)
                {
                    if (match[i].Count > 0)
                        listBox1.Items.Add(match[i].Tag + $" ({match[i].Count})");
                    else
                        listBox1.Items.Add(match[i].Tag);
                }
                listBox1.Location = new Point(tbSearch.Left + GetCaretWidthFromTextBox(position),
                    tbSearch.Top + tbSearch.Font.Height + 5);
                listBox1.MaxColoredTextLength = word.Length;
                listBox1.ColoredTargetText = word;
            }
            else { listBox1.Visible = false; return; }

            global_position = position;
            global_text = word;

            if (e.KeyCode == Keys.Down)
            {
                listBox1.SelectedIndex = 0;
                listBox1.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.Focus();
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                PutStringIntoTextBox(listBox1.Items[0].ToString());
            }
        }

        private void PutStringIntoTextBox(string text)
        {
            text = text.Split('(')[0].Trim();
            tbSearch.Text = tbSearch.Text.Substring(0, global_position) +
                text +
                tbSearch.Text.Substring(global_position + global_text.Length);
            listBox1.Hide();

            tbSearch.SelectionStart = global_position;
            tbSearch.SelectionLength = text.Length;
            tbSearch.Focus();

            global_position = global_position + tbSearch.SelectionLength;
            selected_part = true;
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                if (listBox1.SelectedItems.Count > 0)
                    PutStringIntoTextBox(listBox1.SelectedItem.ToString());
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Escape)
            {
                listBox1.Hide();
                tbSearch.Focus();
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                PutStringIntoTextBox(listBox1.SelectedItem.ToString());
            }
        }
        #endregion

        private void lvHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvHistory.SelectedItems.Count > 0)
            {
                var hitomi_data = HitomiData.Instance.metadata_collection;
                string target = lvHistory.SelectedItems[0].SubItems[0].Text;
                foreach (var metadata in hitomi_data)
                {
                    if (metadata.ID.ToString() == target)
                    {
                        (new frmGalleryInfo(this, metadata)).Show();
                        return;
                    }
                }
            }
        }

        private async void bSearch_ClickAsync(object sender, EventArgs e)
        {
            LogEssential.Instance.PushLog(() => $"Search : \"{tbSearch.Text}\"");
            
            HitomiDataQuery query = new HitomiDataQuery();
            List<string> positive_data = new List<string>();
            List<string> negative_data = new List<string>();
            List<string> request_number = new List<string>();
            int start_element = 0;
            int count_element = 0;
            bool recent = false;
            int recent_count = 0;
            int recent_start = 0;

            tbSearch.Text.Trim().Split(' ').ToList().ForEach((a) => { if (a.StartsWith("/")) start_element = Convert.ToInt32(a.Substring(1)); });
            tbSearch.Text.Trim().Split(' ').ToList().ForEach((a) => { if (a.StartsWith("?")) count_element = Convert.ToInt32(a.Substring(1)); });
            tbSearch.Text.Trim().Split(' ').ToList().ForEach((a) => { if (!a.Contains(":") && !a.StartsWith("/") && !a.StartsWith("?")) positive_data.Add(a.Trim()); });
            query.Common = positive_data;
            query.TagExclude = negative_data;
            foreach (var elem in from elem in tbSearch.Text.Trim().Split(' ') where elem.Contains(":") where !elem.StartsWith("/") where !elem.StartsWith("?") select elem)
            {
                if (elem.StartsWith("tag:"))
                    if (query.TagInclude == null)
                        query.TagInclude = new List<string>() { elem.Substring("tag:".Length) };
                    else
                        query.TagInclude.Add(elem.Substring("tag:".Length));
                else if (elem.StartsWith("female:"))
                    if (query.TagInclude == null)
                        query.TagInclude = new List<string>() { elem };
                    else
                        query.TagInclude.Add(elem);
                else if (elem.StartsWith("male:"))
                    if (query.TagInclude == null)
                        query.TagInclude = new List<string>() { elem };
                    else
                        query.TagInclude.Add(elem);
                else if (elem.StartsWith("artist:"))
                    if (query.Artists == null)
                        query.Artists = new List<string>() { elem.Substring("artist:".Length) };
                    else
                        query.Artists.Add(elem.Substring("artist:".Length));
                else if (elem.StartsWith("series:"))
                    if (query.Series == null)
                        query.Series = new List<string>() { elem.Substring("series:".Length) };
                    else
                        query.Series.Add(elem.Substring("series:".Length));
                else if (elem.StartsWith("group:"))
                    if (query.Groups == null)
                        query.Groups = new List<string>() { elem.Substring("group:".Length) };
                    else
                        query.Groups.Add(elem.Substring("group:".Length));
                else if (elem.StartsWith("character:"))
                    if (query.Characters == null)
                        query.Characters = new List<string>() { elem.Substring("character:".Length) };
                    else
                        query.Characters.Add(elem.Substring("character:".Length));
                else if (elem.StartsWith("tagx:"))
                    if (query.TagExclude == null)
                        query.TagExclude = new List<string>() { elem.Substring("tagx:".Length) };
                    else
                        query.TagExclude.Add(elem.Substring("tagx:".Length));
                else if (elem.StartsWith("type:"))
                    if (query.Type == null)
                        query.Type = new List<string>() { elem.Substring("type:".Length) };
                    else
                        query.Type.Add(elem.Substring("type:".Length));
                else if (elem.StartsWith("request:"))
                    request_number.Add(elem.Substring("request:".Length));
                else if (elem.StartsWith("recent:"))
                {
                    recent = true;
                    try
                    {
                        if (elem.Substring("recent:".Length).Contains("-"))
                        {
                            recent_start = Convert.ToInt32(elem.Substring("recent:".Length).Split('-')[0]);
                            recent_count = Convert.ToInt32(elem.Substring("recent:".Length).Split('-')[1]);
                        }
                        else
                            recent_count = Convert.ToInt32(elem.Substring("recent:".Length));
                    }
                    catch
                    {
                        MetroMessageBox.Show(this, $"recent 규칙 오류입니다. \"{elem}\"", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tbSearch.Text = "recent:" + (recent_start + recent_count) + "-" + recent_count;
                }
                else
                {
                    MetroMessageBox.Show(this, $"알 수 없는 규칙입니다. \"{elem}\"", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Stopwatch sw = Stopwatch.StartNew();
            List<HitomiMetadata> query_result;
            if (recent == true)
            {
                query_result = HitomiDataSearch.GetSubsetOf(recent_start, recent_count);
            }
            else
            {
                query_result = (await HitomiDataSearch.Search3(query));
            }
            long end = sw.ElapsedMilliseconds;
            sw.Stop();
            label1.Text = $"{query_result.Count.ToString()}개 ({end / 1000.0} 초)";

            if (start_element != 0 && start_element <= query_result.Count) query_result.RemoveRange(0, start_element);
            if (count_element != 0 && count_element < query_result.Count) query_result.RemoveRange(count_element, query_result.Count - count_element);

            if (query_result.Count == 0)
            {
                MetroMessageBox.Show(this, "검색된 항목이 없습니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<ListViewItem> lvil = new List<ListViewItem>();
                for (int i = 0; i < query_result.Count; i++)
                {
                    lvil.Add(new ListViewItem(new string[]
                    {
                        query_result[i].ID.ToString(),
                        query_result[i].Name,
                        query_result[i].Type,
                        string.Join(",", query_result[i].Artists ?? Enumerable.Empty<string>()),
                        string.Join(",", query_result[i].Groups ?? Enumerable.Empty<string>()),
                        string.Join(",", query_result[i].Parodies ?? Enumerable.Empty<string>()),
                        string.Join(",", query_result[i].Characters ?? Enumerable.Empty<string>()),
                        HitomiDate.estimate_datetime(query_result[i].ID).ToString(),
                        string.Join(",", query_result[i].Tags ?? Enumerable.Empty<string>()),
                        HitomiLog.Instance.Contains(query_result[i].ID.ToString()) ? "★" : "",
                        HitomiData.Instance.thumbnail_collection.ContainsKey(query_result[i].ID.ToString()) ? "★" : ""
                    }));
                }
                lvil.Sort((a, b) => Convert.ToUInt32(b.SubItems[0].Text).CompareTo(Convert.ToUInt32(a.SubItems[0].Text)));
                lvHistory.Items.Clear();
                lvHistory.Items.AddRange(lvil.ToArray());
            }

            LogEssential.Instance.PushLog(query);
            LogEssential.Instance.PushLog(() => $"Result : {query_result.Count}");
            if (HitomiSetting.Instance.GetModel().DetailedLog)
                LogEssential.Instance.PushLog(query_result);
        }

        private void bDownload_Click(object sender, EventArgs e)
        {
            foreach (var id in lvHistory.SelectedItems)
                (Application.OpenForms[0] as frmMain).RemoteDownloadArticleFromId((id as ListViewItem).SubItems[0].Text);
            (Application.OpenForms[0] as frmMain).BringToFront();
        }

        private void bDownloadAll_Click(object sender, EventArgs e)
        {
            foreach (var id in lvHistory.Items)
                (Application.OpenForms[0] as frmMain).RemoteDownloadArticleFromId((id as ListViewItem).SubItems[0].Text);
            (Application.OpenForms[0] as frmMain).BringToFront();
        }
        
        private void 제목으로검색TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvHistory.SelectedItems.Count > 0)
            {
                (new frmFinder(lvHistory.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }
        
        private void Artist_Click(object sender, EventArgs e)
        {
            (new frmFinder("artist:" + (sender as ToolStripMenuItem).Text.Replace(' ', '_'))).Show();
        }

        private void Group_Click(object sender, EventArgs e)
        {
            (new frmFinder("group:" + (sender as ToolStripMenuItem).Text.Replace(' ', '_'))).Show();
        }

        private void Series_Click(object sender, EventArgs e)
        {
            (new frmFinder("series:" + (sender as ToolStripMenuItem).Text.Split('(')[0].Trim().Replace(' ', '_'))).Show();
        }

        private void Character_Click(object sender, EventArgs e)
        {
            (new frmFinder("character:" + (sender as ToolStripMenuItem).Text.Replace(' ', '_'))).Show();
        }

        private void Tag_Click(object sender, EventArgs e)
        {
            (new frmFinder("tag:" + (sender as ToolStripMenuItem).Text.Split('(')[0].Trim().Replace(' ', '_'))).Show();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (lvHistory.SelectedItems.Count > 0)
            {
                string[] artist = lvHistory.SelectedItems[0].SubItems[3].Text.Split(',').Select(x => x.Trim()).ToArray();
                string[] group = lvHistory.SelectedItems[0].SubItems[4].Text.Split(',').Select(x => x.Trim()).ToArray();
                string[] series = lvHistory.SelectedItems[0].SubItems[5].Text.Split(',').Select(x => x.Trim()).ToArray();
                string[] character = lvHistory.SelectedItems[0].SubItems[6].Text.Split(',').Select(x => x.Trim()).ToArray();
                string[] tag = lvHistory.SelectedItems[0].SubItems[8].Text.Split(',').Select(x => x.Trim()).ToArray();

                (contextMenuStrip1.Items[1] as ToolStripMenuItem).DropDownItems.Clear();
                if (artist[0] != "") (contextMenuStrip1.Items[1] as ToolStripMenuItem).DropDownItems.AddRange(artist.Select(x => new ToolStripMenuItem(x, null, Artist_Click)).ToArray());

                (contextMenuStrip1.Items[2] as ToolStripMenuItem).DropDownItems.Clear();
                if (group[0] != "") (contextMenuStrip1.Items[2] as ToolStripMenuItem).DropDownItems.AddRange(group.Select(x => new ToolStripMenuItem(x, null, Group_Click)).ToArray());

                (contextMenuStrip1.Items[3] as ToolStripMenuItem).DropDownItems.Clear();
                if (series[0] != "") (contextMenuStrip1.Items[3] as ToolStripMenuItem).DropDownItems.AddRange(series.Select(x => {
                    string ko = KoreanSeries.SeriesMap(x);
                    if (ko != x)
                        return new ToolStripMenuItem($"{x} ({ko})", null, Series_Click);
                    else
                        return new ToolStripMenuItem($"{x}", null, Series_Click);
                }).ToArray());

                (contextMenuStrip1.Items[4] as ToolStripMenuItem).DropDownItems.Clear();
                if (character[0] != "") (contextMenuStrip1.Items[4] as ToolStripMenuItem).DropDownItems.AddRange(character.Select(x => new ToolStripMenuItem(x, null, Character_Click)).ToArray());

                (contextMenuStrip1.Items[5] as ToolStripMenuItem).DropDownItems.Clear();
                if (tag[0] != "") (contextMenuStrip1.Items[5] as ToolStripMenuItem).DropDownItems.AddRange(tag.Select(x => {
                    string ko = KoreanTag.TagMap(x);
                    if (ko != x)
                    {
                        if (ko.Contains(':'))
                            return new ToolStripMenuItem($"{x} ({ko.Split(':')[1]})", null, Tag_Click);
                        else
                            return new ToolStripMenuItem($"{x} ({ko})", null, Tag_Click);
                    }
                    else
                        return new ToolStripMenuItem($"{x}", null, Tag_Click);
                }).ToArray());
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
    }
}
