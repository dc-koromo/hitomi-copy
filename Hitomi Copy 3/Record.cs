/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
        }

        private void Record_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(listView1);
            List<ListViewItem> lvil = new List<ListViewItem>();
            for (int i = HitomiLog.Instance.GetList().Count()-1; i >= 0; i--)
            {
                var list = HitomiLog.Instance.GetList()[i];
                lvil.Add(new ListViewItem(new string[]
                {
                    list.Id,
                    list.Title,
                    string.Join(",", list.Artists ?? Enumerable.Empty<string>()),
                    list.Time.ToString(),
                    string.Join(",", list.Tags ?? Enumerable.Empty<string>())
                }));
            }
            listView1.Items.AddRange(lvil.ToArray());
            Text = $"{lvil.Count.ToString("#,#")}개의 기록";
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var hitomi_data = HitomiData.Instance.metadata_collection;
                foreach (var metadata in hitomi_data)
                {
                    if (metadata.ID.ToString() == listView1.SelectedItems[0].SubItems[0].Text)
                    {
                        (new frmGalleryInfo(this, metadata)).Show();
                        return;
                    }
                }
            }
        }
    }
}
