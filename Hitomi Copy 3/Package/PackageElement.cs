/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hitomi_Copy_3.Package
{
    public partial class PackageElement : UserControl
    {
        public PackageElement()
        {
            InitializeComponent();

            Size = new Size(1096, 99);
            textBox1.BackColor = Color.White;
        }
        
        bool Expand = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Expand == false)
                Size = new Size(1096, 200);
            else
                Size = new Size(1096, 99);
            button1.Text = Expand ? "+" : "-";
            Expand = !Expand;
        }
    }
}
