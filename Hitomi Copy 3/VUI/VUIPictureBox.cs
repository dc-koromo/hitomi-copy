/* Copyright (C) 2018. Hitomi Parser Developers */

using System.Drawing;

namespace Hitomi_Copy_3.VUI
{
    public class VUIPictureBox : VUIControl
    {
        public Image Image { get; set; }

        public override void Paint(Graphics g)
        {
            if (Image == null) return;
            decimal r1 = (decimal)Image.Width / Image.Height;
            decimal r2 = (decimal)Size.Width / Size.Height;
            int w = Size.Width;
            int h = Size.Height;
            if (r1 > r2)
            {
                w = Size.Width;
                h = (int)(w / r1);
            }
            else if (r1 < r2)
            {
                h = Size.Height;
                w = (int)(r1 * h);
            }
            int x = (Size.Width - w) / 2;
            int y = (Size.Height - h) / 2;
            g.DrawImage(Image, new Rectangle(x+Location.X, y+Location.Y, w, h));
        }
    }
}
