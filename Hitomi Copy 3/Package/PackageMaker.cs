/* Copyright (C) 2018. Hitomi Parser Developers */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Hitomi_Copy_3.Package
{
    public partial class PackageMaker : Form
    {
        public PackageMaker()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            var list = HitomiBookmark.Instance.GetModel().Artists;
            list.Sort((a, b) => (a.Item3 ?? "").CompareTo(b.Item3 ?? ""));
            foreach (var p in list)
            {
                if (string.IsNullOrEmpty(p.Item3))
                    builder.Append($"미분류|{p.Item1}\r\n");
                else
                    builder.Append($"{p.Item3}|{p.Item1}\r\n");
            }
            textBox5.Text = builder.ToString();

            builder.Clear();
            foreach (var p in HitomiBookmark.Instance.GetModel().Articles)
            {
                builder.Append(p.Item1 + "|\r\n");
            }
            textBox6.Text = builder.ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("패키지 이름을 반드시 입력해야합니다!", "패키지 메이커", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("닉네임을 반드시 입력해야합니다!", "패키지 메이커", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("패키지 사진 링크를 반드시 입력해야합니다.!", "패키지 메이커", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("패키지 정보를 반드시 입력해야합니다.!", "패키지 메이커", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PackageElementModel pem = new PackageElementModel();
            pem.LatestUpdate = DateTime.Now;
            pem.Name = textBox1.Text.Trim();
            pem.Nickname = textBox2.Text.Trim();
            pem.ImageLink = textBox3.Text.Trim();
            pem.Description = textBox4.Text.Trim();

            List<Tuple<string, string>> artists = new List<Tuple<string, string>>();
            foreach (var line in textBox5.Text.Trim().Split(new string[] { "\r\n" },
                           StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.Trim() == "") continue;
                artists.Add(new Tuple<string, string>(line.Trim().Split('|')[0], line.Trim().Split('|')[1]));
            }

            List<Tuple<string, string>> articles = new List<Tuple<string, string>>();
            foreach (var line in textBox6.Text.Trim().Split(new string[] { "\r\n" },
                           StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.Trim() == "") continue;
                articles.Add(new Tuple<string, string>(line.Trim().Split('|')[0], line.Trim().Split('|')[1]));
            }
            
            List<Tuple<string, string>> etcs = new List<Tuple<string, string>>();
            foreach (var line in textBox7.Text.Trim().Split(new string[] { "\r\n" },
                           StringSplitOptions.RemoveEmptyEntries))
            {
                if (line.Trim() == "") continue;
                etcs.Add(new Tuple<string, string>(line.Trim().Split('|')[0], line.Trim().Split('|')[1]));
            }
            pem.Artists = artists;
            pem.Articles = articles;
            pem.Etc = etcs;
            
            string json = JsonConvert.SerializeObject(pem, Formatting.Indented);
            using (var fs = new StreamWriter(new FileStream(pem.Name + ".json", FileMode.Create, FileAccess.Write)))
            {
                fs.Write(json);
            }

            MessageBox.Show("패키지 내보내기 완료됨!", "패키지 메이커", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
