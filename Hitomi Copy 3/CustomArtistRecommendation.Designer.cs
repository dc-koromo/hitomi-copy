﻿namespace Hitomi_Copy_3
{
    partial class CustomArtistRecommendation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomArtistRecommendation));
            this.lvCustomTag = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvArtists = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bUpdate = new System.Windows.Forms.Button();
            this.bAddTag = new System.Windows.Forms.Button();
            this.bAddArtistTag = new System.Windows.Forms.Button();
            this.opMul = new System.Windows.Forms.RadioButton();
            this.opAdd = new System.Windows.Forms.RadioButton();
            this.opSet = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bBookmark = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bOpen = new System.Windows.Forms.Button();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvCustomTag
            // 
            this.lvCustomTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvCustomTag.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvCustomTag.FullRowSelect = true;
            this.lvCustomTag.GridLines = true;
            this.lvCustomTag.Location = new System.Drawing.Point(12, 12);
            this.lvCustomTag.Name = "lvCustomTag";
            this.lvCustomTag.Size = new System.Drawing.Size(281, 431);
            this.lvCustomTag.TabIndex = 0;
            this.lvCustomTag.UseCompatibleStateImageBehavior = false;
            this.lvCustomTag.View = System.Windows.Forms.View.Details;
            this.lvCustomTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvCustomTag_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "태그";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "개수";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 108;
            // 
            // lvArtists
            // 
            this.lvArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvArtists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader5,
            this.columnHeader6});
            this.lvArtists.FullRowSelect = true;
            this.lvArtists.GridLines = true;
            this.lvArtists.Location = new System.Drawing.Point(299, 12);
            this.lvArtists.Name = "lvArtists";
            this.lvArtists.Size = new System.Drawing.Size(918, 431);
            this.lvArtists.TabIndex = 1;
            this.lvArtists.UseCompatibleStateImageBehavior = false;
            this.lvArtists.View = System.Windows.Forms.View.Details;
            this.lvArtists.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvArtists_MouseDoubleClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "순위";
            this.columnHeader3.Width = 59;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "작가";
            this.columnHeader4.Width = 122;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "점수";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 107;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "태그";
            this.columnHeader6.Width = 515;
            // 
            // bUpdate
            // 
            this.bUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bUpdate.Location = new System.Drawing.Point(1091, 449);
            this.bUpdate.Name = "bUpdate";
            this.bUpdate.Size = new System.Drawing.Size(126, 25);
            this.bUpdate.TabIndex = 3;
            this.bUpdate.Text = "업데이트";
            this.bUpdate.UseVisualStyleBackColor = true;
            this.bUpdate.Click += new System.EventHandler(this.bUpdate_ClickAsync);
            // 
            // bAddTag
            // 
            this.bAddTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddTag.Location = new System.Drawing.Point(12, 449);
            this.bAddTag.Name = "bAddTag";
            this.bAddTag.Size = new System.Drawing.Size(134, 25);
            this.bAddTag.TabIndex = 4;
            this.bAddTag.Text = "새로운 태그 추가";
            this.bAddTag.UseVisualStyleBackColor = true;
            this.bAddTag.Click += new System.EventHandler(this.bAddTag_Click);
            // 
            // bAddArtistTag
            // 
            this.bAddArtistTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bAddArtistTag.Location = new System.Drawing.Point(152, 449);
            this.bAddArtistTag.Name = "bAddArtistTag";
            this.bAddArtistTag.Size = new System.Drawing.Size(141, 25);
            this.bAddArtistTag.TabIndex = 5;
            this.bAddArtistTag.Text = "새로운 작가 태그 추가";
            this.bAddArtistTag.UseVisualStyleBackColor = true;
            this.bAddArtistTag.Click += new System.EventHandler(this.bAddArtistTag_Click);
            // 
            // opMul
            // 
            this.opMul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.opMul.AutoSize = true;
            this.opMul.Checked = true;
            this.opMul.Location = new System.Drawing.Point(409, 452);
            this.opMul.Name = "opMul";
            this.opMul.Size = new System.Drawing.Size(49, 19);
            this.opMul.TabIndex = 6;
            this.opMul.TabStop = true;
            this.opMul.Text = "곱셈";
            this.opMul.UseVisualStyleBackColor = true;
            // 
            // opAdd
            // 
            this.opAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.opAdd.AutoSize = true;
            this.opAdd.Location = new System.Drawing.Point(464, 452);
            this.opAdd.Name = "opAdd";
            this.opAdd.Size = new System.Drawing.Size(49, 19);
            this.opAdd.TabIndex = 7;
            this.opAdd.Text = "덧셈";
            this.opAdd.UseVisualStyleBackColor = true;
            // 
            // opSet
            // 
            this.opSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.opSet.AutoSize = true;
            this.opSet.Location = new System.Drawing.Point(519, 452);
            this.opSet.Name = "opSet";
            this.opSet.Size = new System.Drawing.Size(61, 19);
            this.opSet.TabIndex = 8;
            this.opSet.Text = "초기화";
            this.opSet.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "연산법 : ";
            // 
            // bBookmark
            // 
            this.bBookmark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bBookmark.Location = new System.Drawing.Point(840, 449);
            this.bBookmark.Name = "bBookmark";
            this.bBookmark.Size = new System.Drawing.Size(141, 25);
            this.bBookmark.TabIndex = 10;
            this.bBookmark.Text = "북마크에 추가";
            this.bBookmark.UseVisualStyleBackColor = true;
            this.bBookmark.Click += new System.EventHandler(this.bBookmark_Click);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(695, 450);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(139, 23);
            this.tbName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 454);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "북마크 이름 : ";
            // 
            // bOpen
            // 
            this.bOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpen.Location = new System.Drawing.Point(987, 449);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(78, 25);
            this.bOpen.TabIndex = 13;
            this.bOpen.Text = "불러오기";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "작품 수";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 76;
            // 
            // CustomArtistRecommendation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1229, 483);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.bBookmark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.opSet);
            this.Controls.Add(this.opAdd);
            this.Controls.Add(this.opMul);
            this.Controls.Add(this.bAddArtistTag);
            this.Controls.Add(this.bAddTag);
            this.Controls.Add(this.bUpdate);
            this.Controls.Add(this.lvArtists);
            this.Controls.Add(this.lvCustomTag);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1245, 522);
            this.Name = "CustomArtistRecommendation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Artist Recommendation";
            this.Load += new System.EventHandler(this.CustomArtistRecommendation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvCustomTag;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvArtists;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button bUpdate;
        private System.Windows.Forms.Button bAddTag;
        private System.Windows.Forms.Button bAddArtistTag;
        private System.Windows.Forms.RadioButton opMul;
        private System.Windows.Forms.RadioButton opAdd;
        private System.Windows.Forms.RadioButton opSet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bBookmark;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}