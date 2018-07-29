/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmBookmark : Form
    {
        Dictionary<string, ListViewGroup> groups = new Dictionary<string, ListViewGroup>();

        public frmBookmark()
        {
            InitializeComponent();
        }

        private void frmBookmark_Load(object sender, EventArgs e)
        {
            //ColumnSorter.InitListView(listView1);
            ColumnSorter.InitListView(listView2);
            ColumnSorter.InitListView(listView6);
            ColumnSorter.InitListView(listView3);
            ColumnSorter.InitListView(listView4);
            ColumnSorter.InitListView(listView5);

            AddToListGroups(listView1, HitomiBookmark.Instance.GetModel().Artists);
            AddToList(listView2, HitomiBookmark.Instance.GetModel().Groups);
            AddToList(listView6, HitomiBookmark.Instance.GetModel().Articles);
            AddToList(listView3, HitomiBookmark.Instance.GetModel().Tags);
            AddToList(listView4, HitomiBookmark.Instance.GetModel().Series);
            AddToList(listView5, HitomiBookmark.Instance.GetModel().Characters);
        }

        private void AddToListGroups(ListView lv, List<Tuple<string, DateTime, string>> contents)
        {
            ListViewGroup lvg = new ListViewGroup("미분류");
            groups.Add("미분류", lvg);
            foreach (var content in contents)
                if (!groups.ContainsKey(content.Item3 ?? "미분류"))
                {
                    ListViewGroup lvgt = new ListViewGroup(content.Item3 ?? "미분류");
                    groups.Add(content.Item3, lvgt);
                    lv.Groups.Add(lvgt);
                }
            lv.Groups.Add(lvg);
            for (int i = 0; i < contents.Count; i++)
            {
                int index = contents.Count - i - 1;
                lv.Items.Add(new ListViewItem(new string[] {
                    (i+1).ToString(),
                    contents[index].Item1,
                    contents[index].Item2.ToString()
                }, groups[contents[index].Item3 ?? "미분류"]));
            }
        }

        private void AddToList(ListView lv, List<Tuple<string, DateTime>> contents)
        {
            for (int i = 0; i < contents.Count; i++)
            {
                int index = contents.Count - i - 1;
                lv.Items.Add(new ListViewItem(new string[] {
                    (i+1).ToString(),
                    contents[index].Item1,
                    contents[index].Item2.ToString()
                }));
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                (new frmArtistInfo(this, listView1.SelectedItems[0].SubItems[1].Text.Replace('_', ' '))).Show();
            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                (new frmGroupInfo(this, listView2.SelectedItems[0].SubItems[1].Text.Replace('_', ' '))).Show();
            }
        }

        private void listView6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView6.SelectedItems.Count == 1)
            {
                foreach (var md in HitomiData.Instance.metadata_collection)
                    if (md.ID.ToString() == listView6.SelectedItems[0].SubItems[1].Text)
                    {
                        (new frmGalleryInfo(this, md)).Show();
                        break;
                    }
            }
        }

        private void listView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView3.SelectedItems.Count == 1)
            {
                (new frmFinder("tag:" + listView3.SelectedItems[0].SubItems[1].Text.Replace(' ', '_'))).Show();
            }
        }

        private void listView4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView4.SelectedItems.Count == 1)
            {
                (new frmFinder("series:" + listView4.SelectedItems[0].SubItems[1].Text.Replace(' ', '_'))).Show();
            }
        }

        private void listView5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView5.SelectedItems.Count == 1)
            {
                (new frmFinder("character:" + listView5.SelectedItems[0].SubItems[1].Text.Replace(' ', '_'))).Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BKPicker frm = new BKPicker(this,"작가", RequestAddArtist);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void RequestAddArtist(string artist)
        {
            if (HitomiBookmark.Instance.GetModel().Artists.Any(x => x.Item1 == artist))
            {
                MessageBox.Show($"이미 추가된 작가입니다!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HitomiBookmark.Instance.GetModel().Artists.Add(new Tuple<string, DateTime, string>(artist, DateTime.Now, ""));
            HitomiBookmark.Instance.Save();
            listView1.Items.Clear();
            AddToListGroups(listView1, HitomiBookmark.Instance.GetModel().Artists);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BKPicker frm = new BKPicker(this, "그룹", RequestAddGroup);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void RequestAddGroup(string group)
        {
            if (HitomiBookmark.Instance.GetModel().Groups.Any(x => x.Item1 == group))
            {
                MessageBox.Show($"이미 추가된 그룹입니다!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HitomiBookmark.Instance.GetModel().Groups.Add(new Tuple<string, DateTime>(group, DateTime.Now));
            HitomiBookmark.Instance.Save();
            listView2.Items.Clear();
            AddToList(listView2, HitomiBookmark.Instance.GetModel().Groups);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BKPicker frm = new BKPicker(this, "태그", RequestAddTag);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void RequestAddTag(string tag)
        {
            if (HitomiBookmark.Instance.GetModel().Tags.Any(x => x.Item1 == tag))
            {
                MessageBox.Show($"이미 추가된 태그입니다!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HitomiBookmark.Instance.GetModel().Tags.Add(new Tuple<string, DateTime>(tag, DateTime.Now));
            HitomiBookmark.Instance.Save();
            listView3.Items.Clear();
            AddToList(listView3, HitomiBookmark.Instance.GetModel().Tags);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BKPicker frm = new BKPicker(this, "시리즈", RequestAddSeries);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void RequestAddSeries(string series)
        {
            if (HitomiBookmark.Instance.GetModel().Series.Any(x => x.Item1 == series))
            {
                MessageBox.Show($"이미 추가된 시리즈입니다!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HitomiBookmark.Instance.GetModel().Series.Add(new Tuple<string, DateTime>(series, DateTime.Now));
            HitomiBookmark.Instance.Save();
            listView4.Items.Clear();
            AddToList(listView4, HitomiBookmark.Instance.GetModel().Series);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BKPicker frm = new BKPicker(this, "캐릭터", RequestAddCharacter);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        public void RequestAddCharacter(string character)
        {
            if (HitomiBookmark.Instance.GetModel().Characters.Any(x => x.Item1 == character))
            {
                MessageBox.Show($"이미 추가된 캐릭터입니다!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HitomiBookmark.Instance.GetModel().Characters.Add(new Tuple<string, DateTime>(character, DateTime.Now));
            HitomiBookmark.Instance.Save();
            listView5.Items.Clear();
            AddToList(listView5, HitomiBookmark.Instance.GetModel().Characters);
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

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            ListView lv = sender as ListView;
            if (e.KeyCode == Keys.F2)
            {
                if (lv.SelectedItems.Count == 1)
                {
                    (new Record(lv.SelectedItems[0].SubItems[1].Text.Replace('_', ' '))).Show();
                }

                return;
            }
            if (e.KeyCode != Keys.Delete) return;
            if (lv.SelectedItems.Count == 1)
            {
                if (MessageBox.Show($"'{lv.SelectedItems[0].SubItems[1].Text}'를 삭제할까요?", "Hitomi Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (lv == listView1)
                    {
                        int index = HitomiBookmark.Instance.GetModel().Artists.Count - Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text);
                        HitomiBookmark.Instance.GetModel().Artists.RemoveAt(index);
                    }
                    else if (lv == listView2)
                    {
                        int index = HitomiBookmark.Instance.GetModel().Groups.Count - Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text);
                        HitomiBookmark.Instance.GetModel().Groups.RemoveAt(index);
                    }
                    else if (lv == listView6)
                    {
                        int index = HitomiBookmark.Instance.GetModel().Articles.Count - Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text);
                        HitomiBookmark.Instance.GetModel().Articles.RemoveAt(index);
                    }
                    else if (lv == listView3)
                    {
                        int index = HitomiBookmark.Instance.GetModel().Tags.Count - Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text);
                        HitomiBookmark.Instance.GetModel().Tags.RemoveAt(index);
                    }
                    else if (lv == listView4)
                    {
                        int index = HitomiBookmark.Instance.GetModel().Series.Count - Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text);
                        HitomiBookmark.Instance.GetModel().Series.RemoveAt(index);
                    }
                    else if (lv == listView5)
                    {
                        int index = HitomiBookmark.Instance.GetModel().Characters.Count - Convert.ToInt32(lv.SelectedItems[0].SubItems[0].Text);
                        HitomiBookmark.Instance.GetModel().Characters.RemoveAt(index);
                    }
                    HitomiBookmark.Instance.Save();
                    lv.SelectedItems[0].Remove();
                }
            }
        }

        #region 작가 관련

        ListViewItem selected = null;
        private void GroupModify_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                int index = HitomiBookmark.Instance.GetModel().Artists.Count - Convert.ToInt32(selected.SubItems[0].Text);
                if ((sender as ToolStripMenuItem).Text != "새로 만들기...")
                {
                    selected.Group = groups[(sender as ToolStripMenuItem).Text];
                    HitomiBookmark.Instance.GetModel().Artists[index] = new Tuple<string, DateTime, string>(
                        HitomiBookmark.Instance.GetModel().Artists[index].Item1,
                        HitomiBookmark.Instance.GetModel().Artists[index].Item2,
                        (sender as ToolStripMenuItem).Text);
                    HitomiBookmark.Instance.Save();
                }
                else
                {
                    using (var cgd = new CreateGroup())
                    {
                        if (cgd.ShowDialog() == DialogResult.OK)
                        {
                            if (groups.ContainsKey(cgd.ReturnValue))
                            {
                                MessageBox.Show("이미 존재하는 그룹입니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                ListViewGroup lvgt = new ListViewGroup(cgd.ReturnValue);
                                groups.Add(cgd.ReturnValue, lvgt);
                                listView1.Groups.Add(lvgt);
                                selected.Group = groups[cgd.ReturnValue];
                                HitomiBookmark.Instance.GetModel().Artists[index] = new Tuple<string, DateTime, string>(
                                    HitomiBookmark.Instance.GetModel().Artists[index].Item1,
                                    HitomiBookmark.Instance.GetModel().Artists[index].Item2,
                                    cgd.ReturnValue);
                                HitomiBookmark.Instance.Save();
                            }
                        }
                    }
                }
                HitomiBookmark.Instance.Save();
            }
            selected = null;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Clear();

            if (listView1.SelectedItems.Count > 0)
            {
                selected = listView1.SelectedItems[0];
                (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.AddRange(groups.Select(x => new ToolStripMenuItem(x.Key, null, GroupModify_Click)).ToArray());
                (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Add(new ToolStripSeparator());
                (contextMenuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Add(new ToolStripMenuItem("새로 만들기...", null, GroupModify_Click));
            }
        }

        private void 삭제DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                if (MessageBox.Show($"'{listView1.SelectedItems[0].SubItems[1].Text}'를 삭제할까요?", "Hitomi Copy", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int index = HitomiBookmark.Instance.GetModel().Artists.Count - Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
                    HitomiBookmark.Instance.GetModel().Artists.RemoveAt(index);
                }
            }
        }
        
        #endregion

    }
}
