/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Hitomi_Copy_3.Graph
{
    public class ViewManager
    {
        Point bp;
        ViewBuffer vb;
        Font font;
        GraphNodeManager gnm;
        Point dragbox_start = Point.Empty;
        Point dragbox_end = Point.Empty;
        bool drawdragbox = false;
        List<Tuple<RectangleF, string>> stayed_string = new List<Tuple<RectangleF, string>>();

        const int grid_rect = 50;

        public Font TextFont
        {
            get { return font; }
            set { font = value; }
        }

        public Point BasePoint
        {
            get { return bp; }
            set { bp = value; }
        }

        public bool IsDrawDragBox
        {
            get { return drawdragbox; }
            set { drawdragbox = value; }
        }

        public Point DragBoxStartPoint
        {
            get { return dragbox_start; }
            set { dragbox_start = value; }
        }

        public Point DragBoxEndPoint
        {
            get { return dragbox_end; }
            set { dragbox_end = value; }
        }

        public ViewManager(Font font)
        {
            vb = new ViewBuffer();
            bp = new Point(0, 0);
            gnm = new GraphNodeManager();

            this.font = font;
        }

        public void Render(Graphics g, Size sizeOfPannel, Point mousePosition, float scale = 1.0F, List<FixedString> fixedString = null)
        {
            vb.CreateGraphics(sizeOfPannel.Width, sizeOfPannel.Height);
            vb.g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            vb.g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            
            /* 확대 축소 변환 */
            vb.g.ScaleTransform(scale, scale);

            /* 원점을 마우스 표시 지점에 따라 이동 */
            vb.g.TranslateTransform(bp.X, bp.Y);

            sizeOfPannel = new Size((int)(sizeOfPannel.Width / scale), (int)(sizeOfPannel.Height / scale));

            ///
            /// 그리기 메인부 [!--
            DrawGrid(vb.g, sizeOfPannel, Color.FromArgb(150, 150, 255));
            //RenderEdge(vb.g, sizeOfPannel);
            RenderVertex(vb.g, sizeOfPannel, mousePosition);
            DrawStayedString(vb.g, scale);
            /// --!]
            ///

            /* 원점을 제자리로 되돌림 */
            vb.g.TranslateTransform(-bp.X, -bp.Y);

            ///
            /// 고정 오브젝트 그리기 메인부 [!--
            DrawEdge(vb.g, sizeOfPannel, Color.FromArgb(150, 255, 150));
            //DrawFixedText(vb.g, fixedString);
            if (drawdragbox) DrawDragBox(vb.g);
            /// --!]
            /// 

            vb.Draw(g);
        }

        public void Move(int dx, int dy)
        {
            bp = new Point(bp.X - dx, bp.Y - dy);
        }

        /// <summary>
        /// 테두리를 그립니다.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="sizeOfPannel"></param>
        /// <param name="color"></param>
        public void DrawEdge(Graphics g, Size sizeOfPannel, Color color)
        {
            g.DrawRectangle(new Pen(color, 2.0F), 1, 1, sizeOfPannel.Width - 2, sizeOfPannel.Height - 2);
        }

        /// <summary>
        /// 그리드라인을 그립니다.
        /// </summary>
        /// <param name="g">그리드라인을 그릴 그래픽스 드라이버</param>
        /// <param name="sizeOfPannel">그래픽스 드라이버 비트맵의 크기</param>
        /// <param name="size">정사각형의 한 변의 길이 (라인 1px가 포함됨)</param>
        /// <param name="color">라인 색</param>
        public void DrawGrid(Graphics g, Size sizeOfPannel, Color color)
        {
            int start_x = bp.X % grid_rect;
            int start_y = bp.Y % grid_rect;
            Pen pen = new Pen(color, 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int i = -bp.X + start_x; i < sizeOfPannel.Width - bp.X; i += grid_rect)
            {
                g.DrawLine(pen, new Point(i, -bp.Y), new Point(i, -bp.Y + sizeOfPannel.Height));
            }
            for (int i = -bp.Y + start_y; i < sizeOfPannel.Height - bp.Y; i += grid_rect)
            {
                g.DrawLine(pen, new Point(-bp.X, i), new Point(-bp.X + sizeOfPannel.Width, i));
            }
        }

        /// <summary>
        /// 드레그 박스를 그립니다.
        /// </summary>
        /// <param name="g"></param>
        public void DrawDragBox(Graphics g)
        {
            Rectangle rect = new Rectangle(Math.Min(dragbox_start.X, dragbox_end.X), Math.Min(dragbox_start.Y, dragbox_end.Y), Math.Abs(dragbox_start.X - dragbox_end.X), Math.Abs(dragbox_start.Y - dragbox_end.Y));
            g.DrawRectangle(new Pen(new SolidBrush(Color.FromArgb(170, 220, 170))), rect);
            g.FillRectangle(new SolidBrush(Color.FromArgb(100, 170, 220, 170)), new Rectangle(rect.X + 1, rect.Y + 1, rect.Width - 2, rect.Height - 2));
        }

        #region Vertex

        public void DrawVertex(Graphics g, GraphVertex v, Size sizeOfPannel)
        {
            int end_x = v.Position.X;
            int end_y = v.Position.Y;

            RectangleF draw_rect = new RectangleF(end_x - v.Radius, end_y - v.Radius, v.Radius * 2, v.Radius * 2);

            if (RectangleF.Intersect(new Rectangle(-bp.X, -bp.Y, sizeOfPannel.Width, sizeOfPannel.Height), draw_rect) != Rectangle.Empty)
            {
                g.DrawEllipse(new Pen(Color.Black, 1.0F), draw_rect);
                g.FillEllipse(new SolidBrush(v.Color), draw_rect);
                stayed_string.Add(new Tuple<RectangleF, string>(draw_rect, v.InnerText));
                stayed_string.Add(new Tuple<RectangleF, string>(new RectangleF(end_x - v.Radius - 150, end_y - v.Radius - 15, v.Radius * 2 + 300, 15), v.OuterText));
            }
        }

        private void RenderVertex(Graphics g, Size sizeOfPannel, Point mousePosition)
        {
            gnm.IterateVertexs(v => DrawVertex(g, v, sizeOfPannel));
        }
        
        #endregion

        private void DrawFixedText(Graphics g, List<FixedString> fix)
        {
            foreach (FixedString fs in fix)
            {
                g.DrawString(fs.Message, fs.Font, fs.Brush, fs.Position);
            }
        }

        private void DrawStayedString(Graphics g, float scale)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            foreach (var ss in stayed_string)
            {
                g.DrawString(ss.Item2, new Font(new FontFamily("Consolas"), 12 / scale), Brushes.Black, ss.Item1, sf);
            }
            stayed_string.Clear();
        }
    }
}
