/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_2.EH;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmComment : Form
    {
        string url;
        public frmComment(string url)
        {
            InitializeComponent();

            this.url = url;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmComment_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Cookie, "igneous=fc251d23e;ipb_member_id=1904662;ipb_pass_hash=ff8940e2cc632d601091b8836fca66f5;");
            ExHentaiArticle article = ExHentaiParser.GetArticleData(wc.DownloadString(url));
            label1.Text = $"댓글 : {article.comment.Length} 개";

            article.comment.ToList().ForEach(x => richTextBox1.AppendText($"{x.Item2} - {x.Item1.ToString()}\r\n{x.Item3.Trim()}\r\n\r\n"));
        }
    }
}
