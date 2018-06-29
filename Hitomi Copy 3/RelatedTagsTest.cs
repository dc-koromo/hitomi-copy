/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_3.Analysis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class RelatedTagsTest : Form
    {
        public RelatedTagsTest()
        {
            InitializeComponent();
        }

        private void RelatedTagsTest_Load(object sender, EventArgs e)
        {
            ColumnSorter.InitListView(listView1);
        }

        int max;
        
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            double var;
            if (!double.TryParse(textBox1.Text, out var))
            {
                MessageBox.Show("ㅗ");
                return;
            }
            if (var <= 0.00001)
            {
                MessageBox.Show("0.00001 보단 높아야 합니다.");
                return;
            }
            if (var > 1.0)
            {
                MessageBox.Show("1.0 보단 낮아야 합니다.");
                return;
            }
            textBox1.Enabled = false;
            checkBox1.Enabled = false;
            listBox1.Items.Clear();
            listView1.Items.Clear();

            //
            //  계산 시작
            //

            HitomiAnalysisRelatedTags.Instance.Initialize();
            HitomiAnalysisRelatedTags.Instance.Threshold = var;
            max = progressBar1.Maximum = HitomiAnalysisRelatedTags.Instance.tags_list.Count;

            await Task.WhenAll(Enumerable.Range(0, Environment.ProcessorCount).Select(no => Task.Run(() => process(no))));
            LogEssential.Instance.PushLog(() => $"Merge...");
            await Task.Run(() => HitomiAnalysisRelatedTags.Instance.Merge());
            LogEssential.Instance.PushLog(() => $"Complete!");

            //
            //  정렬을 위한 계산
            //

            var tag_count = HitomiAnalysisRelatedTags.Instance.tags_list.ToList();
            tag_count.Sort((a, b) => b.Value.Count.CompareTo(a.Value.Count));
            for (int i = tag_count.Count-1; i >=0; i--)
                if (!HitomiAnalysisRelatedTags.Instance.result.ContainsKey(tag_count[i].Key))
                    tag_count.RemoveAt(i);

            //
            //  결과 표시
            //
            listBox1.SuspendLayout();
            foreach (var tag in tag_count)
                listBox1.Items.Add($"{Regex.Replace(tag.Key, " ", "_")} ({tag.Value.Count})");
            listBox1.ResumeLayout();

            textBox1.Enabled = true;
            checkBox1.Enabled = true;
        }
        
        private void process(int i)
        {
            int min = this.max / 12 * i;
            int max = this.max / 12 * (i+1);
            if (max > this.max)
                max = this.max;

            LogEssential.Instance.PushLog(() => $"{min}/{max} process start!");
            List<Tuple<string, string, double>> result = new List<Tuple<string, string, double>>();

            for (int j = max - 1; j >= min; j--)
            {
                result.AddRange(HitomiAnalysisRelatedTags.Instance.Intersect(j));
                this.Post(() => progressBar1.Value++);
            }

            HitomiAnalysisRelatedTags.Instance.results.AddRange(result);
            LogEssential.Instance.PushLog(() => $"{min}/{max} process finish!");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            HitomiAnalysisRelatedTags.Instance.IncludeFemaleMaleOnly = checkBox1.Checked;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listView1.Items.Clear();
                string tag = Regex.Replace(listBox1.GetItemText(listBox1.SelectedItem).Split(' ')[0], "_", " ");

                listView1.SuspendLayout();
                int i = 1;
                foreach (var v in HitomiAnalysisRelatedTags.Instance.result[tag])
                {
                    listView1.Items.Add(new ListViewItem(new string[] { i++.ToString(), tag, v.Item1, v.Item2.ToString() }));
                }
                listView1.ResumeLayout();
            }
        }
    }
}
