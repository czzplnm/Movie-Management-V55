using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Movie_Management
{
    public partial class MovieCleaner : Form
    {
        public static string renamedMovie { get; set; }
        public static bool Modified = false;
        string originalPathName;
        string originalPath;

        public static string[] qualities = new string[] { "120p", "320p", "420p", "720p", "1080p", "1080i", "2160p" };

        public MovieCleaner(DataGridViewRow row)
        {
            InitializeComponent();
            Modified = false;
            originalPath = row.Cells[0].Value.ToString();
            
            renamedMovie = originalPath;

            string Year = row.Cells[2].Value.ToString();
            string Quality = row.Cells[3].Value.ToString();

            textBoxPath.Text = row.Cells[0].Value.ToString();
            textBoxYear.Text = Year;
            textBoxQuality.Text = Quality;
            textBoxSeason.Text = row.Cells[4].Value.ToString();
            textBoxEpisode.Text = row.Cells[5].Value.ToString();            
           
            originalPathName = Regex.Replace(originalPath, "[A-Za-z](.*)\\\\", "");

            Match Season = Regex.Match(originalPathName, "S[0-9]{1,2}", RegexOptions.IgnoreCase);
            if (Season.Success)
            {
                textBoxSeason.Text = Season.Value.ToString();
            }

            Match Episode = Regex.Match(originalPathName, "E[0-9]{1,2}", RegexOptions.IgnoreCase);
            if (Episode.Success)
            {
                textBoxEpisode.Text = Episode.Value.ToString();
            }

            if(textBoxYear.Text == "")
            {
            MatchCollection hasYear = Regex.Matches(originalPathName, "[0-9]{4}");
            for(int i = 0; i < hasYear.Count; i++)
            {
                int Value = Convert.ToInt16(hasYear[i].Value);
                if (Value > 1800 && Value < 2050)
                {
                    textBoxYear.Text = Value.ToString();
                    string yearFormat = "(" + Value.ToString() + ")";
                    Year = yearFormat;
                    originalPathName = originalPathName.Replace(Value.ToString(), yearFormat);
                }
            }
            }
            if(textBoxQuality.Text == "")
            {
            for (int i = 0; i < qualities.Length; i++)
            {
                Match qualityExists = Regex.Match(originalPathName, qualities[i], RegexOptions.IgnoreCase);
                if (qualityExists.Success)
                {
                    textBoxQuality.Text = qualities[i];
                    string fixedQuality = "[" + qualities[i] + "]";
                    Quality = fixedQuality;

                    originalPathName = originalPathName.Replace(qualityExists.Value.ToString(), fixedQuality);
                }
            }
            }
            textBoxVideoName.Text = originalPathName;

            int theLength = originalPathName.Length;
            string videoType = originalPathName.Substring(theLength - 4, 4);

            int PositionQual = originalPathName.IndexOf(Quality);
            int PositionYear = originalPathName.IndexOf(Year);
            int PositionSeason = originalPath.IndexOf(textBoxSeason.Text);

            if (PositionYear >= PositionQual && PositionYear >= PositionSeason)
                textBoxCleanedMovieName.Text = justMovieName(originalPathName, Year);
            else if (PositionQual >= PositionSeason && PositionQual >= PositionYear)
                textBoxCleanedMovieName.Text = justMovieNameQuality(originalPathName, Quality);
            else if (PositionSeason >= PositionQual && PositionSeason >= PositionYear)
                textBoxCleanedMovieName.Text = justMovieNameSeasons(originalPathName);

            if (Year != "")
            {
                Year = "(" + Year + ")";
                Year = Year.Replace("((", "(");
                Year = Year.Replace("))", ")");
            }
            if (Quality != "")
            {
                Quality = "[" + Quality + "]";
                Quality = Quality.Replace("[[", "[");
                Quality = Quality.Replace("]]", "]");
            }

            textBoxCleanedName.Text = textBoxCleanedMovieName.Text + " " +  textBoxSeason.Text + textBoxEpisode.Text + " " + Quality + " " +  Year + videoType;


            textBoxCleanedName.Text = textBoxCleanedName.Text.Replace("  ", " ");
        }

        public static string justMovieNameQuality(string Input, string Quality)
        {

            string justMovieName = Input;

            string regex;
            if (Quality.Contains("["))
            {
                Quality = Quality.Replace(")", "\\]");
                regex = "\\" + Quality + "(.*?)\\.";
            }
            else
                regex = "\\[" + Quality + "\\](.*?)\\.";

            Match notPartofName = Regex.Match(Input, regex);
            if (notPartofName.Success)
            {
                justMovieName = Input.Replace(notPartofName.Value.ToString(), ".");

            }

            string movieType = FindMovies.whatType(justMovieName);
            string theSpace = " " + movieType;
            justMovieName = justMovieName.Replace(theSpace, "");
            justMovieName = justMovieName.Replace(movieType, "");

            return RemoveLingering(justMovieName);

        }


        public static string justMovieNameSeasons(string Input)
        {

            string justMovieName = Input;

            string regex = "S[0-9]{1,2}E[0-9]{1,2}(.*)\\.";
            

            Match notPartofName = Regex.Match(Input, regex, RegexOptions.IgnoreCase);
            if (notPartofName.Success)
            {
                justMovieName = Input.Replace(notPartofName.Value.ToString(), ".");

            }

            string movieType = FindMovies.whatType(justMovieName);
            string theSpace = " " + movieType;
            justMovieName = justMovieName.Replace(theSpace, "");
            justMovieName = justMovieName.Replace(movieType, "");

            return RemoveLingering(justMovieName);

        }

        public static string RemoveLingering(string Input)
        {
            Match Quality = Regex.Match(Input, "\\[(.*?)\\]");
            if (Quality.Success)
            {
                Input = Input.Replace(Quality.Value.ToString(), "");
            }
            Match Year = Regex.Match(Input, "\\((.*?)\\)");
            if (Year.Success)
            {
                Input = Input.Replace(Year.Value.ToString(), "");
            }

            Match SeasonEpisode = Regex.Match(Input, "S[0-9]{1,2}E[0-9]{1,2}", RegexOptions.IgnoreCase);
            if (SeasonEpisode.Success)
            {
                Input = Input.Replace(SeasonEpisode.Value.ToString(), "");
            }

          
            return Input;
        }
        public static string justMovieName(string Input, string Year)
        {

            string justMovieName = Input;

            string regex;
            if (Year.Contains("("))
            {
                Year = Year.Replace(")", "\\)");
                regex = "\\" + Year + "(.*?)\\.";
            }
            else
                regex = "\\(" + Year + "\\)(.*?)\\.";

            Match notPartofName = Regex.Match(Input, regex);
            if (notPartofName.Success)
            {
                justMovieName = Input.Replace(notPartofName.Value.ToString(), ".");
                
            }

            string movieType = FindMovies.whatType(justMovieName);
            string theSpace = " " + movieType;
            justMovieName = justMovieName.Replace(theSpace, "");
            justMovieName = justMovieName.Replace(movieType, "");

            return RemoveLingering(justMovieName);
                
        }

        private void MovieCleaner_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Match findDirectory = Regex.Match(originalPath, "[A-Za-z](.*)\\\\", RegexOptions.IgnoreCase);
            if(findDirectory.Success)
            {
                string newPathAndName = findDirectory.Value.ToString() + textBoxVideoName.Text;
                File.Move(originalPath, newPathAndName);
                renamedMovie = newPathAndName;
                Modified = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Match findDirectory = Regex.Match(originalPath, "[A-Za-z](.*)\\\\", RegexOptions.IgnoreCase);
            if (findDirectory.Success)
            {
                string newPathAndName = findDirectory.Value.ToString() + textBoxCleanedName.Text;
                File.Move(originalPath, newPathAndName);
                renamedMovie = newPathAndName;
                Modified = true;
                this.Close();
            }
        }
    }
}
