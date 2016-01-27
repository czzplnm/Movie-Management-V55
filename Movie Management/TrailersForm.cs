using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Movie_Management
{
    public partial class TrailersForm : Form
    {
        string HTML_CONTENT;
        string videosID;
        int trailerWidth = 1000;
        int trailerHeight = 740;
        public TrailersForm(string videoID, string Title)
        {
            this.Text = Title;
            videosID = videoID;
            HTML_CONTENT = "<html><iframe width=\"" + trailerWidth + "\" height=\"" + trailerHeight + "\" src=\"http://www.youtube.com/embed/" + videoID + "\"> </iframe></html>";
            InitializeComponent();
        }

        private void TrailersForm_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentText = HTML_CONTENT;
        }

        private void TrailersForm_Resize(object sender, EventArgs e)
        {
            HTML_CONTENT = "<html><iframe width=\"" + (this.Width - 64).ToString() + "\" height=\"" + (this.Height - 70).ToString() + "\" src=\"http://www.youtube.com/embed/" + videosID + "\"> </iframe></html>";
            webBrowser1.DocumentText = HTML_CONTENT;
        }
    }
}
