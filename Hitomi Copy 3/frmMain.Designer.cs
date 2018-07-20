namespace Hitomi_Copy_3
{
    partial class frmMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MainTab = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.제목비슷한작품정리TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lStatusSearch = new MetroFramework.Controls.MetroLabel();
            this.pbLoad = new MetroFramework.Controls.MetroProgressBar();
            this.bCancleAll = new MetroFramework.Controls.MetroButton();
            this.bChooseAll = new MetroFramework.Controls.MetroButton();
            this.bTidy = new MetroFramework.Controls.MetroButton();
            this.tbLang = new MetroFramework.Controls.MetroTextBox();
            this.bDownload = new MetroFramework.Controls.MetroButton();
            this.bSearch = new MetroFramework.Controls.MetroButton();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.finder열기FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearch = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.lDownloadSpeed = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.bAbort = new MetroFramework.Controls.MetroButton();
            this.lRetry = new MetroFramework.Controls.MetroLabel();
            this.lDownloadStatusSize = new MetroFramework.Controls.MetroLabel();
            this.lDownloadSize = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.lStatus = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.pbTarget = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.lvStandBy = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroTabPage4 = new MetroFramework.Controls.MetroTabPage();
            this.bCustomRecommend = new MetroFramework.Controls.MetroButton();
            this.bRTidy = new MetroFramework.Controls.MetroButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tgFilterArtists = new MetroFramework.Controls.MetroToggle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.이미지로저장SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.bRelatedTags = new MetroFramework.Controls.MetroButton();
            this.bStat = new MetroFramework.Controls.MetroButton();
            this.bDetailSetting = new MetroFramework.Controls.MetroButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tgAutoZip = new MetroFramework.Controls.MetroToggle();
            this.bSync = new MetroFramework.Controls.MetroButton();
            this.lThread = new MetroFramework.Controls.MetroLabel();
            this.vThread = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.cbLanguage = new MetroFramework.Controls.MetroComboBox();
            this.tbInfo = new MetroFramework.Controls.MetroTextBox();
            this.tbExcludeTag = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tbDownloadPath = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.lMemoryUsage = new MetroFramework.Controls.MetroLabel();
            this.MemoryUsageUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.speed_timer = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new Hitomi_Copy_2.AutoCompleteListBox();
            this.ImagePanel = new Hitomi_Copy_2.ScrollFixLayoutPanel();
            this.RecommendPannel = new Hitomi_Copy_2.ScrollFixLayoutPanel();
            this.pbSync = new Hitomi_Copy_3.MarqueeColorBar();
            this.MainTab.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.metroTabPage1);
            this.MainTab.Controls.Add(this.metroTabPage2);
            this.MainTab.Controls.Add(this.metroTabPage4);
            this.MainTab.Controls.Add(this.metroTabPage3);
            this.MainTab.Location = new System.Drawing.Point(10, 59);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(1136, 551);
            this.MainTab.Style = MetroFramework.MetroColorStyle.Pink;
            this.MainTab.TabIndex = 1;
            this.MainTab.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MainTab.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.listBox1);
            this.metroTabPage1.Controls.Add(this.ImagePanel);
            this.metroTabPage1.Controls.Add(this.lStatusSearch);
            this.metroTabPage1.Controls.Add(this.pbLoad);
            this.metroTabPage1.Controls.Add(this.bCancleAll);
            this.metroTabPage1.Controls.Add(this.bChooseAll);
            this.metroTabPage1.Controls.Add(this.bTidy);
            this.metroTabPage1.Controls.Add(this.tbLang);
            this.metroTabPage1.Controls.Add(this.bDownload);
            this.metroTabPage1.Controls.Add(this.bSearch);
            this.metroTabPage1.Controls.Add(this.tbSearch);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 2;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(1128, 509);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "검색";
            this.metroTabPage1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.제목비슷한작품정리TToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(239, 26);
            // 
            // 제목비슷한작품정리TToolStripMenuItem
            // 
            this.제목비슷한작품정리TToolStripMenuItem.Name = "제목비슷한작품정리TToolStripMenuItem";
            this.제목비슷한작품정리TToolStripMenuItem.Size = new System.Drawing.Size(238, 22);
            this.제목비슷한작품정리TToolStripMenuItem.Text = "제목 비슷한 작품 선택 취소(&C)";
            this.제목비슷한작품정리TToolStripMenuItem.Click += new System.EventHandler(this.제목비슷한작품정리TToolStripMenuItem_Click);
            // 
            // lStatusSearch
            // 
            this.lStatusSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lStatusSearch.AutoSize = true;
            this.lStatusSearch.Location = new System.Drawing.Point(99, 485);
            this.lStatusSearch.Name = "lStatusSearch";
            this.lStatusSearch.Size = new System.Drawing.Size(112, 19);
            this.lStatusSearch.TabIndex = 27;
            this.lStatusSearch.Text = "0 개 항목 검색됨";
            // 
            // pbLoad
            // 
            this.pbLoad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLoad.Location = new System.Drawing.Point(276, 491);
            this.pbLoad.Maximum = 0;
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(378, 8);
            this.pbLoad.Style = MetroFramework.MetroColorStyle.Pink;
            this.pbLoad.TabIndex = 23;
            // 
            // bCancleAll
            // 
            this.bCancleAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancleAll.Location = new System.Drawing.Point(889, 484);
            this.bCancleAll.Name = "bCancleAll";
            this.bCancleAll.Size = new System.Drawing.Size(88, 23);
            this.bCancleAll.Style = MetroFramework.MetroColorStyle.Pink;
            this.bCancleAll.TabIndex = 26;
            this.bCancleAll.Text = "모두 선택 취소";
            this.bCancleAll.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bCancleAll.UseSelectable = true;
            this.bCancleAll.Click += new System.EventHandler(this.bCancleAll_Click);
            // 
            // bChooseAll
            // 
            this.bChooseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bChooseAll.Location = new System.Drawing.Point(806, 484);
            this.bChooseAll.Name = "bChooseAll";
            this.bChooseAll.Size = new System.Drawing.Size(77, 23);
            this.bChooseAll.Style = MetroFramework.MetroColorStyle.Pink;
            this.bChooseAll.TabIndex = 25;
            this.bChooseAll.Text = "모두 선택";
            this.bChooseAll.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bChooseAll.UseSelectable = true;
            this.bChooseAll.Click += new System.EventHandler(this.bChooseAll_Click);
            // 
            // bTidy
            // 
            this.bTidy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bTidy.Location = new System.Drawing.Point(682, 484);
            this.bTidy.Name = "bTidy";
            this.bTidy.Size = new System.Drawing.Size(88, 23);
            this.bTidy.Style = MetroFramework.MetroColorStyle.Pink;
            this.bTidy.TabIndex = 24;
            this.bTidy.Text = "정리";
            this.bTidy.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bTidy.UseSelectable = true;
            this.bTidy.Click += new System.EventHandler(this.bTidy_Click);
            // 
            // tbLang
            // 
            this.tbLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            // 
            // 
            // 
            this.tbLang.CustomButton.Image = null;
            this.tbLang.CustomButton.Location = new System.Drawing.Point(43, 1);
            this.tbLang.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbLang.CustomButton.Name = "";
            this.tbLang.CustomButton.Size = new System.Drawing.Size(21, 17);
            this.tbLang.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLang.CustomButton.TabIndex = 1;
            this.tbLang.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLang.CustomButton.UseSelectable = true;
            this.tbLang.CustomButton.Visible = false;
            this.tbLang.Lines = new string[] {
        "korean"};
            this.tbLang.Location = new System.Drawing.Point(3, 484);
            this.tbLang.MaxLength = 32767;
            this.tbLang.Name = "tbLang";
            this.tbLang.PasswordChar = '\0';
            this.tbLang.ReadOnly = true;
            this.tbLang.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbLang.SelectedText = "";
            this.tbLang.SelectionLength = 0;
            this.tbLang.SelectionStart = 0;
            this.tbLang.ShortcutsEnabled = true;
            this.tbLang.Size = new System.Drawing.Size(65, 23);
            this.tbLang.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbLang.TabIndex = 7;
            this.tbLang.Text = "korean";
            this.tbLang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLang.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLang.UseSelectable = true;
            this.tbLang.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLang.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // bDownload
            // 
            this.bDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bDownload.Location = new System.Drawing.Point(1011, 484);
            this.bDownload.Name = "bDownload";
            this.bDownload.Size = new System.Drawing.Size(114, 23);
            this.bDownload.Style = MetroFramework.MetroColorStyle.Pink;
            this.bDownload.TabIndex = 6;
            this.bDownload.Text = "다운로드";
            this.bDownload.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bDownload.UseSelectable = true;
            this.bDownload.Click += new System.EventHandler(this.bDownload_Click);
            // 
            // bSearch
            // 
            this.bSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSearch.ContextMenuStrip = this.contextMenuStrip3;
            this.bSearch.Enabled = false;
            this.bSearch.Location = new System.Drawing.Point(1011, 8);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(114, 23);
            this.bSearch.Style = MetroFramework.MetroColorStyle.Pink;
            this.bSearch.TabIndex = 5;
            this.bSearch.Text = "검색";
            this.bSearch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bSearch.UseSelectable = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finder열기FToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(150, 26);
            // 
            // finder열기FToolStripMenuItem
            // 
            this.finder열기FToolStripMenuItem.Name = "finder열기FToolStripMenuItem";
            this.finder열기FToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.finder열기FToolStripMenuItem.Text = "Finder 열기(&F)";
            this.finder열기FToolStripMenuItem.Click += new System.EventHandler(this.finder열기FToolStripMenuItem_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbSearch.CustomButton.Image = null;
            this.tbSearch.CustomButton.Location = new System.Drawing.Point(980, 1);
            this.tbSearch.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearch.CustomButton.Name = "";
            this.tbSearch.CustomButton.Size = new System.Drawing.Size(21, 17);
            this.tbSearch.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbSearch.CustomButton.TabIndex = 1;
            this.tbSearch.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSearch.CustomButton.UseSelectable = true;
            this.tbSearch.CustomButton.Visible = false;
            this.tbSearch.Enabled = false;
            this.tbSearch.Lines = new string[] {
        "recent:0-25"};
            this.tbSearch.Location = new System.Drawing.Point(3, 8);
            this.tbSearch.MaxLength = 32767;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.PasswordChar = '\0';
            this.tbSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbSearch.SelectedText = "";
            this.tbSearch.SelectionLength = 0;
            this.tbSearch.SelectionStart = 0;
            this.tbSearch.ShortcutsEnabled = true;
            this.tbSearch.Size = new System.Drawing.Size(1002, 23);
            this.tbSearch.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbSearch.TabIndex = 4;
            this.tbSearch.Text = "recent:0-25";
            this.tbSearch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSearch.UseSelectable = true;
            this.tbSearch.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbSearch.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            this.tbSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyUp);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.lDownloadSpeed);
            this.metroTabPage2.Controls.Add(this.metroLabel11);
            this.metroTabPage2.Controls.Add(this.bAbort);
            this.metroTabPage2.Controls.Add(this.lRetry);
            this.metroTabPage2.Controls.Add(this.lDownloadStatusSize);
            this.metroTabPage2.Controls.Add(this.lDownloadSize);
            this.metroTabPage2.Controls.Add(this.metroLabel10);
            this.metroTabPage2.Controls.Add(this.metroLabel9);
            this.metroTabPage2.Controls.Add(this.lStatus);
            this.metroTabPage2.Controls.Add(this.metroLabel8);
            this.metroTabPage2.Controls.Add(this.pbTarget);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.Controls.Add(this.lvStandBy);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 2;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(1128, 509);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "다운로드";
            this.metroTabPage2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // lDownloadSpeed
            // 
            this.lDownloadSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lDownloadSpeed.AutoSize = true;
            this.lDownloadSpeed.Location = new System.Drawing.Point(156, 469);
            this.lDownloadSpeed.Name = "lDownloadSpeed";
            this.lDownloadSpeed.Size = new System.Drawing.Size(47, 19);
            this.lDownloadSpeed.TabIndex = 32;
            this.lDownloadSpeed.Text = "0 KB/S";
            this.lDownloadSpeed.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel11
            // 
            this.metroLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(42, 469);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(108, 19);
            this.metroLabel11.TabIndex = 31;
            this.metroLabel11.Text = "다운로드 속도 : ";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // bAbort
            // 
            this.bAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAbort.Location = new System.Drawing.Point(920, 431);
            this.bAbort.Name = "bAbort";
            this.bAbort.Size = new System.Drawing.Size(162, 38);
            this.bAbort.Style = MetroFramework.MetroColorStyle.Pink;
            this.bAbort.TabIndex = 30;
            this.bAbort.Text = "선택파일 다운로드 취소";
            this.bAbort.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bAbort.UseSelectable = true;
            this.bAbort.Click += new System.EventHandler(this.bAbort_Click);
            // 
            // lRetry
            // 
            this.lRetry.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lRetry.AutoSize = true;
            this.lRetry.Location = new System.Drawing.Point(451, 431);
            this.lRetry.Name = "lRetry";
            this.lRetry.Size = new System.Drawing.Size(202, 19);
            this.lRetry.TabIndex = 29;
            this.lRetry.Text = "항목 다운로드를 재시작합니다.";
            this.lRetry.Theme = MetroFramework.MetroThemeStyle.Light;
            this.lRetry.Visible = false;
            // 
            // lDownloadStatusSize
            // 
            this.lDownloadStatusSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lDownloadStatusSize.AutoSize = true;
            this.lDownloadStatusSize.Location = new System.Drawing.Point(156, 450);
            this.lDownloadStatusSize.Name = "lDownloadStatusSize";
            this.lDownloadStatusSize.Size = new System.Drawing.Size(40, 19);
            this.lDownloadStatusSize.TabIndex = 28;
            this.lDownloadStatusSize.Text = "0 MB";
            this.lDownloadStatusSize.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lDownloadSize
            // 
            this.lDownloadSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lDownloadSize.AutoSize = true;
            this.lDownloadSize.Location = new System.Drawing.Point(156, 431);
            this.lDownloadSize.Name = "lDownloadSize";
            this.lDownloadSize.Size = new System.Drawing.Size(40, 19);
            this.lDownloadSize.TabIndex = 27;
            this.lDownloadSize.Text = "0 MB";
            this.lDownloadSize.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel10
            // 
            this.metroLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(42, 450);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(108, 19);
            this.metroLabel10.TabIndex = 26;
            this.metroLabel10.Text = "다운받은 크기 : ";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel9
            // 
            this.metroLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(24, 431);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(126, 19);
            this.metroLabel9.TabIndex = 25;
            this.metroLabel9.Text = "총 다운로드 크기 : ";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lStatus
            // 
            this.lStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(156, 400);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(36, 19);
            this.lStatus.TabIndex = 24;
            this.lStatus.Text = "0 / 0";
            this.lStatus.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel8
            // 
            this.metroLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(42, 400);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(108, 19);
            this.metroLabel8.TabIndex = 23;
            this.metroLabel8.Text = "다운로드 상태 : ";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // pbTarget
            // 
            this.pbTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTarget.Location = new System.Drawing.Point(42, 365);
            this.pbTarget.Maximum = 0;
            this.pbTarget.Name = "pbTarget";
            this.pbTarget.Size = new System.Drawing.Size(1040, 32);
            this.pbTarget.Style = MetroFramework.MetroColorStyle.Pink;
            this.pbTarget.TabIndex = 22;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(42, 25);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(97, 19);
            this.metroLabel2.TabIndex = 21;
            this.metroLabel2.Text = "대기중인 항목";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // lvStandBy
            // 
            this.lvStandBy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStandBy.BackColor = System.Drawing.SystemColors.Window;
            this.lvStandBy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvStandBy.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvStandBy.FullRowSelect = true;
            this.lvStandBy.GridLines = true;
            this.lvStandBy.Location = new System.Drawing.Point(42, 47);
            this.lvStandBy.Name = "lvStandBy";
            this.lvStandBy.Size = new System.Drawing.Size(1040, 312);
            this.lvStandBy.TabIndex = 20;
            this.lvStandBy.UseCompatibleStateImageBehavior = false;
            this.lvStandBy.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "큐";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "제목";
            this.columnHeader2.Width = 586;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "이미지 링크";
            this.columnHeader3.Width = 351;
            // 
            // metroTabPage4
            // 
            this.metroTabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.metroTabPage4.Controls.Add(this.bCustomRecommend);
            this.metroTabPage4.Controls.Add(this.bRTidy);
            this.metroTabPage4.Controls.Add(this.label1);
            this.metroTabPage4.Controls.Add(this.tgFilterArtists);
            this.metroTabPage4.Controls.Add(this.RecommendPannel);
            this.metroTabPage4.HorizontalScrollbarBarColor = true;
            this.metroTabPage4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.HorizontalScrollbarSize = 2;
            this.metroTabPage4.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage4.Name = "metroTabPage4";
            this.metroTabPage4.Size = new System.Drawing.Size(1128, 509);
            this.metroTabPage4.TabIndex = 4;
            this.metroTabPage4.Text = "작가추천";
            this.metroTabPage4.VerticalScrollbarBarColor = true;
            this.metroTabPage4.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage4.VerticalScrollbarSize = 10;
            // 
            // bCustomRecommend
            // 
            this.bCustomRecommend.Enabled = false;
            this.bCustomRecommend.Location = new System.Drawing.Point(161, 3);
            this.bCustomRecommend.Name = "bCustomRecommend";
            this.bCustomRecommend.Size = new System.Drawing.Size(152, 25);
            this.bCustomRecommend.Style = MetroFramework.MetroColorStyle.Pink;
            this.bCustomRecommend.TabIndex = 23;
            this.bCustomRecommend.Text = "커스텀 작가추천";
            this.bCustomRecommend.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bCustomRecommend.UseSelectable = true;
            this.bCustomRecommend.Click += new System.EventHandler(this.bCustomRecommend_Click);
            // 
            // bRTidy
            // 
            this.bRTidy.Enabled = false;
            this.bRTidy.Location = new System.Drawing.Point(3, 3);
            this.bRTidy.Name = "bRTidy";
            this.bRTidy.Size = new System.Drawing.Size(152, 25);
            this.bRTidy.Style = MetroFramework.MetroColorStyle.Pink;
            this.bRTidy.TabIndex = 22;
            this.bRTidy.Text = "정리";
            this.bRTidy.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bRTidy.UseSelectable = true;
            this.bRTidy.Click += new System.EventHandler(this.bRTidy_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(923, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "로그 분석하여 작가 숨기기";
            // 
            // tgFilterArtists
            // 
            this.tgFilterArtists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tgFilterArtists.AutoSize = true;
            this.tgFilterArtists.Location = new System.Drawing.Point(1048, 9);
            this.tgFilterArtists.Name = "tgFilterArtists";
            this.tgFilterArtists.Size = new System.Drawing.Size(80, 19);
            this.tgFilterArtists.Style = MetroFramework.MetroColorStyle.Pink;
            this.tgFilterArtists.TabIndex = 5;
            this.tgFilterArtists.Text = "Off";
            this.tgFilterArtists.UseSelectable = true;
            this.tgFilterArtists.CheckedChanged += new System.EventHandler(this.tgFilterArtists_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.이미지로저장SToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 26);
            // 
            // 이미지로저장SToolStripMenuItem
            // 
            this.이미지로저장SToolStripMenuItem.Enabled = false;
            this.이미지로저장SToolStripMenuItem.Name = "이미지로저장SToolStripMenuItem";
            this.이미지로저장SToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.이미지로저장SToolStripMenuItem.Text = "이미지로 저장(&S)";
            this.이미지로저장SToolStripMenuItem.Click += new System.EventHandler(this.이미지로저장SToolStripMenuItem_Click);
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.bRelatedTags);
            this.metroTabPage3.Controls.Add(this.bStat);
            this.metroTabPage3.Controls.Add(this.bDetailSetting);
            this.metroTabPage3.Controls.Add(this.label2);
            this.metroTabPage3.Controls.Add(this.tgAutoZip);
            this.metroTabPage3.Controls.Add(this.bSync);
            this.metroTabPage3.Controls.Add(this.lThread);
            this.metroTabPage3.Controls.Add(this.vThread);
            this.metroTabPage3.Controls.Add(this.metroLabel7);
            this.metroTabPage3.Controls.Add(this.metroLabel6);
            this.metroTabPage3.Controls.Add(this.cbLanguage);
            this.metroTabPage3.Controls.Add(this.tbInfo);
            this.metroTabPage3.Controls.Add(this.tbExcludeTag);
            this.metroTabPage3.Controls.Add(this.metroLabel5);
            this.metroTabPage3.Controls.Add(this.tbDownloadPath);
            this.metroTabPage3.Controls.Add(this.metroLabel4);
            this.metroTabPage3.Controls.Add(this.pbSync);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 2;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(1128, 509);
            this.metroTabPage3.TabIndex = 3;
            this.metroTabPage3.Text = "설정";
            this.metroTabPage3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // bRelatedTags
            // 
            this.bRelatedTags.Enabled = false;
            this.bRelatedTags.Location = new System.Drawing.Point(214, 26);
            this.bRelatedTags.Name = "bRelatedTags";
            this.bRelatedTags.Size = new System.Drawing.Size(84, 32);
            this.bRelatedTags.Style = MetroFramework.MetroColorStyle.Pink;
            this.bRelatedTags.TabIndex = 22;
            this.bRelatedTags.Text = "연관태그";
            this.bRelatedTags.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bRelatedTags.UseSelectable = true;
            this.bRelatedTags.Click += new System.EventHandler(this.bRelatedTags_Click);
            // 
            // bStat
            // 
            this.bStat.Enabled = false;
            this.bStat.Location = new System.Drawing.Point(124, 26);
            this.bStat.Name = "bStat";
            this.bStat.Size = new System.Drawing.Size(84, 32);
            this.bStat.Style = MetroFramework.MetroColorStyle.Pink;
            this.bStat.TabIndex = 21;
            this.bStat.Text = "통계";
            this.bStat.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bStat.UseSelectable = true;
            this.bStat.Click += new System.EventHandler(this.bStat_Click);
            // 
            // bDetailSetting
            // 
            this.bDetailSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bDetailSetting.Enabled = false;
            this.bDetailSetting.Location = new System.Drawing.Point(679, 26);
            this.bDetailSetting.Name = "bDetailSetting";
            this.bDetailSetting.Size = new System.Drawing.Size(146, 32);
            this.bDetailSetting.Style = MetroFramework.MetroColorStyle.Pink;
            this.bDetailSetting.TabIndex = 19;
            this.bDetailSetting.Text = "고급 설정";
            this.bDetailSetting.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bDetailSetting.UseSelectable = true;
            this.bDetailSetting.Click += new System.EventHandler(this.bDetailSetting_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(878, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "자동 압축";
            // 
            // tgAutoZip
            // 
            this.tgAutoZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tgAutoZip.AutoSize = true;
            this.tgAutoZip.Location = new System.Drawing.Point(912, 397);
            this.tgAutoZip.Name = "tgAutoZip";
            this.tgAutoZip.Size = new System.Drawing.Size(80, 19);
            this.tgAutoZip.Style = MetroFramework.MetroColorStyle.Pink;
            this.tgAutoZip.TabIndex = 17;
            this.tgAutoZip.Text = "Off";
            this.tgAutoZip.UseSelectable = true;
            this.tgAutoZip.CheckedChanged += new System.EventHandler(this.tgAutoZip_CheckedChanged);
            // 
            // bSync
            // 
            this.bSync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSync.Enabled = false;
            this.bSync.Location = new System.Drawing.Point(831, 26);
            this.bSync.Name = "bSync";
            this.bSync.Size = new System.Drawing.Size(161, 32);
            this.bSync.Style = MetroFramework.MetroColorStyle.Pink;
            this.bSync.TabIndex = 16;
            this.bSync.Text = "데이터 동기화";
            this.bSync.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bSync.UseSelectable = true;
            this.bSync.Click += new System.EventHandler(this.bSync_ClickAsync);
            // 
            // lThread
            // 
            this.lThread.AutoSize = true;
            this.lThread.Location = new System.Drawing.Point(238, 136);
            this.lThread.Name = "lThread";
            this.lThread.Size = new System.Drawing.Size(23, 19);
            this.lThread.Style = MetroFramework.MetroColorStyle.Pink;
            this.lThread.TabIndex = 15;
            this.lThread.Text = "32";
            // 
            // vThread
            // 
            this.vThread.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vThread.BackColor = System.Drawing.Color.Transparent;
            this.vThread.Location = new System.Drawing.Point(267, 134);
            this.vThread.Maximum = 64;
            this.vThread.Minimum = 1;
            this.vThread.Name = "vThread";
            this.vThread.Size = new System.Drawing.Size(725, 23);
            this.vThread.Style = MetroFramework.MetroColorStyle.Pink;
            this.vThread.TabIndex = 14;
            this.vThread.Text = "Thread";
            this.vThread.Value = 32;
            this.vThread.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vThread_Scroll);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(152, 136);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(80, 19);
            this.metroLabel7.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "쓰레드 수 : ";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(374, 32);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(48, 19);
            this.metroLabel6.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "언어 : ";
            // 
            // cbLanguage
            // 
            this.cbLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.ItemHeight = 23;
            this.cbLanguage.Location = new System.Drawing.Point(428, 26);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(227, 29);
            this.cbLanguage.Style = MetroFramework.MetroColorStyle.Pink;
            this.cbLanguage.TabIndex = 11;
            this.cbLanguage.UseSelectable = true;
            this.cbLanguage.SelectedIndexChanged += new System.EventHandler(this.cbLanguage_SelectedIndexChanged);
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbInfo.CustomButton.Image = null;
            this.tbInfo.CustomButton.Location = new System.Drawing.Point(636, 1);
            this.tbInfo.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbInfo.CustomButton.Name = "";
            this.tbInfo.CustomButton.Size = new System.Drawing.Size(231, 185);
            this.tbInfo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbInfo.CustomButton.TabIndex = 1;
            this.tbInfo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbInfo.CustomButton.UseSelectable = true;
            this.tbInfo.CustomButton.Visible = false;
            this.tbInfo.Lines = new string[0];
            this.tbInfo.Location = new System.Drawing.Point(124, 158);
            this.tbInfo.MaxLength = 32767;
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.PasswordChar = '\0';
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.SelectedText = "";
            this.tbInfo.SelectionLength = 0;
            this.tbInfo.SelectionStart = 0;
            this.tbInfo.ShortcutsEnabled = true;
            this.tbInfo.Size = new System.Drawing.Size(868, 233);
            this.tbInfo.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbInfo.TabIndex = 10;
            this.tbInfo.UseSelectable = true;
            this.tbInfo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbInfo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbExcludeTag
            // 
            this.tbExcludeTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbExcludeTag.CustomButton.Image = null;
            this.tbExcludeTag.CustomButton.Location = new System.Drawing.Point(732, 1);
            this.tbExcludeTag.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbExcludeTag.CustomButton.Name = "";
            this.tbExcludeTag.CustomButton.Size = new System.Drawing.Size(21, 17);
            this.tbExcludeTag.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbExcludeTag.CustomButton.TabIndex = 1;
            this.tbExcludeTag.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbExcludeTag.CustomButton.UseSelectable = true;
            this.tbExcludeTag.CustomButton.Visible = false;
            this.tbExcludeTag.Lines = new string[] {
        "female:mother, male:anal"};
            this.tbExcludeTag.Location = new System.Drawing.Point(238, 110);
            this.tbExcludeTag.MaxLength = 32767;
            this.tbExcludeTag.Name = "tbExcludeTag";
            this.tbExcludeTag.PasswordChar = '\0';
            this.tbExcludeTag.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbExcludeTag.SelectedText = "";
            this.tbExcludeTag.SelectionLength = 0;
            this.tbExcludeTag.SelectionStart = 0;
            this.tbExcludeTag.ShortcutsEnabled = true;
            this.tbExcludeTag.Size = new System.Drawing.Size(754, 23);
            this.tbExcludeTag.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbExcludeTag.TabIndex = 8;
            this.tbExcludeTag.Text = "female:mother, male:anal";
            this.tbExcludeTag.UseSelectable = true;
            this.tbExcludeTag.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbExcludeTag.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(138, 112);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(94, 19);
            this.metroLabel5.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "제외할 태그 : ";
            // 
            // tbDownloadPath
            // 
            this.tbDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.tbDownloadPath.CustomButton.Image = null;
            this.tbDownloadPath.CustomButton.Location = new System.Drawing.Point(732, 1);
            this.tbDownloadPath.CustomButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbDownloadPath.CustomButton.Name = "";
            this.tbDownloadPath.CustomButton.Size = new System.Drawing.Size(21, 17);
            this.tbDownloadPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbDownloadPath.CustomButton.TabIndex = 1;
            this.tbDownloadPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbDownloadPath.CustomButton.UseSelectable = true;
            this.tbDownloadPath.CustomButton.Visible = false;
            this.tbDownloadPath.Lines = new string[] {
        "C:\\Hitomi\\{Artists}\\[{Id}] {Title}\\"};
            this.tbDownloadPath.Location = new System.Drawing.Point(238, 81);
            this.tbDownloadPath.MaxLength = 32767;
            this.tbDownloadPath.Name = "tbDownloadPath";
            this.tbDownloadPath.PasswordChar = '\0';
            this.tbDownloadPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbDownloadPath.SelectedText = "";
            this.tbDownloadPath.SelectionLength = 0;
            this.tbDownloadPath.SelectionStart = 0;
            this.tbDownloadPath.ShortcutsEnabled = true;
            this.tbDownloadPath.Size = new System.Drawing.Size(754, 23);
            this.tbDownloadPath.Style = MetroFramework.MetroColorStyle.Pink;
            this.tbDownloadPath.TabIndex = 6;
            this.tbDownloadPath.Text = "C:\\Hitomi\\{Artists}\\[{Id}] {Title}\\";
            this.tbDownloadPath.UseSelectable = true;
            this.tbDownloadPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbDownloadPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.tbDownloadPath.Leave += new System.EventHandler(this.tbDownloadPath_Leave);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(124, 83);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(108, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Pink;
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "다운로드 경로 : ";
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(678, 37);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(468, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Copyright (C) 2018. DCInside Programming Gallery Union. All Rights Reserved.";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(464, 19);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(111, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Memory Usage : ";
            // 
            // lMemoryUsage
            // 
            this.lMemoryUsage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lMemoryUsage.AutoSize = true;
            this.lMemoryUsage.Location = new System.Drawing.Point(581, 19);
            this.lMemoryUsage.Name = "lMemoryUsage";
            this.lMemoryUsage.Size = new System.Drawing.Size(35, 19);
            this.lMemoryUsage.TabIndex = 4;
            this.lMemoryUsage.Text = "0 KB";
            this.lMemoryUsage.Click += new System.EventHandler(this.lMemoryUsage_Click);
            // 
            // MemoryUsageUpdateTimer
            // 
            this.MemoryUsageUpdateTimer.Enabled = true;
            this.MemoryUsageUpdateTimer.Interval = 1000;
            this.MemoryUsageUpdateTimer.Tick += new System.EventHandler(this.MemoryUsageUpdateTimer_Tick);
            // 
            // speed_timer
            // 
            this.speed_timer.Enabled = true;
            this.speed_timer.Interval = 1000;
            this.speed_timer.Tick += new System.EventHandler(this.speed_timer_Tick);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(381, 192);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(367, 124);
            this.listBox1.TabIndex = 28;
            this.listBox1.Visible = false;
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // ImagePanel
            // 
            this.ImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ImagePanel.ContextMenuStrip = this.contextMenuStrip2;
            this.ImagePanel.Location = new System.Drawing.Point(3, 37);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(1122, 441);
            this.ImagePanel.TabIndex = 3;
            // 
            // RecommendPannel
            // 
            this.RecommendPannel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecommendPannel.AutoScroll = true;
            this.RecommendPannel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.RecommendPannel.ContextMenuStrip = this.contextMenuStrip1;
            this.RecommendPannel.Location = new System.Drawing.Point(3, 34);
            this.RecommendPannel.Name = "RecommendPannel";
            this.RecommendPannel.Size = new System.Drawing.Size(1122, 471);
            this.RecommendPannel.TabIndex = 4;
            // 
            // pbSync
            // 
            this.pbSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSync.Location = new System.Drawing.Point(193, 439);
            this.pbSync.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbSync.Name = "pbSync";
            this.pbSync.Size = new System.Drawing.Size(709, 12);
            this.pbSync.TabIndex = 5;
            this.pbSync.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 616);
            this.Controls.Add(this.lMemoryUsage);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.MainTab);
            this.DoubleBuffered = false;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1156, 616);
            this.Name = "frmMain";
            this.Padding = new System.Windows.Forms.Padding(20, 75, 20, 25);
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "Hitomi Copy ";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MainTab.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage4.ResumeLayout(false);
            this.metroTabPage4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.metroTabPage3.ResumeLayout(false);
            this.metroTabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl MainTab;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private Hitomi_Copy_2.ScrollFixLayoutPanel ImagePanel;
        private MetroFramework.Controls.MetroButton bSearch;
        private MetroFramework.Controls.MetroTextBox tbSearch;
        private MetroFramework.Controls.MetroButton bDownload;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox tbLang;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.ListView lvStandBy;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MetroFramework.Controls.MetroProgressBar pbLoad;
        private MetroFramework.Controls.MetroButton bTidy;
        private MetroFramework.Controls.MetroButton bChooseAll;
        private MetroFramework.Controls.MetroButton bCancleAll;
        private MetroFramework.Controls.MetroProgressBar pbTarget;
        private MetroFramework.Controls.MetroLabel lStatusSearch;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel lMemoryUsage;
        private System.Windows.Forms.Timer MemoryUsageUpdateTimer;
        private MetroFramework.Controls.MetroTextBox tbDownloadPath;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox tbExcludeTag;
        private MetroFramework.Controls.MetroTextBox tbInfo;
        private MetroFramework.Controls.MetroComboBox cbLanguage;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTrackBar vThread;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel lThread;
        private MetroFramework.Controls.MetroButton bSync;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel lStatus;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel lDownloadSize;
        private MetroFramework.Controls.MetroLabel lDownloadStatusSize;
        private MetroFramework.Controls.MetroLabel lRetry;
        private MetroFramework.Controls.MetroButton bAbort;
        private MarqueeColorBar pbSync;
        private MetroFramework.Controls.MetroTabPage metroTabPage4;
        private Hitomi_Copy_2.ScrollFixLayoutPanel RecommendPannel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 이미지로저장SToolStripMenuItem;
        private Hitomi_Copy_2.AutoCompleteListBox listBox1;
        private MetroFramework.Controls.MetroToggle tgFilterArtists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroToggle tgAutoZip;
        private MetroFramework.Controls.MetroButton bDetailSetting;
        private MetroFramework.Controls.MetroLabel lDownloadSpeed;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private System.Windows.Forms.Timer speed_timer;
        private MetroFramework.Controls.MetroButton bStat;
        private MetroFramework.Controls.MetroButton bRTidy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 제목비슷한작품정리TToolStripMenuItem;
        private MetroFramework.Controls.MetroButton bRelatedTags;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem finder열기FToolStripMenuItem;
        private MetroFramework.Controls.MetroButton bCustomRecommend;
    }
}

