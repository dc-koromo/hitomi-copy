namespace Hitomi_Copy_3
{
    partial class PicDetailElement
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pb = new System.Windows.Forms.PictureBox();
            this.lCharacter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lSeries = new System.Windows.Forms.Label();
            this.lArtist = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lGroup = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton5 = new MetroFramework.Controls.MetroButton();
            this.lLang = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lPage = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.제목으로검색TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작가로검색AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.그룹으로검색GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.시리즈로검색SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.캐릭터로검색CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.태그로검색GToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(3, 3);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(150, 200);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            // 
            // lCharacter
            // 
            this.lCharacter.AutoSize = true;
            this.lCharacter.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lCharacter.Location = new System.Drawing.Point(238, 100);
            this.lCharacter.Name = "lCharacter";
            this.lCharacter.Size = new System.Drawing.Size(58, 21);
            this.lCharacter.TabIndex = 30;
            this.lCharacter.Text = "캐릭터";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label1.Location = new System.Drawing.Point(170, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "캐릭터 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label4.Location = new System.Drawing.Point(170, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 28;
            this.label4.Text = "시리즈 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label3.Location = new System.Drawing.Point(186, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "작가 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.label2.Location = new System.Drawing.Point(179, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "제목 :";
            // 
            // lSeries
            // 
            this.lSeries.AutoSize = true;
            this.lSeries.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lSeries.Location = new System.Drawing.Point(238, 79);
            this.lSeries.Name = "lSeries";
            this.lSeries.Size = new System.Drawing.Size(58, 21);
            this.lSeries.TabIndex = 25;
            this.lSeries.Text = "시리즈";
            // 
            // lArtist
            // 
            this.lArtist.AutoSize = true;
            this.lArtist.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lArtist.Location = new System.Drawing.Point(238, 37);
            this.lArtist.Name = "lArtist";
            this.lArtist.Size = new System.Drawing.Size(42, 21);
            this.lArtist.TabIndex = 24;
            this.lArtist.Text = "작가";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.lTitle.Location = new System.Drawing.Point(237, 9);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(50, 25);
            this.lTitle.TabIndex = 23;
            this.lTitle.Text = "제목";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label5.Location = new System.Drawing.Point(186, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "태그 :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(242, 123);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(705, 60);
            this.flowLayoutPanel1.TabIndex = 34;
            // 
            // lGroup
            // 
            this.lGroup.AutoSize = true;
            this.lGroup.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lGroup.Location = new System.Drawing.Point(238, 58);
            this.lGroup.Name = "lGroup";
            this.lGroup.Size = new System.Drawing.Size(42, 21);
            this.lGroup.TabIndex = 31;
            this.lGroup.Text = "그룹";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label7.Location = new System.Drawing.Point(186, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 21);
            this.label7.TabIndex = 32;
            this.label7.Text = "그룹 :";
            // 
            // lDate
            // 
            this.lDate.AutoSize = true;
            this.lDate.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lDate.Location = new System.Drawing.Point(529, 62);
            this.lDate.Name = "lDate";
            this.lDate.Size = new System.Drawing.Size(42, 21);
            this.lDate.TabIndex = 37;
            this.lDate.Text = "날짜";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.label6.Location = new System.Drawing.Point(528, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 25);
            this.label6.TabIndex = 36;
            this.label6.Text = "업로드된 날짜:";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(963, 85);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(119, 27);
            this.metroButton1.TabIndex = 38;
            this.metroButton1.Text = "미리보기";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Location = new System.Drawing.Point(963, 145);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(119, 38);
            this.metroButton4.TabIndex = 41;
            this.metroButton4.Text = "히토미에서 열기";
            this.metroButton4.UseSelectable = true;
            this.metroButton4.Click += new System.EventHandler(this.metroButton4_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(963, 58);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(119, 27);
            this.metroButton3.TabIndex = 40;
            this.metroButton3.Text = "그룹 찾기";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(963, 31);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(119, 27);
            this.metroButton2.TabIndex = 39;
            this.metroButton2.Text = "작가 찾기";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroButton5
            // 
            this.metroButton5.Location = new System.Drawing.Point(963, 112);
            this.metroButton5.Name = "metroButton5";
            this.metroButton5.Size = new System.Drawing.Size(119, 27);
            this.metroButton5.TabIndex = 42;
            this.metroButton5.Text = "댓글 보기";
            this.metroButton5.UseSelectable = true;
            this.metroButton5.Click += new System.EventHandler(this.metroButton5_Click);
            // 
            // lLang
            // 
            this.lLang.AutoSize = true;
            this.lLang.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.lLang.Location = new System.Drawing.Point(587, 91);
            this.lLang.Name = "lLang";
            this.lLang.Size = new System.Drawing.Size(58, 21);
            this.lLang.TabIndex = 44;
            this.lLang.Text = "코리안";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.label9.Location = new System.Drawing.Point(529, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 21);
            this.label9.TabIndex = 43;
            this.label9.Text = "언어 :";
            // 
            // lPage
            // 
            this.lPage.AutoSize = true;
            this.lPage.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.lPage.Location = new System.Drawing.Point(170, 164);
            this.lPage.Name = "lPage";
            this.lPage.Size = new System.Drawing.Size(25, 19);
            this.lPage.TabIndex = 45;
            this.lPage.Text = "0p";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.제목으로검색TToolStripMenuItem,
            this.작가로검색AToolStripMenuItem,
            this.그룹으로검색GToolStripMenuItem,
            this.시리즈로검색SToolStripMenuItem,
            this.캐릭터로검색CToolStripMenuItem,
            this.태그로검색GToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 158);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 제목으로검색TToolStripMenuItem
            // 
            this.제목으로검색TToolStripMenuItem.Name = "제목으로검색TToolStripMenuItem";
            this.제목으로검색TToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.제목으로검색TToolStripMenuItem.Text = "제목으로 검색(&T)";
            this.제목으로검색TToolStripMenuItem.Click += new System.EventHandler(this.제목으로검색TToolStripMenuItem_Click);
            // 
            // 작가로검색AToolStripMenuItem
            // 
            this.작가로검색AToolStripMenuItem.Name = "작가로검색AToolStripMenuItem";
            this.작가로검색AToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.작가로검색AToolStripMenuItem.Text = "작가로 검색(&A)";
            // 
            // 그룹으로검색GToolStripMenuItem
            // 
            this.그룹으로검색GToolStripMenuItem.Name = "그룹으로검색GToolStripMenuItem";
            this.그룹으로검색GToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.그룹으로검색GToolStripMenuItem.Text = "그룹으로 검색(&G)";
            // 
            // 시리즈로검색SToolStripMenuItem
            // 
            this.시리즈로검색SToolStripMenuItem.Name = "시리즈로검색SToolStripMenuItem";
            this.시리즈로검색SToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.시리즈로검색SToolStripMenuItem.Text = "시리즈로 검색(&S)";
            // 
            // 캐릭터로검색CToolStripMenuItem
            // 
            this.캐릭터로검색CToolStripMenuItem.Name = "캐릭터로검색CToolStripMenuItem";
            this.캐릭터로검색CToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.캐릭터로검색CToolStripMenuItem.Text = "캐릭터로 검색(&C)";
            // 
            // 태그로검색GToolStripMenuItem
            // 
            this.태그로검색GToolStripMenuItem.Name = "태그로검색GToolStripMenuItem";
            this.태그로검색GToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.태그로검색GToolStripMenuItem.Text = "태그로 검색(&G)";
            // 
            // PicDetailElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lPage);
            this.Controls.Add(this.lLang);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.metroButton5);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.lDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lGroup);
            this.Controls.Add(this.lCharacter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lSeries);
            this.Controls.Add(this.lArtist);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.pb);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PicDetailElement";
            this.Size = new System.Drawing.Size(1096, 208);
            this.Load += new System.EventHandler(this.PicDetailElement_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PicDetailElement_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicDetailElement_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PicDetailElement_MouseDoubleClick);
            this.MouseLeave += new System.EventHandler(this.PicDetailElement_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicDetailElement_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Label lCharacter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lSeries;
        private System.Windows.Forms.Label lArtist;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lDate;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton5;
        private System.Windows.Forms.Label lLang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lPage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 제목으로검색TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작가로검색AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 그룹으로검색GToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 시리즈로검색SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 캐릭터로검색CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 태그로검색GToolStripMenuItem;
    }
}
