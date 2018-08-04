/* Copyright (C) 2018. Hitomi Parser Developers */

// https://stackoverflow.com/questions/7731855/rounded-edges-in-picturebox-c-sharp
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hitomi_Copy_3.Package
{
    class OvalPictureBox : PictureBox
    {
        public OvalPictureBox()
        {
            this.BackColor = Color.DarkGray;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
                Region = new Region(gp);
            }
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Pink), 5), 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}
