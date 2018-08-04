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
            var list = Package.Instance.GetModel().Elements;
            list.Sort((a, b) => b.LatestUpdate.CompareTo(a.LatestUpdate));
            foreach (var pem in list)
            {
                PackagePannel.Controls.Add(new PackageElement(pem));
            }
        }

        private void PackageViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            for (int i = PackagePannel.Controls.Count - 1; i >= 0; i--)
                if (PackagePannel.Controls[i] != null)
                    PackagePannel.Controls[i].Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new PackageMaker()).Show();
        }
    }
}
