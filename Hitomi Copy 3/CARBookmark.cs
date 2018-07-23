/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using System;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class CARBookmark : Form
    {
        CustomArtistRecommendation parent;

        public CARBookmark(CustomArtistRecommendation parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void CARBookmark_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(listView1);

            for (int i = 0; i < HitomiBookmark.Instance.GetModel().CustomTags.Count; i++)
            {
                int index = HitomiBookmark.Instance.GetModel().CustomTags.Count - i - 1;
                listView1.Items.Add(new ListViewItem( new string[] {
                    (i+1).ToString(),
                    HitomiBookmark.Instance.GetModel().CustomTags[index].Item1,
                    HitomiBookmark.Instance.GetModel().CustomTags[index].Item3.ToString(),
                    string.Join(", ", HitomiBookmark.Instance.GetModel().CustomTags[index].Item2),
                }));
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                parent.RequestLoadCustomTags(listView1.SelectedItems[0].SubItems[0].Text);
                Close();
            }
        }
    }
}
