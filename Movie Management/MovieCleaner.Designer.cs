namespace Movie_Management
{
    partial class MovieCleaner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieCleaner));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSeason = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEpisode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxVideoName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxQuality = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCleanedMovieName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCleanedName = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Enabled = false;
            this.textBoxPath.Location = new System.Drawing.Point(15, 25);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(714, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Season";
            // 
            // textBoxSeason
            // 
            this.textBoxSeason.Location = new System.Drawing.Point(15, 64);
            this.textBoxSeason.Name = "textBoxSeason";
            this.textBoxSeason.Size = new System.Drawing.Size(100, 20);
            this.textBoxSeason.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Episode";
            // 
            // textBoxEpisode
            // 
            this.textBoxEpisode.Location = new System.Drawing.Point(130, 64);
            this.textBoxEpisode.Name = "textBoxEpisode";
            this.textBoxEpisode.Size = new System.Drawing.Size(100, 20);
            this.textBoxEpisode.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Year";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(248, 64);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(100, 20);
            this.textBoxYear.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "File Name";
            // 
            // textBoxVideoName
            // 
            this.textBoxVideoName.Location = new System.Drawing.Point(74, 92);
            this.textBoxVideoName.Name = "textBoxVideoName";
            this.textBoxVideoName.Size = new System.Drawing.Size(468, 20);
            this.textBoxVideoName.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(548, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Quality";
            // 
            // textBoxQuality
            // 
            this.textBoxQuality.Location = new System.Drawing.Point(354, 64);
            this.textBoxQuality.Name = "textBoxQuality";
            this.textBoxQuality.Size = new System.Drawing.Size(72, 20);
            this.textBoxQuality.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 39);
            this.label7.TabIndex = 13;
            this.label7.Text = "For the season & episode, keep the format to S00E00\r\nFor the Year, place paranthe" +
    "sis around it, like (2007)\r\nFor the quality, please square brackets around it [7" +
    "20p]";
            // 
            // textBoxCleanedMovieName
            // 
            this.textBoxCleanedMovieName.Location = new System.Drawing.Point(442, 64);
            this.textBoxCleanedMovieName.Name = "textBoxCleanedMovieName";
            this.textBoxCleanedMovieName.Size = new System.Drawing.Size(286, 20);
            this.textBoxCleanedMovieName.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(439, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Movie Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 228);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(538, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "The Movie Name text box is what will be used to search for matching videos, make " +
    "sure it is just the movie name.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "File Name";
            // 
            // textBoxCleanedName
            // 
            this.textBoxCleanedName.Location = new System.Drawing.Point(74, 118);
            this.textBoxCleanedName.Name = "textBoxCleanedName";
            this.textBoxCleanedName.Size = new System.Drawing.Size(468, 20);
            this.textBoxCleanedName.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(548, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(180, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MovieCleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 255);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxCleanedMovieName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxQuality);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxCleanedName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxVideoName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEpisode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxSeason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MovieCleaner";
            this.Text = "Movie Name Cleaner";
            this.Load += new System.EventHandler(this.MovieCleaner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSeason;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEpisode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxVideoName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxQuality;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCleanedMovieName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCleanedName;
        private System.Windows.Forms.Button button2;
    }
}