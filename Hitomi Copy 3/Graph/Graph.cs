/* Copyright (C) 2018. Hitomi Parser Developers */

using System.Collections.Generic;
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

            ResizeRedraw = true;
            DoubleBuffered = true;

            MouseDown += new MouseEventHandler(OnMouseDown);
            MouseUp += new MouseEventHandler(OnMouseUp);
            MouseMove += new MouseEventHandler(OnMouseMove);
            MouseClick += new MouseEventHandler(OnMouseClick);
            MouseWheel += new MouseEventHandler(OnMouseWheel);

            vm = new ViewManager(Font);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            vm.Render(e.Graphics, this.Size, PointToClient(Cursor.Position), zoom, GetStaticState());
            base.OnPaint(e);
        }

        private List<FixedString> GetStaticState()
        {
            List<FixedString> fx = new List<FixedString>();
            string message = $"Base Point : {vm.BasePoint.ToString()}\n" +
                $"Mouse Point : {PointToClient(Cursor.Position).ToString()}\n";
            if (key_control)
                message += "\nControl Key Pressed";
            fx.Add(new FixedString(message, new Point(10, 10), Font, Brushes.Aqua));
            return fx;
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

                if (key_control)
                {
                    vm.DragBoxEndPoint = vm.DragBoxStartPoint = PointToClient(Cursor.Position);
                    vm.IsDrawDragBox = true;
                }

                Invalidate();
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (ml_down == true)
            {
                ml_down = false;

                if (key_control)
                {
                    //vm.CellSelectDraged();
                    vm.IsDrawDragBox = false;
                }

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
                if (!key_control)
                {
                    Cursor = Cursors.Hand;
                    
                    int dx = ml_pos.X - e.Location.X;
                    int dy = ml_pos.Y - e.Location.Y;

                    vm.Move((int)(dx / zoom), (int)(dy / zoom));
                }
                else
                {
                    vm.DragBoxEndPoint = e.Location;
                }
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
            Point p = PointToClient(e.Location);
            float prev_zoom = zoom;


            if (e.Delta > 0)
                zoom += 0.05F;
            else
                zoom -= 0.05F;

            int dx = (int)(p.X - p.X * prev_zoom / zoom);
            int dy = (int)(p.Y - p.Y * prev_zoom / zoom);
            vm.Move(dx, dy);
            //vm.Move((int)(p.X * prev_zoom / zoom), (int)(p.Y * prev_zoom / zoom));

            Invalidate();
        }

        #region Mouse Clipping
        
        public void ClipStart()
        {
            Cursor.Clip = new Rectangle(PointToScreen(Location), Size);
        }

        public void ClipEnd()
        {
            Cursor.Clip = new Rectangle();
        }

        #endregion

        #endregion

        #region Keyboard Event

        bool key_control = false;

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cursor.Clip = Rectangle.Empty;
                    break;
                case Keys.A:
                    //if (e.Control) vm.CellSelectAll();
                    break;
                case Keys.Delete:
                    //vm.CellDeleteSelected();
                    break;
                default:
                    if (e.Control && !key_control)
                    {
                        key_control = true;
                    }
                    break;
            }
            Invalidate();
        }
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            key_control = false;
            vm.IsDrawDragBox = false;
            Invalidate();
        }

        #endregion
    }
}
