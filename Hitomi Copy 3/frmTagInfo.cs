/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hitomi_Copy
{
    public partial class frmTagInfo : Form
    {
        string tag, tag2 = "";
        Form closed_form;

        public frmTagInfo(Form closed, string tag, string tag2 = "")
        {
            InitializeComponent();

            this.tag = tag;
            this.tag2 = tag2;
            closed_form = closed;
            Text += tag;
            if (tag2 != "") Text += $" {tag2}";
        }
        
        private void frmTagInfo_Load(object sender, EventArgs e)
        {
            ColumnInit();

            List<HitomiMetadata> result = new List<HitomiMetadata>();
            var hitomi_data = HitomiData.Instance.metadata_collection;
            foreach (var data in hitomi_data)
            {
                if (data.Tags != null && data.Tags.Contains(tag))
                {
                    if (tag2 != "" && !data.Tags.Contains(tag2)) continue;
                    result.Add(data);
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
            lvil.Sort((a, b) => Convert.ToUInt32(b.SubItems[0].Text).CompareTo(Convert.ToUInt32(a.SubItems[0].Text)));
            lvHistory.Items.AddRange(lvil.ToArray());
        }

        private void ColumnInit()
        {
            ColumnSorter.InitListView(lvHistory);
        }

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

        private void frmTagInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { closed_form.BringToFront(); } catch { }
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
