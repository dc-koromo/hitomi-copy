namespace Hitomi_Copy
{
    partial class frmGalleryInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGalleryInfo));
            this.lTitle = new System.Windows.Forms.Label();
            this.lArtist = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lSeries = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lCharacter = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lGroup = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lDate = new System.Windows.Forms.Label();
            this.bPreview = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.lPage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.lTitle.Location = new System.Drawing.Point(504, 37);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(52, 28);
            this.lTitle.TabIndex = 7;
            this.lTitle.Text = "제목";
            this.lTitle.Click += new System.EventHandler(this.Label_Click);
            // 
            // lArtist
            // 
            this.lArtist.AutoSize = true;
            this.lArtist.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lArtist.Location = new System.Drawing.Point(504, 65);
            this.lArtist.Name = "lArtist";
            this.lArtist.Size = new System.Drawing.Size(48, 25);
            this.lArtist.TabIndex = 8;
            this.lArtist.Text = "작가";
            this.lArtist.Click += new System.EventHandler(this.Label_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.textBox1.Location = new System.Drawing.Point(509, 167);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(674, 152);
            this.textBox1.TabIndex = 9;
            this.textBox1.Visible = false;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGalleryInfo_KeyDown);
            // 
            // lSeries
            // 
            this.lSeries.AutoSize = true;
            this.lSeries.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lSeries.Location = new System.Drawing.Point(504, 114);
            this.lSeries.Name = "lSeries";
            this.lSeries.Size = new System.Drawing.Size(66, 25);
            this.lSeries.TabIndex = 10;
            this.lSeries.Text = "시리즈";
            this.lSeries.Click += new System.EventHandler(this.Label_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.label2.Location = new System.Drawing.Point(428, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 28);
            this.label2.TabIndex = 11;
            this.label2.Text = "제목 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.label3.Location = new System.Drawing.Point(434, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "작가 : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.label4.Location = new System.Drawing.Point(416, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "시리즈 : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.label5.Location = new System.Drawing.Point(434, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "태그 : ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button1.Location = new System.Drawing.Point(575, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 41);
            this.button1.TabIndex = 15;
            this.button1.Text = "작가 찾기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button2.Location = new System.Drawing.Point(575, 392);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 41);
            this.button2.TabIndex = 16;
            this.button2.Text = "시리즈 찾기";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button3.Location = new System.Drawing.Point(1020, 392);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(163, 41);
            this.button3.TabIndex = 17;
            this.button3.Text = "다운로드";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button4.Location = new System.Drawing.Point(1020, 345);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(163, 41);
            this.button4.TabIndex = 18;
            this.button4.Text = "히토미에서 열기";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.label1.Location = new System.Drawing.Point(416, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "캐릭터 : ";
            // 
            // lCharacter
            // 
            this.lCharacter.AutoSize = true;
            this.lCharacter.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lCharacter.Location = new System.Drawing.Point(504, 139);
            this.lCharacter.Name = "lCharacter";
            this.lCharacter.Size = new System.Drawing.Size(66, 25);
            this.lCharacter.TabIndex = 20;
            this.lCharacter.Text = "캐릭터";
            this.lCharacter.Click += new System.EventHandler(this.Label_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.label7.Location = new System.Drawing.Point(434, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 25);
            this.label7.TabIndex = 22;
            this.label7.Text = "그룹 : ";
            // 
            // lGroup
            // 
            this.lGroup.AutoSize = true;
            this.lGroup.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lGroup.Location = new System.Drawing.Point(504, 90);
            this.lGroup.Name = "lGroup";
            this.lGroup.Size = new System.Drawing.Size(48, 25);
            this.lGroup.TabIndex = 21;
            this.lGroup.Text = "그룹";
            this.lGroup.Click += new System.EventHandler(this.Label_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button5.Location = new System.Drawing.Point(718, 392);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 41);
            this.button5.TabIndex = 23;
            this.button5.Text = "캐릭터 찾기";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button6.Location = new System.Drawing.Point(718, 345);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(137, 41);
            this.button6.TabIndex = 24;
            this.button6.Text = "그룹 찾기";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(509, 167);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(674, 152);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(360, 446);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 6;
            this.pbImage.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.label6.Location = new System.Drawing.Point(881, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 28);
            this.label6.TabIndex = 26;
            this.label6.Text = "업로드된 날짜(추정):";
            // 
            // lDate
            // 
            this.lDate.AutoSize = true;
            this.lDate.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lDate.Location = new System.Drawing.Point(881, 111);
            this.lDate.Name = "lDate";
            this.lDate.Size = new System.Drawing.Size(48, 25);
            this.lDate.TabIndex = 27;
            this.lDate.Text = "날짜";
            this.lDate.Click += new System.EventHandler(this.Label_Click);
            // 
            // bPreview
            // 
            this.bPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bPreview.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.bPreview.Location = new System.Drawing.Point(432, 345);
            this.bPreview.Name = "bPreview";
            this.bPreview.Size = new System.Drawing.Size(137, 41);
            this.bPreview.TabIndex = 28;
            this.bPreview.Text = "미리보기";
            this.bPreview.UseVisualStyleBackColor = true;
            this.bPreview.Click += new System.EventHandler(this.bPreview_Click);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button7.Location = new System.Drawing.Point(432, 392);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(137, 41);
            this.button7.TabIndex = 29;
            this.button7.Text = "익헨에서 열기";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.button8.Location = new System.Drawing.Point(861, 392);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(137, 41);
            this.button8.TabIndex = 30;
            this.button8.Text = "댓글 보기";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // lPage
            // 
            this.lPage.AutoSize = true;
            this.lPage.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.lPage.Location = new System.Drawing.Point(416, 294);
            this.lPage.Name = "lPage";
            this.lPage.Size = new System.Drawing.Size(33, 25);
            this.lPage.TabIndex = 46;
            this.lPage.Text = "0p";
            // 
            // frmGalleryInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1286, 470);
            this.Controls.Add(this.lPage);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.bPreview);
            this.Controls.Add(this.lDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lGroup);
            this.Controls.Add(this.lCharacter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lSeries);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lArtist);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.pbImage);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1302, 509);
            this.Name = "frmGalleryInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "정보";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmGalleryInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmGalleryInfo_LoadAsync);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGalleryInfo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lArtist;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lSeries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lCharacter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lGroup;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lDate;
        private System.Windows.Forms.Button bPreview;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label lPage;
    }
}