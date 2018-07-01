/* Copyright (C) 2018. Hitomi Parser Developers */

using System.Drawing;

namespace Hitomi_Copy_3.VUI
{
    public class VUIButton : VUIControl
    {
        public Font Font { get; set; }
        public string Text { get; set; }

        public VUIButton()
        {
            MouseMoveEvent = mouse_move_action;
            MouseLeaveEvent = mouse_leave_action;
        }

        bool hover = false;
        private void mouse_move_action()
        {
            hover = true;
        }
        private void mouse_leave_action()
        {
            hover = false;
        }

        public override void Paint(Graphics g)
        {
            var button = new MetroFramework.Controls.MetroButton();
            button.Location = Location;
            button.Size = Size;
            button.Text = Text;
            button.UseSelectable = true;
            Bitmap bim = new Bitmap(Size.Width, Size.Height);
            button.DrawToBitmap(bim, new Rectangle(0, 0, Size.Width, Size.Height));
            g.DrawImage(bim, Location);
            button.Dispose();
        }
    }
}
