/* Copyright (C) 2018. Hitomi Parser Developers */

using hitomi.Parser;
using Hitomi_Copy_3;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Hitomi_Copy
{
    public interface IPicElement
    {
        bool Selected { get; set; }
        bool MouseIn { get; set; }
        Image Image { get; set; }
        string Label { get; set; }
        HitomiArticle Article { get; set; }
        Font Font { set; }
        PictureBox Picture { get; }
        bool Downloaded { get; set; }
        bool Downloading { get; set; }
        bool Overlap { get; set; }
        void SetImageFromAddress(string addr, int pannelw, int pannelh, bool title = true);
        void Invalidate();
    }

    public partial class PicElement : UserControl, IPicElement
    {
        Image image;
        bool selected = false;
        string label = "";
        Font font;
        bool mouse_enter = false;
        bool downloading = false;
        bool downloaded = false;
        bool overlap = false;
        HitomiArticle ha;
        PictureBox pb = new PictureBox();
        Lazy<InfoForm> info;
        Form parent;

        public PicElement(Form parent, ToolTip tooltip = null)
        {
            InitializeComponent();

            this.Paint += PicElement_Paint;
            this.BackColor = Color.WhiteSmoke;
            this.parent = parent;
            this.DoubleBuffered = true;

            MouseEnter += Thumbnail_MouseEnter;
            MouseLeave += Thumbnail_MouseLeave;
            MouseClick += Thunbnail_MouseClick;
            
            Disposed += OnDispose;
        }

        private void Thumbnail_MouseEnter(object sender, EventArgs e)
        { ((PicElement)sender).MouseIn = true; }
        private void Thumbnail_MouseLeave(object sender, EventArgs e)
        { ((PicElement)sender).MouseIn = false; }
        private void Thunbnail_MouseClick(object sender, EventArgs e)
        { if (((MouseEventArgs)e).Button == MouseButtons.Left) { ((PicElement)sender).Selected = !((PicElement)sender).Selected; } }

        private void PicElement_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            RectangleF LabelRect = new RectangleF(pb.Location.X, pb.Location.Y + pb.Size.Height + 2, pb.Width, 30);
            g.DrawString(label, font, Brushes.Black, LabelRect);
            if (downloaded == false)
            {
                if (selected)
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(200, 234, 202, 233));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                    g.DrawRectangle(new Pen(Color.LightPink, 2), 2, 2, this.Width - 4, this.Height - 4);
                }
                else if (mouse_enter)
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(100, 234, 202, 233));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                    g.DrawRectangle(new Pen(Color.FromArgb(255, 174, 201), 1), 1, 1, this.Width - 2, this.Height - 2);

                }
            }
            else
            {
                if (downloading)
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(200, 200, 200, 0));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                }
                else
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(200, 200, 130, 130));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                }
            }
            
            if (callfrom_paint == false)
            {
                callfrom_panel = true;
                pb.Invalidate();
            }
            callfrom_paint = false;
        }

        bool callfrom_paint = false;
        bool callfrom_panel = false;

        private void Picture_Paint(object sender, PaintEventArgs e)
        {
            ViewBuffer buffer = new ViewBuffer();
            buffer.CreateGraphics(pb.Width, pb.Height);

            Graphics g = buffer.g;

            if (downloaded == false)
            {
                if (selected)
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(170, 234, 202, 233));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                }
                else if (mouse_enter)
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(100, 234, 202, 233));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                }
            }
            else
            {
                if (downloading)
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(200, 200, 200, 0));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                }
                else
                {
                    SolidBrush basicBrushes = new SolidBrush(Color.FromArgb(200, 200, 130, 130));
                    g.FillRectangle(basicBrushes, 0, 0, Width, Height);
                }
            }

            if (callfrom_panel == false)
            {
                callfrom_paint = true;
                Invalidate();
            }
            callfrom_panel = false;

            buffer.Draw(e.Graphics);
            buffer.Dispose();
        }
        private void Invalidall()
        { callfrom_panel = callfrom_paint = false; Invalidate(); }
        private void Picture_MouseEnter(object sender, EventArgs e)
        { mouse_enter = true; if (!downloading) { info.Value.Location = Cursor.Position; info.Value.Show(); Invalidall(); } }
        private void Picture_MouseLeave(object sender, EventArgs e)
        { mouse_enter = false; if (!downloading) { info.Value.Location = Cursor.Position; info.Value.Hide(); Invalidall(); } }
        private void Picture_MouseMove(object sender, EventArgs e)
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
        private void Picture_MouseClick(object sender, EventArgs e)
        { if (((MouseEventArgs)e).Button == MouseButtons.Left) { selected = !selected; Invalidall(); } }
        private void Picture_MouseDoubleClick(object sender, EventArgs e)
        { if (((MouseEventArgs)e).Button == MouseButtons.Left) { OpenInfo(); selected = false; } }

        public void OpenInfo()
        {
            (new frmGalleryInfo(parent, this)).Show();
        }

        private void OnDispose(object sender, EventArgs e)
        {
            if (image != null)
                image.Dispose();
            if (info != null && info.IsValueCreated)
                info.Value.Dispose();
            LogEssential.Instance.PushLog(() => $"Successful disposed! [PicElement] {label}");
        }

        private new void Resize(object sedner, EventArgs e)
        {
            Invalidate();
        }

        public void SetImageFromAddress(string addr, int pannelw, int pannelh, bool title = true)
        {
            Dock = DockStyle.Bottom;
            try
            {
                pb.Location = new Point(3, 3);
                if (title == true)
                    pb.Size = new Size(pannelw - 6, pannelh - 30);
                else
                    pb.Size = new Size(pannelw - 6, pannelh - 6);
                using (FileStream fs = new FileStream(addr, FileMode.Open, FileAccess.Read, FileShare.None, 4096, FileOptions.DeleteOnClose))
                {
                    pb.Image = image = Image.FromStream(fs);
                }
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Paint += Picture_Paint;
                pb.MouseEnter += Picture_MouseEnter;
                pb.MouseLeave += Picture_MouseLeave;
                if (title) pb.MouseClick += Picture_MouseClick;
                pb.MouseMove += Picture_MouseMove;
                if (title) pb.MouseDoubleClick += Picture_MouseDoubleClick;
                if (title)
                    info = new Lazy<InfoForm>(() => new InfoForm(Image, new Size(image.Width*3/4, image.Height*3/4)));
                else
                    info = new Lazy<InfoForm>(() => new InfoForm(Image, new Size(image.Width*3/4/2, image.Height*3/4/2)));
                this.Width = pannelw;
                this.Height = pannelh;
                this.Controls.Add(pb);
            }
            catch (Exception ex)
            {
                LogEssential.Instance.PushLog(() => $"[Pic Element] {ex.Message}");
            }
        }

        public bool Selected
        { get { return selected; } set { selected = value; Invalidate(); } }
        public bool MouseIn
        { get { return mouse_enter; } set { mouse_enter = value; Invalidate(); } }
        public Image Image
        { get { return image; } set { image = value; } }
        public string Label
        { get { return label; } set { label = value; } }
        public HitomiArticle Article
        { get { return ha; } set { ha = value; } }
        public override Font Font
        { set { font = value; } }
        public PictureBox Picture
        { get { return pb; } }
        public bool Downloaded
        { get { return downloaded; } set { downloaded = value; } }
        public bool Downloading
        { get { return downloading; } set { downloading = value; } }
        public bool Overlap
        { get { return overlap; } set { overlap = value; } }
    }
}
