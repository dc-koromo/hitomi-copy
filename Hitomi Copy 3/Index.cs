/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(listView1);
            ColumnSorter.InitListView(listView2);

            List<HitomiTagdata> tags = new List<HitomiTagdata>();
            tags.AddRange(HitomiData.Instance.tagdata_collection.female);
            tags.AddRange(HitomiData.Instance.tagdata_collection.male);
            tags.AddRange(HitomiData.Instance.tagdata_collection.tag);

            List<Tuple<string, string, int>> tag_e2k = new List<Tuple<string, string, int>>();
            foreach (var tag in tags)
            {
                string k_try = KoreanTag.TagMap(tag.Tag);
                if (k_try != tag.Tag)
                {
                    if (k_try.Contains(":"))
                        tag_e2k.Add(new Tuple<string, string, int>(tag.Tag, k_try.Split(':')[1], tag.Count));
                    else
                        tag_e2k.Add(new Tuple<string, string, int>(tag.Tag, k_try, tag.Count));
                }
            }
            tag_e2k.Sort((a, b) => b.Item3.CompareTo(a.Item3));

            List<ListViewItem> lvi = new List<ListViewItem>();
            for (int i = 0; i < tag_e2k.Count; i++)
            {
                lvi.Add(new ListViewItem(new string[] { (i + 1).ToString(), tag_e2k[i].Item1, tag_e2k[i].Item2, tag_e2k[i].Item3.ToString("#,#") }));
            }
            listView1.Items.AddRange(lvi.ToArray());

            List<Tuple<string, string, int>> series_e2k = new List<Tuple<string, string, int>>();
            foreach (var tag in HitomiData.Instance.tagdata_collection.series)
            {
                string k_try = KoreanSeries.SeriesMap(tag.Tag);
                if (k_try != tag.Tag)
                {
                    series_e2k.Add(new Tuple<string, string, int>(tag.Tag, k_try, tag.Count));
                }
            }
            series_e2k.Sort((a, b) => b.Item3.CompareTo(a.Item3));

            List<ListViewItem> lvi2 = new List<ListViewItem>();
            for (int i = 0; i < series_e2k.Count; i++)
            {
                lvi2.Add(new ListViewItem(new string[] { (i + 1).ToString(), series_e2k[i].Item1, series_e2k[i].Item2, series_e2k[i].Item3.ToString("#,#") }));
            }
            listView2.Items.AddRange(lvi2.ToArray());
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                (new frmFinder("tag:" + listView1.SelectedItems[0].SubItems[1].Text.Replace(' ', '_'))).Show();
            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                (new frmFinder("series:" + listView2.SelectedItems[0].SubItems[1].Text.Replace(' ', '_'))).Show();
            }
        }
    }
}
