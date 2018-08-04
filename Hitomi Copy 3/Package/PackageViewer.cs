/* Copyright (C) 2018. Hitomi Parser Developers */

using System;
using System.Windows.Forms;

namespace Hitomi_Copy_3.Package
{
    public partial class PackageViewer : Form
    {
        public PackageViewer()
        {
            InitializeComponent();
        }

        private void PackageViewer_Load(object sender, EventArgs e)
        {
            PackagePannel.Controls.Add(new PackageElement());
            PackagePannel.Controls.Add(new PackageElement());
            PackagePannel.Controls.Add(new PackageElement());
        }
    }
}
