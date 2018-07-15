/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy;
using Hitomi_Copy_2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class frmPreview : Form
    {
        Form closed_form;
        string id;
        RightClickCloser CloseOnRBtn;

        public frmPreview(Form closed, string id)
        {
            InitializeComponent();

            this.closed_form = closed;
            this.id = id;
            CloseOnRBtn = new RightClickCloser(this);
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            PicElement pe = new PicElement(this);
            pe.Article = new HitomiArticle();
            pe.Article.Magic = id;
            Task.Run(() => HitomiCore.DownloadAndSetImageLink(pe, ImageLinkCallback));
        }

        HitomiQueue download_queue;
        private void ImageLinkCallback(IPicElement pe)
        {
            download_queue = new HitomiQueue(Notify, Notify_Size, Notify_Status, Notify_Retry);
            int max = pe.Article.ImagesLink.Count;
            if (HitomiSetting.Instance.GetModel().LoadPreviewMaximum < max)
                max = HitomiSetting.Instance.GetModel().LoadPreviewMaximum;
            PBMaxSize(max);
            for (int i = 0; i < max; i++)
            {
                string temp = Path.GetTempFileName();
                download_queue.Add(HitomiDef.GetDownloadImageAddress(pe.Article.Magic, pe.Article.ImagesLink[i]), temp, i);
            }
        }

        private void PBMaxSize(int count)
        {
            if (pbLoad.InvokeRequired)
            {
                Invoke(new Action<int>(PBMaxSize), new object[] { count });
                return;
            }
            pbLoad.Maximum = count;
        }

        private void PBIncrease()
        {
            if (pbLoad.InvokeRequired)
            {
                try { Invoke(new Action(PBIncrease)); } catch { }
                return;
            }
            pbLoad.Value++;
            if (pbLoad.Value == pbLoad.Maximum)
                pbLoad.Visible = false;
        }

        private void Notify(string uri, string filename, object obj)
        {
            PicElement pe = new PicElement(this);
            pe.Article = new HitomiArticle();
            pe.Article.Magic = ((int)obj).ToString();
            pe.Dock = DockStyle.Bottom;
            pe.SetImageFromAddress(filename, 300, 400, false);

            pe.Font = this.Font;

            AddPanel(pe);
            PBIncrease();
            Application.DoEvents();
        }

        private void Notify_Size(string uri, long size) { }
        private void Notify_Status(string uri, int size) { }
        private void Notify_Retry(string uri) { }
        
        private void AddPanel(PicElement pe)
        {
            try
            {
                if (ImagePanel.InvokeRequired)
                {
                    Invoke(new Action<PicElement>(AddPanel), new object[] { pe }); return;
                }
                ImagePanel.Controls.Add(pe);
                SortThumbnail();
            } catch
            {

            }
        }
        private void SortThumbnail()
        {
            List<Control> controls = new List<Control>();
            for (int i = 0; i < ImagePanel.Controls.Count; i++)
                controls.Add(ImagePanel.Controls[i]);
            controls.Sort((a, b) => Convert.ToUInt32((a as PicElement).Article.Magic).CompareTo(Convert.ToUInt32((b as PicElement).Article.Magic)));
            for (int i = 0; i < controls.Count; i++)
                ImagePanel.Controls.SetChildIndex(controls[i], i);
        }

        private void frmPreview_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { closed_form.BringToFront(); } catch { }

            download_queue.Abort();

            for (int i = ImagePanel.Controls.Count - 1; i >= 0; i--)
                if (ImagePanel.Controls[i] != null)
                    ImagePanel.Controls[i].Dispose();
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
    }
}
