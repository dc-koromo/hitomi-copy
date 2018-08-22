/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_2.EH;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmComment : Form
    {
        string url;
        Form closed_form;

        public frmComment(Form closed_form, string url)
        {
            InitializeComponent();

            this.url = url;
            this.closed_form = closed_form;
        }


        private void frmComment_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { closed_form.BringToFront(); } catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmComment_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add(HttpRequestHeader.Cookie, "igneous=30e0c0a66;ipb_member_id=2742770;ipb_pass_hash=6042be35e994fed920ee7dd11180b65f;");
            ExHentaiArticle article = ExHentaiParser.GetArticleData(wc.DownloadString(url));
            label1.Text = $"댓글 : {article.comment.Length} 개";

            int ccc = 0;
            article.comment.ToList().ForEach(x => {
                richTextBox1.AppendText($"{x.Item2} - {x.Item1.ToString()}\r\n{x.Item3.Trim()}\r\n\r\n");
                richTextBox1.Select(ccc, x.Item2.Length);
                richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 11.0F, FontStyle.Bold);
                richTextBox1.Select(ccc + x.Item2.Length + 3, x.Item1.ToString().Length);
                richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, 11.0F);
                ccc = richTextBox1.Text.Length;
            });
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
