/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_3.MM;
using MM_Downloader.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmMarumaru : Form
    {
        public frmMarumaru()
        {
            InitializeComponent();
        }

        private void frmMarumaru_Load(object sender, System.EventArgs e)
        {
            Task.Run(() => process());
        }

        private List<string> DownloadArticle(string url)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36");

            string html = wc.DownloadString(url);
            return MMParser.ParseManga(html);
        }

        private bool IsNeedUpdate(MMArticleDataModel mmadm)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36");

            string html = wc.DownloadString(mmadm.ArticleUrl);
            var archives = MMParser.ParseManga(html);

            if (mmadm.DownloadUrlList.Length < archives.Count)
                return true;

            return false;
        }

        List<Tuple<string, List<string>>> reserve = new List<Tuple<string, List<string>>>();
        private void process()
        {
            foreach (var model in MMSetting.Instance.GetModel().Articles)
            {
                var list = DownloadArticle(model.ArticleUrl);
                if (model.DownloadUrlList.Length < list.Count)
                {
                    this.Post(() => checkedListBox1.Items.Add(model.Title, true));
                    reserve.Add(new Tuple<string, List<string>>(model.ArticleUrl, model.DownloadUrlList.Select(x => x.Item1).ToList()));
                }
            }
            this.Post(() => label2.Text = "확인완료");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    int k = i;
                    (Application.OpenForms[0] as frmMain).Post(() => Task.Run(() => (Application.OpenForms[0] as frmMain).DownloadMMAsync(reserve[k].Item1, reserve[k].Item2)));
                }
            }
            Close();
        }
    }
}
