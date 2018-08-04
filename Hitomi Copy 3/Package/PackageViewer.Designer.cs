namespace Hitomi_Copy_3.Package
{
    partial class PackageViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageViewer));
            this.PackagePannel = new Hitomi_Copy_2.ScrollFixLayoutPanel();
            this.SuspendLayout();
            // 
            // PackagePannel
            // 
            this.PackagePannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PackagePannel.AutoScroll = true;
            this.PackagePannel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PackagePannel.Location = new System.Drawing.Point(12, 12);
            this.PackagePannel.Name = "PackagePannel";
            this.PackagePannel.Size = new System.Drawing.Size(1122, 471);
            this.PackagePannel.TabIndex = 5;
            // 
            // PackageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1147, 497);
            this.Controls.Add(this.PackagePannel);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1163, 536);
            this.Name = "PackageViewer";
            this.Text = "PackageViewer";
            this.Load += new System.EventHandler(this.PackageViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Hitomi_Copy_2.ScrollFixLayoutPanel PackagePannel;
    }
}