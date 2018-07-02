/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3._403
{
    public partial class _403Tester : Form
    {
        public _403Tester()
        {
            InitializeComponent();
        }

        List<int> magics = new List<int>();
        HashSet<int> magic_set = new HashSet<int>();
        List<HitomiArticle> new_article = new List<HitomiArticle>();
        int status = 0;
        private void _403Tester_Load(object sender, System.EventArgs e)
        {
            foreach (var metadata in HitomiData.Instance.metadata_collection)
            {
                magics.Add(metadata.ID);
                magic_set.Add(metadata.ID);
            }
            label2.Text = magics.Count + " 개";
            magics.Sort((a, b) => b.CompareTo(a));
            progressBar1.Maximum = magics.Count;
        }

        DateTime start;
        private void button1_ClickAsync(object sender, System.EventArgs e)
        {
            //await Task.WhenAll(Enumerable.Range(0, 30).Select(no => Task.Run(() => process(no))));
            start = DateTime.Now;
            for (int i = 0; i < 30; i++)
            {
                Notify();
            }
        }

        private void process(int i)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                string x;
                x = wc.DownloadString("https://hitomi.la/galleries/" + magics[i] + ".html");
                var list = HitomiParser.ParseArticles(x);
                foreach (var data in list)
                {
                    if (!magic_set.Contains(Convert.ToInt32(data.Magic)))
                    {
                        magic_set.Add(Convert.ToInt32(data.Magic));
                        new_article.Add(data);
                        LogEssential.Instance.PushLog(() => $"New! {data.Magic}");
                    }
                }
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"{i} error {ex.Message}");
            }

            this.Post(() => progressBar1.Value++);
            this.Post(() => label3.Text = $"{progressBar1.Value}/{magics.Count} 분석완료");
            this.Post(() => label5.Text = $"{(new DateTime((DateTime.Now - start).Ticks * magics.Count / progressBar1.Value)).ToString("HH시간 mm분 ss초")}");
            
            lock (int_lock) mtx--;
            lock (notify_lock) Notify();
        }

        private void Notify()
        {
            lock (int_lock)
            {
                if (status < magics.Count) { Task.Run(() => process(status)); status++; mtx++; }
                if (status >= magics.Count && mtx == 0)
                    lock (new_article) File.WriteAllText("403.json", LogEssential.SerializeObject(new_article));
            }
        }

        int mtx = 0;

        object int_lock = new object();
        object notify_lock = new object();
        
    }
}
