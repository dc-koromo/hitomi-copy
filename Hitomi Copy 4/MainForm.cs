﻿/*************************************************************************

   Copyright (C) 2018. dc-koromo. All Rights Reserved.

   Author: Koromo Hitomi Copy Developer

***************************************************************************/

using System;

namespace Hitomi_Copy_4
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text += Version.Text;
        }
    }
}
