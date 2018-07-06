/* Copyright (C) 2018. Hitomi Parser Developers */

using MM_Downloader.MM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Hitomi_Copy_3.MM
{
    public class MMUpdate
    {
        private static readonly Lazy<MMUpdate> instance = new Lazy<MMUpdate>(() => new MMUpdate());
        public static MMUpdate Instance => instance.Value;

        private List<string> DownloadArticle(string url)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Accept, "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            wc.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36");

            string html = wc.DownloadString(url);
            return MMParser.ParseManga(html);
        }

        public List<Tuple<string, List<string>, string>> reserve = new List<Tuple<string, List<string>, string>>();

        public void UpdateCheck()
        {
            LogEssential.Instance.PushLog(() => "[MM Update] Check update...");
            foreach (var model in MMSetting.Instance.GetModel().Articles)
            {
                var list = DownloadArticle(model.ArticleUrl);
                if (model.DownloadUrlList.Length + (model.NotFound?.Length ?? 0) < list.Count)
                {
                    reserve.Add(new Tuple<string, List<string>, string>(model.ArticleUrl, model.DownloadUrlList.Select(x => x.Item1).ToList(), model.Title));
                }
            }

            if (reserve.Count > 0)
            {
                LogEssential.Instance.PushLog(() => $"[MM Update] Found {reserve.Count} update list.");
                Application.OpenForms[0].Post(() => (new frmMarumaru()).Show());
            }
            else
            {
                LogEssential.Instance.PushLog(() => "[MM Update] Don't need update.");
            }
        }
    }
}
