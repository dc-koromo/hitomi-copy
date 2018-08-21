/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy;
using Hitomi_Copy.Data;
using Hitomi_Copy_2;
using Hitomi_Copy_3.EH;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class PicDetailElement : UserControl, IPicElement
    {
        Image image;
        bool selected = false;
        string label = "";
        Font font;
        bool mouse_enter = false;
        bool downloading = false;
        bool downloaded = false;
        bool overlap = false;
        bool downloaded_overlapping = false;
        bool hidden_data = false;
        bool bookmark = false;
        HitomiArticle ha;
        Lazy<InfoForm> info;
        Form parent;
        VUI.VUIPictureBox vuiPB;
        List<VUI.VUILabel> vuiLabels = new List<VUI.VUILabel>();
        List<VUI.VUIButton> vuiButtons = new List<VUI.VUIButton>();

        public PicDetailElement(Form parent, ToolTip tooltip = null)
        {
            InitializeComponent();

            this.BackColor = Color.GhostWhite;
            this.parent = parent;
            this.DoubleBuffered = true;

            Disposed += OnDispose;

            //
            //  PictureBox to VUI
            //
            vuiPB = new VUI.VUIPictureBox();
            vuiPB.Size = new Size(150, 200);
            vuiPB.Location = pb.Location;
            vuiPB.MouseEnterEvent = () => { if (info != null) { info.Value.Location = Cursor.Position; info.Value.Show(); } };
            vuiPB.MouseLeaveEvent = () => { if (info != null) { info.Value.Location = Cursor.Position; info.Value.Hide(); } };
            vuiPB.MouseMoveEvent = () => {
                if (info != null)
                {
                    int sw = SystemInformation.VirtualScreen.Width;
                    int sh = SystemInformation.VirtualScreen.Height;
                    int cx = Cursor.Position.X + 15;
                    int cy = Cursor.Position.Y;
                    if (sw < cx - 15 + info.Value.Width)
                        cx = Cursor.Position.X - 15 - info.Value.Width;
                    if (sh < info.Value.Height + cy)
                        cy = sh - info.Value.Height;
                    info.Value.Location = new Point(cx, cy);
                }
            };
            pb.Dispose();

            //
            // Button to VUI
            //
            //for (int i = 0; i < Controls.Count; i++)
            //{
            //    if (Controls[i] is Button)
            //    {
            //        using (Button bbb = Controls[i] as Button)
            //        {
            //            VUI.VUIButton button = new VUI.VUIButton();
            //            button.Location = (Controls[i] as Button).Location;
            //            button.Size = (Controls[i] as Button).Size;
            //            button.Font = (Controls[i] as Button).Font;
            //            button.Text = (Controls[i] as Button).Text;
            //            (Controls[i--] as Button).Dispose();
            //            vuiButtons.Add(button);
            //        }
            //    }
            //}

            //https://stackoverflow.com/questions/5489273/how-do-i-disable-the-horizontal-scrollbar-in-a-panel=
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.HorizontalScroll.Enabled = false;
            flowLayoutPanel1.HorizontalScroll.Visible = false;
        }

        public void ConvertToVUILabel(Label label)
        {
            VUI.VUILabel vl = new VUI.VUILabel();
            vl.Size = label.Size;
            vl.Location = label.Location;
            vl.Text = label.Text;
            vl.Font = label.Font;
            vuiLabels.Add(vl);
            label.Dispose();
        }

        public PicDetailElement(int index)
        {
            Disposed += OnDispose;
        }

        private void OnDispose(object sender, EventArgs e)
        {
            if (image != null)
                image.Dispose();
            if (info != null && info.IsValueCreated)
                info.Value.Dispose();
            if (vuiPB.Image != null)
                vuiPB.Image.Dispose();
            LogEssential.Instance.PushLog(() => $"Successful disposed! [PicDetailElement] {label}");
        }

        #region VUI
        private void PicDetailElement_Paint(object sender, PaintEventArgs e)
        {
            ViewBuffer buffer = new ViewBuffer();
            buffer.CreateGraphics(Width, Height);
            Graphics g = buffer.g;

            vuiPB.Paint(g);

            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            
            float star_position = vuiPB.Location.X + 4;

            if (downloaded_overlapping)
            {
                g.DrawString("★", new Font(font.FontFamily, 12), Brushes.Orange, new PointF(star_position, vuiPB.Location.Y));
                star_position += 6;
            }

            if (hidden_data)
            {
                g.DrawString("★", new Font(font.FontFamily, 12), Brushes.SkyBlue, new PointF(star_position, vuiPB.Location.Y));
                star_position += 6;
            }

            if (bookmark)
            {
                g.DrawString("★", new Font(font.FontFamily, 12), Brushes.OrangeRed, new PointF(star_position, vuiPB.Location.Y));
            }
            
            vuiLabels.ForEach(x => x.Paint(g));
            vuiButtons.ForEach(x => x.Paint(g));

            buffer.Draw(e.Graphics);
            buffer.Dispose();
        }
        
        private void PicDetailElement_MouseMove(object sender, MouseEventArgs e)
        {
            Point screenPosition = MousePosition;
            Point clientPosition = PointToClient(screenPosition);
            vuiPB.MouseMove(clientPosition);
        }
        private void PicDetailElement_MouseLeave(object sender, EventArgs e)
        {
            vuiPB.MouseLeave();
        }
        #endregion
        
        public void SetImageFromAddress(string addr, int pannelw, int pannelh, bool title = true)
        {
            Dock = DockStyle.Bottom;
            try
            {
                using (FileStream fs = new FileStream(addr, FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.DeleteOnClose))
                {
                    vuiPB.Image = /*pb.Image =*/ image = Image.FromStream(fs);
                }
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                if (title)
                    info = new Lazy<InfoForm>(() => new InfoForm(Image, new Size(image.Width * 3 / 4, image.Height * 3 / 4)));
                else
                    info = new Lazy<InfoForm>(() => new InfoForm(Image, new Size(image.Width * 3 / 4 / 2, image.Height * 3 / 4 / 2)));
            }
            catch { }
        }

        private void PicDetailElement_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Downloading && !Downloaded)
            {
                selected = !selected;
                if (selected) BackColor = Color.FromArgb(200, 234, 202, 233);
                else BackColor = Color.GhostWhite;
            }
        }

        public bool Selected
        { get { return selected; } set { selected = value; if (!Downloading && !Downloaded) { if (selected) BackColor = Color.FromArgb(200, 234, 202, 233); else BackColor = Color.GhostWhite; } } }
        public bool MouseIn
        { get { return mouse_enter; } set { mouse_enter = value; Invalidate(); } }
        public Image Image
        { get { return image; } set { image = value; } }
        public string Label
        { get { return label; } set { label = value; } }
        public HitomiArticle Article
        { get { return ha; } set { ha = value;
                if (HitomiLog.Instance.Contains(ha.Magic)) downloaded_overlapping = true;
                if (HitomiData.Instance.thumbnail_collection.ContainsKey(ha.Magic)) hidden_data = true;
                if (HitomiBookmark.Instance.GetModel().Articles.Any(x => ha.Magic == x.Item1)) bookmark = true;
                if (ha.Artists != null && HitomiBookmark.Instance.GetModel().Artists.Any(x => ha.Artists.Contains(x.Item1))) bookmark = true;
            } }
        public override Font Font
        { set { font = value; } }
        public PictureBox Picture
        { get { return pb; } }
        public bool Downloaded
        { get { return downloaded; } set { downloaded = value; } }
        public bool Downloading
        { get { return downloading; } set { downloading = value; if (Downloading) BackColor = Color.FromArgb(200, 200, 200, 0); else BackColor = Color.FromArgb(200, 200, 130, 130); } }
        public bool Overlap
        { get { return overlap; } set { overlap = value; } }
        public bool IsHidden
        { get { return hidden_data; } }
        public bool IsDownloaded
        { get { return downloaded_overlapping; } }

        private void PicDetailElement_Load(object sender, EventArgs e)
        {
            lTitle.Text = ha.Title;
            lArtist.Text = string.Join(",", ha.Artists ?? Enumerable.Empty<string>());
            lSeries.Text = string.Join(",", ha.Series ?? Enumerable.Empty<string>());
            lGroup.Text = string.Join(",", ha.Groups ?? Enumerable.Empty<string>());
            lCharacter.Text = string.Join(",", ha.Characters ?? Enumerable.Empty<string>());
            lDate.Text = HitomiDate.estimate_datetime(Convert.ToInt32(ha.Magic)).ToString();
            if (ha.Tags != null)
                ha.Tags.ToList().ForEach((a) =>
                {
                    a = HitomiCommon.LegalizeTag(a);
                    if (a.StartsWith("female:")) AddTagToPanel(a.Substring("female:".Length), 1);
                    else if (a.StartsWith("male:")) AddTagToPanel(a.Substring("male:".Length), 2);
                    else AddTagToPanel(a, 0);
                });
            if (HitomiSetting.Instance.GetModel().UsingExHentaiBaseOpener)
                metroButton4.Text = "익헨에서 열기";
            lLang.Text = ha.Language;
            if (HitomiSetting.Instance.GetModel().Language != "ALL") {
                label9.Dispose();
                lLang.Dispose();
            }

            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i] is Label && Controls[i] != lPage)
                    ConvertToVUILabel(Controls[i--] as Label);
            }
            
            if (HitomiSetting.Instance.GetModel().ShowPageCount)
                Task.Run(() => {
                    string ppp = HitomiCore.GetPageCount(this).ToString() + "p";
                    this.Send(() => lPage.Text = ppp);
                    });
            else
                lPage.Dispose();

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
                    (new frmTagInfo(parent, "female:" + ((Button)sender).Text)).Show();
                else if (((Button)sender).ForeColor == Color.Blue)
                    (new frmTagInfo(parent, "male:" + ((Button)sender).Text)).Show();
                else
                    (new frmTagInfo(parent, ((Button)sender).Text)).Show();
            }
        }
        
        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmArtistInfo(parent, ha.Artists[0])).Show();
            }
            catch { }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmGroupInfo(parent, ha.Groups[0])).Show();
            }
            catch { }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                (new frmPreview(parent, ha.Magic)).Show();
            }
            catch { }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (!HitomiSetting.Instance.GetModel().UsingExHentaiBaseOpener)
                System.Diagnostics.Process.Start($"https://hitomi.la/galleries/{ha.Magic}.html");
            else
            {
                string result = ExHentaiTool.GetAddressFromMagicTitle(ha.Magic, ha.OriginalTitle);
                if (result != "")
                    System.Diagnostics.Process.Start(result);
                else
                    MessageBox.Show("익헨 주소를 찾지 못했습니다.", "Hitomi Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            string result = ExHentaiTool.GetAddressFromMagicTitle(ha.Magic, ha.OriginalTitle);
            if (result != "")
                (new frmComment(parent, result)).Show();
            else
                MessageBox.Show("익헨 주소를 찾지 못했습니다.", "Hitomi Copy", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PicDetailElement_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            (new frmGalleryInfo(parent, this)).Show();

            if (!Downloading && !Downloaded)
            {
                selected = false;
                BackColor = Color.GhostWhite;
            }
        }

        #region 메뉴

        private void 제목으로검색TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new frmFinder(Article.OriginalTitle)).Show();
        }

        private void Artist_Click(object sender, EventArgs e)
        {
            (new frmArtistInfo(parent,(sender as ToolStripMenuItem).Text)).Show();
        }

        private void Group_Click(object sender, EventArgs e)
        {
            (new frmGroupInfo(parent,(sender as ToolStripMenuItem).Text)).Show();
        }

        private void Series_Click(object sender, EventArgs e)
        {
            (new frmFinder("series:" + (sender as ToolStripMenuItem).Text.Split('(')[0].Trim().Replace(' ', '_'))).Show();
        }

        private void Character_Click(object sender, EventArgs e)
        {
            (new frmFinder("character:" + (sender as ToolStripMenuItem).Text.Replace(' ', '_'))).Show();
        }

        private void Tag_Click(object sender, EventArgs e)
        {
            (new frmFinder("tag:" + (sender as ToolStripMenuItem).Text.Split('(')[0].Trim().Replace(' ', '_'))).Show();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string[] artist = Article.Artists?.Select(x => x.Trim()).ToArray();
            string[] group = Article.Groups?.Select(x => x.Trim()).ToArray();
            string[] series = Article.Series?.Select(x => x.Trim()).ToArray();
            string[] character = Article.Characters?.Select(x => x.Trim()).ToArray();
            string[] tag = Article.Tags?.Select(x => x.Trim()).ToArray();

            (contextMenuStrip1.Items[1] as ToolStripMenuItem).DropDownItems.Clear();
            if (artist != null) (contextMenuStrip1.Items[1] as ToolStripMenuItem).DropDownItems.AddRange(artist.Select(x => new ToolStripMenuItem(x, null, Artist_Click)).ToArray());

            (contextMenuStrip1.Items[2] as ToolStripMenuItem).DropDownItems.Clear();
            if (group != null) (contextMenuStrip1.Items[2] as ToolStripMenuItem).DropDownItems.AddRange(group.Select(x => new ToolStripMenuItem(x, null, Group_Click)).ToArray());

            (contextMenuStrip1.Items[3] as ToolStripMenuItem).DropDownItems.Clear();
            if (series != null) (contextMenuStrip1.Items[3] as ToolStripMenuItem).DropDownItems.AddRange(series.Select(x => {
                string ko = KoreanSeries.SeriesMap(x);
                if (ko != x)
                    return new ToolStripMenuItem($"{x} ({ko})", null, Series_Click);
                else
                    return new ToolStripMenuItem($"{x}", null, Series_Click);
            }).ToArray());

            (contextMenuStrip1.Items[4] as ToolStripMenuItem).DropDownItems.Clear();
            if (character != null) (contextMenuStrip1.Items[4] as ToolStripMenuItem).DropDownItems.AddRange(character.Select(x => new ToolStripMenuItem(x, null, Character_Click)).ToArray());

            (contextMenuStrip1.Items[5] as ToolStripMenuItem).DropDownItems.Clear();
            if (tag != null) (contextMenuStrip1.Items[5] as ToolStripMenuItem).DropDownItems.AddRange(tag.Select(x => {
                string ko = KoreanTag.TagMap(x);
                if (ko != x)
                {
                    if (ko.Contains(':'))
                        return new ToolStripMenuItem($"{x} ({ko.Split(':')[1]})", null, Tag_Click);
                    else
                        return new ToolStripMenuItem($"{x} ({ko})", null, Tag_Click);
                }
                else
                    return new ToolStripMenuItem($"{x}", null, Tag_Click);
            }).ToArray());
        }

        #endregion
    }
}
