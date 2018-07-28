/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Windows.Forms;

namespace Hitomi_Copy_3
{
    public partial class CreateGroup : Form
    {
        public string ReturnValue { get; set; }

        public CreateGroup()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReturnValue = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
