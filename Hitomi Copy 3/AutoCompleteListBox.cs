/* Copyright (C) 2018. Hitomi Parser Developers */

using Hitomi_Copy_3;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hitomi_Copy_2
{
    public partial class AutoCompleteListBox : ListBox
    {
        public int MaxColoredTextLength = 0;
        public string ColoredTargetText = "";

        public AutoCompleteListBox()
        {
            Hide();
            BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            ScrollAlwaysVisible = true;
            DrawMode = DrawMode.OwnerDrawVariable;

            DrawItem += ExListBox_DrawItem;
            MeasureItem += ExListBox_MeasureItem;
        }

        public static Size MeasureText(string Text, Font Font)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix;
            Size szProposed = new Size(int.MaxValue, int.MaxValue);
            Size sz1 = TextRenderer.MeasureText(".", Font, szProposed, flags);
            Size sz2 = TextRenderer.MeasureText(Text + Convert.ToString("."), Font, szProposed, flags);
            return new Size(sz2.Width - sz1.Width, sz2.Height);
        }

        private void ExListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.State == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, e.Bounds);
            }

            try
            {
                string text = Items[e.Index].ToString();
                if (!HitomiSetting.Instance.GetModel().UsingFuzzy)
                {
                    int StartColoredTextPosition = text.IndexOf(ColoredTargetText);

                    string firstdraw = Items[e.Index].ToString().Substring(0, StartColoredTextPosition);
                    e.Graphics.DrawString(firstdraw, Font, Brushes.White, new PointF(e.Bounds.X, e.Bounds.Y));

                    int mesaure1 = MeasureText(firstdraw, Font).Width;
                    string seconddraw = Items[e.Index].ToString().Substring(StartColoredTextPosition, MaxColoredTextLength);
                    e.Graphics.DrawString(seconddraw, Font, Brushes.Orange, new PointF(e.Bounds.X + mesaure1, e.Bounds.Y));

                    int mesaure2 = MeasureText(seconddraw, Font).Width;
                    e.Graphics.DrawString(Items[e.Index].ToString().Substring(StartColoredTextPosition + MaxColoredTextLength), this.Font, Brushes.White, new PointF(e.Bounds.X + mesaure1 + mesaure2, e.Bounds.Y));
                    e.DrawFocusRectangle();
                }
                else
                {
                    string postfix = text.Split(' ').Length > 1 ? text.Split(' ')[1] : "";
                    text = text.Split(' ')[0];
                    
                    int measure = 0;
                    int[] diff = StringAlgorithms.get_diff_array(text, ColoredTargetText);
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (diff[i+1] == 1)
                            e.Graphics.DrawString(text[i].ToString(), Font, Brushes.Orange, new PointF(e.Bounds.X + measure, e.Bounds.Y));
                        else
                            e.Graphics.DrawString(text[i].ToString(), Font, Brushes.White, new PointF(e.Bounds.X + measure, e.Bounds.Y));
                        measure += MeasureText(text[i].ToString(), Font).Width;
                    }
                    e.DrawFocusRectangle();

                    e.Graphics.DrawString(" " + postfix, Font, Brushes.White, new PointF(e.Bounds.X + measure, e.Bounds.Y));

                }
            }
            catch { }
        }

        private void ExListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (this.Items.Count > 0)
            {
                SizeF size = e.Graphics.MeasureString(Items[e.Index].ToString(), Font);
                e.ItemHeight = (int)size.Height;
                e.ItemWidth = (int)size.Width;
            }
        }
    }
}
