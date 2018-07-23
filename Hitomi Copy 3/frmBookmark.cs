/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmBookmark : Form
    {
        public frmBookmark()
        {
            InitializeComponent();
        }

        private void frmBookmark_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(listView1);
            ColumnSorter.InitListView(listView2);
            ColumnSorter.InitListView(listView6);
            ColumnSorter.InitListView(listView3);
            ColumnSorter.InitListView(listView4);
            ColumnSorter.InitListView(listView5);
            
            AddToList(listView1, HitomiBookmark.Instance.GetModel().Artists);
            AddToList(listView2, HitomiBookmark.Instance.GetModel().Groups);
            AddToList(listView6, HitomiBookmark.Instance.GetModel().Articles);
            AddToList(listView3, HitomiBookmark.Instance.GetModel().Tags);
            AddToList(listView4, HitomiBookmark.Instance.GetModel().Series);
            AddToList(listView5, HitomiBookmark.Instance.GetModel().Characters);
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
                (new frmArtistInfo(this, listView1.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                (new frmGroupInfo(this, listView2.SelectedItems[0].SubItems[1].Text)).Show();
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
            if (listView2.SelectedItems.Count == 1)
            {
                (new frmFinder("tag:" + listView4.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void listView4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView4.SelectedItems.Count == 1)
            {
                (new frmFinder("series:" + listView3.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }

        private void listView5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView5.SelectedItems.Count == 1)
            {
                (new frmFinder("character:" + listView5.SelectedItems[0].SubItems[1].Text)).Show();
            }
        }
    }
}
