/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_3.Analysis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        int max;
        
        private void button1_ClickAsync(object sender, EventArgs e)
        {
            double a;
            if (!double.TryParse(textBox1.Text, out a))
            {
                MessageBox.Show("ㅗ");
                return;
            }
            if (a <= 0.00001)
            {
                MessageBox.Show("0.00001 보단 높아야 합니다.");
                return;
            }
            max = progressBar1.Maximum = HitomiAnalysisRelatedTags.Instance.tags_list.Count;
            Task.Run(() => Start());
        }

        private async void Start()
        {
            await Task.WhenAll(Enumerable.Range(0, 12).Select(no => Task.Run(() => process(no))));
            LogEssential.Instance.PushLog(() => $"Merge...");
            HitomiAnalysisRelatedTags.Instance.Merge();
            LogEssential.Instance.PushLog(() => $"Complete!");
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
    }
}
