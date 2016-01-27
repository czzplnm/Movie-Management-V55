namespace Movie_Management
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.labelSearching = new System.Windows.Forms.Label();
            this.labelCrawledCount = new System.Windows.Forms.Label();
            this.labelCrawledGenres = new System.Windows.Forms.Label();
            this.labelMoviesInView = new System.Windows.Forms.Label();
            this.buttonCrawl = new System.Windows.Forms.Button();
            this.textBoxMoviesPerPage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.labelListViewType = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxStats = new System.Windows.Forms.GroupBox();
            this.textBoxDesciption = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.centerPb = new System.Windows.Forms.PictureBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.labelTotalMovies = new System.Windows.Forms.Label();
            this.labelRunTime = new System.Windows.Forms.Label();
            this.labelCurrentGenre = new System.Windows.Forms.Label();
            this.labelCurrentMovie = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelLastWatchedMovie = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.dgwMyVideos = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxReplacePeriods = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreSamples = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.dgwVideoFolders = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
         //   this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.button5 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxSetMovieFocus = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreMovies = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreTVShows = new System.Windows.Forms.CheckBox();
            this.button14 = new System.Windows.Forms.Button();
            this.labelTotalMyVideos = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.imageListMyMoviesLarge = new System.Windows.Forms.ImageList(this.components);
            this.processSettings = new System.ComponentModel.BackgroundWorker();
            this.bgwCrawlIMDB = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadImages = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadData = new System.ComponentModel.BackgroundWorker();
            this.timerImdbCrawler = new System.Windows.Forms.Timer(this.components);
            this.bgwFindVideos = new System.ComponentModel.BackgroundWorker();
            this.bgwCrawlDirectory = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadMyMovies = new System.ComponentModel.BackgroundWorker();
            this.bgwPopulateMyMovies = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxStats.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.centerPb)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMyVideos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVideoFolders)).BeginInit();
            this.tabPage3.SuspendLayout();
          //  ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1296, 864);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBoxStats);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1288, 838);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View Movies";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(171, 3);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = true;
            this.listView1.Size = new System.Drawing.Size(646, 832);
            this.listView1.SmallImageList = this.imageList2;
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listView1_ItemMouseHover);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button16);
            this.groupBox1.Controls.Add(this.button15);
            this.groupBox1.Controls.Add(this.labelResult);
            this.groupBox1.Controls.Add(this.labelSearching);
            this.groupBox1.Controls.Add(this.labelCrawledCount);
            this.groupBox1.Controls.Add(this.labelCrawledGenres);
            this.groupBox1.Controls.Add(this.labelMoviesInView);
            this.groupBox1.Controls.Add(this.buttonCrawl);
            this.groupBox1.Controls.Add(this.textBoxMoviesPerPage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.domainUpDown1);
            this.groupBox1.Controls.Add(this.labelListViewType);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 832);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "To be determined";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button16.Location = new System.Drawing.Point(132, 774);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(30, 23);
            this.button16.TabIndex = 12;
            this.button16.Text = "-";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.Location = new System.Drawing.Point(132, 752);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(30, 23);
            this.button15.TabIndex = 11;
            this.button15.Text = "+";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(6, 150);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(40, 13);
            this.labelResult.TabIndex = 10;
            this.labelResult.Text = "Result:";
            // 
            // labelSearching
            // 
            this.labelSearching.AutoSize = true;
            this.labelSearching.Location = new System.Drawing.Point(6, 107);
            this.labelSearching.Name = "labelSearching";
            this.labelSearching.Size = new System.Drawing.Size(58, 13);
            this.labelSearching.TabIndex = 9;
            this.labelSearching.Text = "Searching:";
            // 
            // labelCrawledCount
            // 
            this.labelCrawledCount.AutoSize = true;
            this.labelCrawledCount.Location = new System.Drawing.Point(6, 70);
            this.labelCrawledCount.Name = "labelCrawledCount";
            this.labelCrawledCount.Size = new System.Drawing.Size(65, 13);
            this.labelCrawledCount.TabIndex = 8;
            this.labelCrawledCount.Text = "Searched: 0";
            // 
            // labelCrawledGenres
            // 
            this.labelCrawledGenres.AutoSize = true;
            this.labelCrawledGenres.Location = new System.Drawing.Point(6, 89);
            this.labelCrawledGenres.Name = "labelCrawledGenres";
            this.labelCrawledGenres.Size = new System.Drawing.Size(93, 13);
            this.labelCrawledGenres.TabIndex = 7;
            this.labelCrawledGenres.Text = "Searching Genre: ";
            // 
            // labelMoviesInView
            // 
            this.labelMoviesInView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelMoviesInView.AutoSize = true;
            this.labelMoviesInView.Location = new System.Drawing.Point(0, 741);
            this.labelMoviesInView.Name = "labelMoviesInView";
            this.labelMoviesInView.Size = new System.Drawing.Size(89, 13);
            this.labelMoviesInView.TabIndex = 6;
            this.labelMoviesInView.Text = "Movies in view: 0";
            // 
            // buttonCrawl
            // 
            this.buttonCrawl.Enabled = false;
            this.buttonCrawl.Location = new System.Drawing.Point(3, 42);
            this.buttonCrawl.Name = "buttonCrawl";
            this.buttonCrawl.Size = new System.Drawing.Size(162, 25);
            this.buttonCrawl.TabIndex = 5;
            this.buttonCrawl.Text = "Start Searching";
            this.buttonCrawl.UseVisualStyleBackColor = true;
            this.buttonCrawl.Click += new System.EventHandler(this.buttonCrawl_Click);
            // 
            // textBoxMoviesPerPage
            // 
            this.textBoxMoviesPerPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMoviesPerPage.Location = new System.Drawing.Point(88, 762);
            this.textBoxMoviesPerPage.Name = "textBoxMoviesPerPage";
            this.textBoxMoviesPerPage.Size = new System.Drawing.Size(38, 20);
            this.textBoxMoviesPerPage.TabIndex = 4;
            this.textBoxMoviesPerPage.Text = "18";
            this.textBoxMoviesPerPage.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 765);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Movies Per Page:";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.domainUpDown1.Items.Add("LargeIcon");
            this.domainUpDown1.Items.Add("SmallIcon");
            this.domainUpDown1.Items.Add("Tile");
            this.domainUpDown1.Items.Add("List");
            this.domainUpDown1.Items.Add("Details");
            this.domainUpDown1.Location = new System.Drawing.Point(3, 809);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(162, 20);
            this.domainUpDown1.TabIndex = 2;
            this.domainUpDown1.Text = "LargeIcon";
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // labelListViewType
            // 
            this.labelListViewType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelListViewType.AutoSize = true;
            this.labelListViewType.Location = new System.Drawing.Point(3, 790);
            this.labelListViewType.Name = "labelListViewType";
            this.labelListViewType.Size = new System.Drawing.Size(79, 13);
            this.labelListViewType.TabIndex = 1;
            this.labelListViewType.Text = "List View Type:";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(3, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select Genre(s)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBoxStats
            // 
            this.groupBoxStats.Controls.Add(this.textBoxDesciption);
            this.groupBoxStats.Controls.Add(this.label1);
            this.groupBoxStats.Controls.Add(this.groupBoxOptions);
            this.groupBoxStats.Controls.Add(this.centerPb);
            this.groupBoxStats.Controls.Add(this.labelYear);
            this.groupBoxStats.Controls.Add(this.labelTotalMovies);
            this.groupBoxStats.Controls.Add(this.labelRunTime);
            this.groupBoxStats.Controls.Add(this.labelCurrentGenre);
            this.groupBoxStats.Controls.Add(this.labelCurrentMovie);
            this.groupBoxStats.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxStats.Location = new System.Drawing.Point(817, 3);
            this.groupBoxStats.Name = "groupBoxStats";
            this.groupBoxStats.Size = new System.Drawing.Size(468, 832);
            this.groupBoxStats.TabIndex = 1;
            this.groupBoxStats.TabStop = false;
            this.groupBoxStats.Text = "Statistics";
            // 
            // textBoxDesciption
            // 
            this.textBoxDesciption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDesciption.Location = new System.Drawing.Point(12, 521);
            this.textBoxDesciption.Multiline = true;
            this.textBoxDesciption.Name = "textBoxDesciption";
            this.textBoxDesciption.ReadOnly = true;
            this.textBoxDesciption.Size = new System.Drawing.Size(453, 127);
            this.textBoxDesciption.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Description:";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.button9);
            this.groupBoxOptions.Controls.Add(this.button8);
            this.groupBoxOptions.Controls.Add(this.button7);
            this.groupBoxOptions.Controls.Add(this.button6);
            this.groupBoxOptions.Controls.Add(this.button3);
            this.groupBoxOptions.Controls.Add(this.button2);
            this.groupBoxOptions.Location = new System.Drawing.Point(6, 654);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(462, 175);
            this.groupBoxOptions.TabIndex = 6;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(9, 136);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(218, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "Go Backward 1 Page";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(9, 106);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(218, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Go Foward 1 Page";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(233, 48);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(223, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Watch Trailer";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(233, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(223, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Blacklist";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(218, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Go Backward 1 Movie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Go Forward 1 Movie";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // centerPb
            // 
            this.centerPb.ImageLocation = "";
            this.centerPb.Location = new System.Drawing.Point(117, 107);
            this.centerPb.Name = "centerPb";
            this.centerPb.Size = new System.Drawing.Size(267, 411);
            this.centerPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.centerPb.TabIndex = 2;
            this.centerPb.TabStop = false;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(6, 55);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(32, 13);
            this.labelYear.TabIndex = 4;
            this.labelYear.Text = "Year:";
            // 
            // labelTotalMovies
            // 
            this.labelTotalMovies.AutoSize = true;
            this.labelTotalMovies.Location = new System.Drawing.Point(3, 16);
            this.labelTotalMovies.Name = "labelTotalMovies";
            this.labelTotalMovies.Size = new System.Drawing.Size(71, 13);
            this.labelTotalMovies.TabIndex = 3;
            this.labelTotalMovies.Text = "Total Movies:";
            // 
            // labelRunTime
            // 
            this.labelRunTime.AutoSize = true;
            this.labelRunTime.Location = new System.Drawing.Point(6, 42);
            this.labelRunTime.Name = "labelRunTime";
            this.labelRunTime.Size = new System.Drawing.Size(56, 13);
            this.labelRunTime.TabIndex = 2;
            this.labelRunTime.Text = "Run Time:";
            // 
            // labelCurrentGenre
            // 
            this.labelCurrentGenre.AutoSize = true;
            this.labelCurrentGenre.Location = new System.Drawing.Point(6, 29);
            this.labelCurrentGenre.Name = "labelCurrentGenre";
            this.labelCurrentGenre.Size = new System.Drawing.Size(87, 13);
            this.labelCurrentGenre.TabIndex = 1;
            this.labelCurrentGenre.Text = "Current Genre(s):";
            // 
            // labelCurrentMovie
            // 
            this.labelCurrentMovie.AutoSize = true;
            this.labelCurrentMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentMovie.Location = new System.Drawing.Point(5, 84);
            this.labelCurrentMovie.Name = "labelCurrentMovie";
            this.labelCurrentMovie.Size = new System.Drawing.Size(125, 20);
            this.labelCurrentMovie.TabIndex = 0;
            this.labelCurrentMovie.Text = "Current Movie:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1288, 838);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "My Movies";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelLastWatchedMovie);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Controls.Add(this.button11);
            this.groupBox3.Controls.Add(this.dgwMyVideos);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1282, 626);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "My Videos";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // labelLastWatchedMovie
            // 
            this.labelLastWatchedMovie.AutoSize = true;
            this.labelLastWatchedMovie.Location = new System.Drawing.Point(150, 24);
            this.labelLastWatchedMovie.Name = "labelLastWatchedMovie";
            this.labelLastWatchedMovie.Size = new System.Drawing.Size(77, 13);
            this.labelLastWatchedMovie.TabIndex = 3;
            this.labelLastWatchedMovie.Text = "Last Watched:";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(1058, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(218, 23);
            this.button12.TabIndex = 2;
            this.button12.Text = "Watch Selected Movie";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click_1);
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button11.Location = new System.Drawing.Point(6, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(138, 23);
            this.button11.TabIndex = 1;
            this.button11.Text = "Clean Movie Name";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // dgwMyVideos
            // 
            this.dgwMyVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMyVideos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column12,
            this.Column10,
            this.Column11,
            this.Column8,
            this.Column9,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgwMyVideos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgwMyVideos.Location = new System.Drawing.Point(3, 48);
            this.dgwMyVideos.MultiSelect = false;
            this.dgwMyVideos.Name = "dgwMyVideos";
            this.dgwMyVideos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgwMyVideos.Size = new System.Drawing.Size(1276, 575);
            this.dgwMyVideos.TabIndex = 0;
            this.dgwMyVideos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgwMyVideos_RowsAdded);
            this.dgwMyVideos.SelectionChanged += new System.EventHandler(this.dgwMyVideos_SelectionChanged);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "File Path";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 50;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "File Name";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 400;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Year";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Quality";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Season";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Episode";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Video Type";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Video Length";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Last Watched";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Date Added";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxReplacePeriods);
            this.groupBox2.Controls.Add(this.checkBoxIgnoreSamples);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.dgwVideoFolders);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1282, 192);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "My Video Folder(s)";
            // 
            // checkBoxReplacePeriods
            // 
            this.checkBoxReplacePeriods.AutoSize = true;
            this.checkBoxReplacePeriods.Checked = true;
            this.checkBoxReplacePeriods.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReplacePeriods.Location = new System.Drawing.Point(438, 23);
            this.checkBoxReplacePeriods.Name = "checkBoxReplacePeriods";
            this.checkBoxReplacePeriods.Size = new System.Drawing.Size(165, 17);
            this.checkBoxReplacePeriods.TabIndex = 4;
            this.checkBoxReplacePeriods.Text = "Replace Periods with Spaces";
            this.checkBoxReplacePeriods.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreSamples
            // 
            this.checkBoxIgnoreSamples.AutoSize = true;
            this.checkBoxIgnoreSamples.Checked = true;
            this.checkBoxIgnoreSamples.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIgnoreSamples.Location = new System.Drawing.Point(342, 23);
            this.checkBoxIgnoreSamples.Name = "checkBoxIgnoreSamples";
            this.checkBoxIgnoreSamples.Size = new System.Drawing.Size(99, 17);
            this.checkBoxIgnoreSamples.TabIndex = 3;
            this.checkBoxIgnoreSamples.Text = "Ignore Samples";
            this.checkBoxIgnoreSamples.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button10.Location = new System.Drawing.Point(150, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(186, 23);
            this.button10.TabIndex = 2;
            this.button10.Text = "Remove Selected Directory(s)";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // dgwVideoFolders
            // 
            this.dgwVideoFolders.AllowUserToAddRows = false;
            this.dgwVideoFolders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwVideoFolders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgwVideoFolders.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgwVideoFolders.Location = new System.Drawing.Point(3, 47);
            this.dgwVideoFolders.Name = "dgwVideoFolders";
            this.dgwVideoFolders.Size = new System.Drawing.Size(1276, 142);
            this.dgwVideoFolders.TabIndex = 1;
            this.dgwVideoFolders.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwVideoFolders_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Directory";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 650;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Movies Found";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Location = new System.Drawing.Point(5, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(139, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Add Directory";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // tabPage3
            // 
//            this.tabPage3.Controls.Add(this.axVLCPlugin21);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1288, 838);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Watch Movie";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // axVLCPlugin21
            // 
       //     this.axVLCPlugin21.Dock = System.Windows.Forms.DockStyle.Fill;
       //     this.axVLCPlugin21.Enabled = true;
       //     this.axVLCPlugin21.Location = new System.Drawing.Point(3, 26);
       //     this.axVLCPlugin21.Name = "axVLCPlugin21";
       //     this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
       //     this.axVLCPlugin21.Size = new System.Drawing.Size(1282, 809);
       //     this.axVLCPlugin21.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(1282, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Play";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.listView2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1288, 838);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "My Movies Big View";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxSetMovieFocus);
            this.groupBox4.Controls.Add(this.checkBoxIgnoreMovies);
            this.groupBox4.Controls.Add(this.checkBoxIgnoreTVShows);
            this.groupBox4.Controls.Add(this.button14);
            this.groupBox4.Controls.Add(this.labelTotalMyVideos);
            this.groupBox4.Controls.Add(this.button13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1282, 51);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "My Video Controls";
            // 
            // checkBoxSetMovieFocus
            // 
            this.checkBoxSetMovieFocus.AutoSize = true;
            this.checkBoxSetMovieFocus.Checked = true;
            this.checkBoxSetMovieFocus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSetMovieFocus.Location = new System.Drawing.Point(471, 23);
            this.checkBoxSetMovieFocus.Name = "checkBoxSetMovieFocus";
            this.checkBoxSetMovieFocus.Size = new System.Drawing.Size(150, 17);
            this.checkBoxSetMovieFocus.TabIndex = 5;
            this.checkBoxSetMovieFocus.Text = "Set focus on added movie";
            this.checkBoxSetMovieFocus.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreMovies
            // 
            this.checkBoxIgnoreMovies.AutoSize = true;
            this.checkBoxIgnoreMovies.Location = new System.Drawing.Point(381, 23);
            this.checkBoxIgnoreMovies.Name = "checkBoxIgnoreMovies";
            this.checkBoxIgnoreMovies.Size = new System.Drawing.Size(93, 17);
            this.checkBoxIgnoreMovies.TabIndex = 4;
            this.checkBoxIgnoreMovies.Text = "Ignore Movies";
            this.checkBoxIgnoreMovies.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreTVShows
            // 
            this.checkBoxIgnoreTVShows.AutoSize = true;
            this.checkBoxIgnoreTVShows.Location = new System.Drawing.Point(267, 23);
            this.checkBoxIgnoreTVShows.Name = "checkBoxIgnoreTVShows";
            this.checkBoxIgnoreTVShows.Size = new System.Drawing.Size(108, 17);
            this.checkBoxIgnoreTVShows.TabIndex = 3;
            this.checkBoxIgnoreTVShows.Text = "Ignore TV Shows";
            this.checkBoxIgnoreTVShows.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(83, 19);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 2;
            this.button14.Text = "Clear";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // labelTotalMyVideos
            // 
            this.labelTotalMyVideos.AutoSize = true;
            this.labelTotalMyVideos.Location = new System.Drawing.Point(164, 24);
            this.labelTotalMyVideos.Name = "labelTotalMyVideos";
            this.labelTotalMyVideos.Size = new System.Drawing.Size(68, 13);
            this.labelTotalMyVideos.TabIndex = 1;
            this.labelTotalMyVideos.Text = "My Videos: 0";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 19);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(71, 23);
            this.button13.TabIndex = 0;
            this.button13.Text = "Load";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.LargeImageList = this.imageListMyMoviesLarge;
            this.listView2.Location = new System.Drawing.Point(3, 60);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1282, 775);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // imageListMyMoviesLarge
            // 
            this.imageListMyMoviesLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListMyMoviesLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListMyMoviesLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // processSettings
            // 
            this.processSettings.DoWork += new System.ComponentModel.DoWorkEventHandler(this.processSettings_DoWork);
            // 
            // bgwCrawlIMDB
            // 
            this.bgwCrawlIMDB.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadMovies_DoWork);
            // 
            // bgwLoadImages
            // 
            this.bgwLoadImages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadImages_DoWork);
            // 
            // bgwLoadData
            // 
            this.bgwLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadData_DoWork);
            // 
            // timerImdbCrawler
            // 
            this.timerImdbCrawler.Tick += new System.EventHandler(this.timerImdbCrawler_Tick);
            // 
            // bgwFindVideos
            // 
            this.bgwFindVideos.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFindVideos_DoWork);
            // 
            // bgwCrawlDirectory
            // 
            this.bgwCrawlDirectory.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCrawlDirectory_DoWork);
            // 
            // bgwLoadMyMovies
            // 
            this.bgwLoadMyMovies.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadMyMovies_DoWork);
            // 
            // bgwPopulateMyMovies
            // 
            this.bgwPopulateMyMovies.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwPopulateMyMovies_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 864);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Movie Management";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxStats.ResumeLayout(false);
            this.groupBoxStats.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.centerPb)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMyVideos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwVideoFolders)).EndInit();
            this.tabPage3.ResumeLayout(false);
         //   ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.ComponentModel.BackgroundWorker processSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxStats;
        private System.Windows.Forms.PictureBox centerPb;
        private System.Windows.Forms.Label labelCurrentGenre;
        private System.Windows.Forms.Label labelCurrentMovie;
        private System.ComponentModel.BackgroundWorker bgwCrawlIMDB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelRunTime;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Label labelTotalMovies;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button5;
      //  private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelListViewType;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.ComponentModel.BackgroundWorker bgwLoadImages;
        private System.ComponentModel.BackgroundWorker bgwLoadData;
        private System.Windows.Forms.TextBox textBoxDesciption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBoxMoviesPerPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCrawl;
        private System.Windows.Forms.Timer timerImdbCrawler;
        private System.Windows.Forms.Label labelMoviesInView;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label labelCrawledCount;
        private System.Windows.Forms.Label labelCrawledGenres;
        private System.Windows.Forms.Label labelSearching;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgwVideoFolders;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.ComponentModel.BackgroundWorker bgwFindVideos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DataGridView dgwMyVideos;
        private System.Windows.Forms.CheckBox checkBoxIgnoreSamples;
        private System.ComponentModel.BackgroundWorker bgwCrawlDirectory;
        private System.Windows.Forms.CheckBox checkBoxReplacePeriods;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ImageList imageListMyMoviesLarge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.ComponentModel.BackgroundWorker bgwLoadMyMovies;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label labelTotalMyVideos;
        private System.ComponentModel.BackgroundWorker bgwPopulateMyMovies;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.CheckBox checkBoxIgnoreMovies;
        private System.Windows.Forms.CheckBox checkBoxIgnoreTVShows;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label labelLastWatchedMovie;
        private System.Windows.Forms.CheckBox checkBoxSetMovieFocus;
     
    }
}

