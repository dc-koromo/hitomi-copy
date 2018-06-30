/* Copyright (C) 2018. Hitomi Parser Developers */

using System.Drawing;
using System.Windows.Forms;

namespace Hitomi_Copy_3.Graph
{
    public partial class Graph : UserControl
    {
        ViewManager vm;
        float zoom = 1.0F;

        public Graph()
        {
            InitializeComponent();

            MouseDown += new MouseEventHandler(OnMouseDown);
            MouseUp += new MouseEventHandler(OnMouseUp);
            MouseMove += new MouseEventHandler(OnMouseMove);
            MouseClick += new MouseEventHandler(OnMouseClick);
            MouseWheel += new MouseEventHandler(OnMouseWheel);

            vm = new ViewManager(Font);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            vm.Render(e.Graphics, this.Size, PointToClient(Cursor.Position), zoom);
            base.OnPaint(e);
        }

        #region Mouse Event

        bool ml_down = false;
        bool mr_down = false;
        Point mr_pos;
        Point ml_pos;

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (ml_down == false && e.Button == MouseButtons.Left)
            {
                ml_down = true;
                ml_pos = e.Location;

                Invalidate();
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (ml_down == true)
            {
                ml_down = false;
                
                Invalidate();
            }
            else if (mr_down == true)
            {
                mr_down = false;
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (ml_down)
            {
                Cursor = Cursors.Hand;
                
                int dx = ml_pos.X - e.Location.X;
                int dy = ml_pos.Y - e.Location.Y;

                vm.Move((int)(dx / zoom), (int)(dy / zoom));

                ml_pos = e.Location;
                Invalidate();
            }
            else if (mr_down)
            {
                mr_pos = e.Location;

                Invalidate();
            }
        }
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
        }
        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
        }
        
        #endregion
    }
}
