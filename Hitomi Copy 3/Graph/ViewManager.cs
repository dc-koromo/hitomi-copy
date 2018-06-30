/* Copyright (C) 2018. Hitomi Parser Developers */

using System.Drawing;

namespace Hitomi_Copy_3.Graph
{
    public class ViewManager
    {
        Point bp;
        ViewBuffer vb;
        Font font;

        public ViewManager(Font font)
        {
            vb = new ViewBuffer();
            bp = new Point(0, 0);

            this.font = font;
        }

        public void Render(Graphics g, Size sizeOfPannel, Point mousePosition, float scale = 1.0F)
        {
            vb.CreateGraphics(sizeOfPannel.Width, sizeOfPannel.Height);

            vb.Draw(g);
        }

        public void Move(int dx, int dy)
        {
            bp = new Point(bp.X - dx, bp.Y - dy);
        }
    }
}
