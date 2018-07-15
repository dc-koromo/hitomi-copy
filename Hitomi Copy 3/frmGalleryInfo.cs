/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using Hitomi_Copy_3;
using Hitomi_Copy_3.EH;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy
{
    public partial class frmGalleryInfo : Form
    {
        IPicElement pic;
        HitomiMetadata metadata;
        string id;
        Form closed_form;
        RightClickCloser CloseOnRBtn;

        public frmGalleryInfo(Form closed, IPicElement pic)
        {
            InitializeComponent();

            this.pic = pic;
            closed_form = closed;
            id = pic.Article.Magic;
            CloseOnRBtn = new RightClickCloser(this);
        }

        public frmGalleryInfo(Form closed, HitomiMetadata metadata)
        {
            InitializeComponent();

            this.metadata = metadata;
            closed_form = closed;
            id = metadata.ID.ToString();
            CloseOnRBtn = new RightClickCloser(this);
        }

        private void frmGalleryInfo_LoadAsync(object sender, EventArgs e)
        {
            lDate.Text = HitomiDate.estimate_datetime(Convert.ToInt32(id)).ToString();
            if (pic != null)
            {
                pbImage.Image = pic.Image;
                lTitle.Text = pic.Article.Title;
                lArtist.Text = string.Join(",", pic.Article.Artists ?? Enumerable.Empty<string>());
                lSeries.Text = string.Join(",", pic.Article.Series ?? Enumerable.Empty<string>());
                lGroup.Text = string.Join(",", pic.Article.Groups ?? Enumerable.Empty<string>());
                lCharacter.Text = string.Join(",", pic.Article.Characters ?? Enumerable.Empty<string>());
                textBox1.Text = string.Join(",", pic.Article.Tags ?? Enumerable.Empty<string>());

                if (pic.Article.Tags != null)
                    pic.Article.Tags.ToList().ForEach((a) =>
                    {
                        a = HitomiCommon.LegalizeTag(a);
                        if (a.StartsWith("female:")) AddTagToPanel(a.Substring("female:".Length), 1);
                        else if (a.StartsWith("male:")) AddTagToPanel(a.Substring("male:".Length), 2);
                        else AddTagToPanel(a, 0);
                    });
            }
            else
            {
                lTitle.Text = metadata.Name;
                lArtist.Text = string.Join(",", metadata.Artists ?? Enumerable.Empty<string>());
                lSeries.Text = string.Join(",", metadata.Parodies ?? Enumerable.Empty<string>());
                lGroup.Text = string.Join(",", metadata.Groups ?? Enumerable.Empty<string>());
                lCharacter.Text = string.Join(",", metadata.Characters ?? Enumerable.Empty<string>());
                
                if (metadata.Tags != null)
                    metadata.Tags.ToList().ForEach((a) =>
                    {
                        if (a.StartsWith("female:")) AddTagToPanel(a.Substring("female:".Length), 1);
                        else if (a.StartsWith("male:")) AddTagToPanel(a.Substring("male:".Length), 2);
                        else AddTagToPanel(a, 0);
                    });

                Task.Run(() => download_image());
            }
        }
        
        private void AddTagToPanel(string tag_data, int image)
        {
            Button b = new Button();
            b.Text = tag_data;
            b.UseVisualStyleBackColor = true;
            b.AutoSize = false;
            b.Font = new Font(Font.Name, 10);
            using (Graphics cg = this.CreateGraphics())
            {
                b.Width = (int)cg.MeasureString(tag_data, b.Font).Width + 13;
            }
            b.Height = 26;
            b.Padding = new Padding(0);
            b.Margin = new Padding(0);
            b.MouseClick += ButtonMessage;
            
            if (image == 1)
                b.ForeColor = Color.DeepPink;
            else if (image == 2)
                b.ForeColor = Color.Blue;
            
            flowLayoutPanel1.Controls.Add(b);
        }

        public void ButtonMessage(object sender, EventArgs e)
        {
            if (HitomiSetting.Instance.GetModel().OpenWithFinder)
            {
                if (((Button)sender).ForeColor == Color.DeepPink)
                    (new frmFinder("tag:female:" + ((Button)sender).Text.Replace(' ', '_'))).Show();
                else if (((Button)sender).ForeColor == Color.Blue)
                    (new frmFinder("tag:male:" + ((Button)sender).Text.Replace(' ', '_'))).Show();
                else
                    (new frmFinder("tag:" + ((Button)sender).Text.Replace(' ', '_'))).Show();
            }
            else
            {
                if (((Button)sender).ForeColor == Color.DeepPink)
                    (new frmTagInfo(this, "female:" + ((Button)sender).Text)).Show();
                else if (((Button)sender).ForeColor == Color.Blue)
                    (new frmTagInfo(this, "male:" + ((Button)sender).Text)).Show();
                else
                    (new frmTagInfo(this, ((Button)sender).Text)).Show();
            }
        }

        private void download_image()
        {
            string localFilename = Path.GetTempFileName();
            using (WebClient client = new WebClient())
            {
                string url;
                if (HitomiData.Instance.thumbnail_collection.ContainsKey(id))
                    url = HitomiDef.HitomiThumbnail + HitomiData.Instance.thumbnail_collection[id];
                else
                    url = HitomiDef.HitomiThumbnail + HitomiParser.ParseGallery(client.DownloadString(new Uri(HitomiDef.HitomiAddress + "galleries/" + metadata.ID + ".html"))).Thumbnail;
                client.DownloadFile(url, localFilename);
                load_image(localFilename);
                LogEssential.Instance.PushLog(() => $"Download image successful! {url} {localFilename}");
            }
        }
        private void load_image(string path)
        {
            try
            {
                if (pbImage.InvokeRequired)
                {
                    Invoke(new Action<string>(load_image), new object[] { path });
                    return;
                }
                pbImage.Image = Image.FromFile(path);
            } catch { }
        }

        private void frmGalleryInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmGalleryInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { closed_form.BringToFront(); } catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pic != null)
                    (new frmArtistInfo(this, pic.Article.Artists[0])).Show();
                else if (metadata.Artists != null)
                    (new frmArtistInfo(this, metadata.Artists[0])).Show();
            } catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (HitomiSetting.Instance.GetModel().OpenWithFinder)
                {
                    if (pic != null)
                        (new frmFinder("series:" + pic.Article.Series[0].Replace(' ', '_'))).Show();
                    else
                        (new frmFinder("series:" + metadata.Parodies[0].Replace(' ', '_'))).Show();
                }
                else
                {
                    if (pic != null)
                        (new frmSeriesInfo(this, pic.Article.Series[0])).Show();
                    else
                        (new frmSeriesInfo(this, metadata.Parodies[0])).Show();
                }
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            (Application.OpenForms[0] as frmMain).RemoteDownloadArticleFromId(id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (pic != null)
                    System.Diagnostics.Process.Start($"https://hitomi.la/galleries/{pic.Article.Magic}.html");
                else
                    System.Diagnostics.Process.Start($"https://hitomi.la/galleries/{metadata.ID}.html");
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (pic != null)
                    (new frmGroupInfo(this, pic.Article.Groups[0])).Show();
                else
                    (new frmGroupInfo(this, metadata.Groups[0])).Show();
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (HitomiSetting.Instance.GetModel().OpenWithFinder)
                {
                    if (pic != null)
                        (new frmFinder("character:" + pic.Article.Characters[0].Replace(' ', '_'))).Show();
                    else
                        (new frmFinder("character:" + metadata.Characters[0].Replace(' ', '_'))).Show();
                }
                else
                {
                    if (pic != null)
                        (new frmCharacterInfo(this, pic.Article.Characters[0])).Show();
                    else
                        (new frmCharacterInfo(this, metadata.Characters[0])).Show();
                }
            }
            catch { }
        }

        private void bPreview_Click(object sender, EventArgs e)
        {
            if (pic != null)
                (new frmPreview(this, pic.Article.Magic)).Show();
            else
                (new frmPreview(this, metadata.ID.ToString())).Show();
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

        private void Label_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((sender as Label).Text);
            LogEssential.Instance.PushLog(() => $"Copy to clipboard \"{(sender as Label).Text}\"");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string result="";
            if (pic != null)
                result = ExHentaiTool.GetAddressFromMagicTitle(pic.Article.Magic, pic.Article.OriginalTitle);
            else
                result = ExHentaiTool.GetAddressFromMagicTitle(metadata.ID.ToString(), metadata.Name);
            if (result != "")
                System.Diagnostics.Process.Start(result);
            else
                MessageBox.Show("익헨 주소를 찾지 못했습니다.", "Hitomi Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string result = "";
            if (pic != null)
                result = ExHentaiTool.GetAddressFromMagicTitle(pic.Article.Magic, pic.Article.OriginalTitle);
            else
                result = ExHentaiTool.GetAddressFromMagicTitle(metadata.ID.ToString(), metadata.Name);
            if (result != "")
                (new frmComment(this, result)).Show();
            else
                MessageBox.Show("익헨 주소를 찾지 못했습니다.", "Hitomi Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
