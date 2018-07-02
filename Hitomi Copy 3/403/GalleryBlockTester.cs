﻿/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3._403
{
    public partial class GalleryBlockTester : Form
    {
        public GalleryBlockTester()
        {
            InitializeComponent();
        }

        public void PushString(string str)
        {
            if (textBox3.InvokeRequired)
            {
                Invoke(new Action<string>(PushString), new object[] { str }); return;
            }
            textBox3.SuspendLayout();
            textBox3.AppendText(str + "\r\n");
            textBox3.ResumeLayout();
        }
        
        int status = 0;
        int maximum = 0;
        int minimum = 0;
        HashSet<int> exists = new HashSet<int>();
        List<HitomiArticle> result = new List<HitomiArticle>();
        private void GalleryBlockTester_Load(object sender, EventArgs e)
        {
            foreach (var metadata in HitomiData.Instance.metadata_collection)
            {
                exists.Add(metadata.ID);
            }
            textBox1.BackColor = Color.White;
        }

        DateTime start;
        private void button1_Click(object sender, EventArgs e)
        {
            status = minimum = Convert.ToInt32(textBox1.Text);
            progressBar1.Maximum = maximum = Convert.ToInt32(textBox2.Text);
            start = DateTime.Now;
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            for (int i = 0; i < 100; i++)
            {
                lock (notify_lock) Notify();
            }
        }
        
        private void process(int i)
        {
            try
            {
                if (exists.Contains(i)) goto FINISH;
                WebClient wc = new WebClient();
                wc.Encoding = Encoding.UTF8;
                string x;
                x = wc.DownloadString("https://hitomi.la/galleryblock/" + i + ".html");
                result.Add(HitomiParser.ParseArticles(x)[0]);
                PushString($"New! {i}");
            }
            catch (Exception ex)
            {
            }

        FINISH:
            
            this.Post(() => progressBar1.Value++);
            this.Post(() => label3.Text = $"{progressBar1.Value}/{maximum - minimum + 1} 분석완료");
            this.Post(() => label5.Text = $"{(new DateTime((DateTime.Now - start).Ticks * (maximum - minimum + 1 - progressBar1.Value) / progressBar1.Value)).ToString("HH시간 mm분 ss초")}");

            lock (int_lock) mtx--;
            lock (notify_lock) Notify();
        }

        private void Notify()
        {
            lock (int_lock)
            {
                if (status < maximum) { Task.Run(() => process(status)); status++; mtx++; }
                if (status >= maximum && mtx == 0)
                    lock (result) File.WriteAllText("gallery_block.json", LogEssential.SerializeObject(result));
            }
        }

        int mtx = 0;

        object int_lock = new object();
        object notify_lock = new object();

        private void timer1_Tick(object sender, EventArgs e)
        {
            lock (result) File.WriteAllText($"snapshot_{DateTime.Now.Ticks.ToString()}.json", LogEssential.SerializeObject(result));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lock (result) File.WriteAllText("gallery_block.json", LogEssential.SerializeObject(result));
            PushString("완료됨!");
        }
    }
}
