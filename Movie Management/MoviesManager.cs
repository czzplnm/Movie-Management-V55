using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;

namespace Movie_Management
{
    class MoviesManager
    {

       

        public static int TotalMovies { get; set; }

        public static int MyMoviesCount { get; set; }
        public static List<int> RunTime = new List<int>();
        public static List<string> Rating { get; set; }
        public static List<string> Title { get; set; }
        public static List<Int32> Year { get; set; }
        public static List<string> Description { get; set; }
        public static List<string> SmallImage { get; set; }
        public static List<string> Image { get; set; }
        public static List<string> URL { get; set; }
        public static List<string> number { get; set; }
        public static List<Array> Genres { get; set; }
        public static List<string> IMDBRating { get; set; }
        public static List<string> ComingSoon { get; set; }
        public static List<string> TheaterStatus { get; set; }
        public static List<string> Trailers { get; set; }

        public static Int32 currentPage { get; set; }


        public static Int32  CurrentMovie {get; set;}

        public static void Init()
        {
            currentPage = 0;
            Title = new List<string>();
            Year = new List<Int32>();
            MyMoviesCount = 0;
            Description = new List<string>();
            Image = new List<string>();
            SmallImage = new List<string>();
            URL = new List<string>();
            number = new List<string>();
            Rating = new List<string>();
            Genres = new List<Array>();
            IMDBRating = new List<string>();
            ComingSoon = new List<string>();
            TheaterStatus = new List<string>();
            Trailers = new List<string>();
             
            
        }

        public static void AddMovie2(string SmallImage, string Number, string Title, string Description, string CleanYear, string CleanRuntime, string URL, string Image, string Rating, string TheaterStatus, string ComingSoon, string IMDGRating, Array genres, string Trailer)
            {
                MoviesManager.SmallImage.Add(SmallImage);
                MoviesManager.number.Add(Number);
                MoviesManager.Title.Add(Title);
                MoviesManager.Description.Add(Description);
                MoviesManager.CleanYear(CleanYear);
                MoviesManager.CleanRuntime(CleanRuntime);
                MoviesManager.URL.Add(URL);
                MoviesManager.Image.Add(Image);
                MoviesManager.Rating.Add(Rating);
                MoviesManager.TheaterStatus.Add(TheaterStatus);
                MoviesManager.ComingSoon.Add(ComingSoon);
                MoviesManager.IMDBRating.Add(IMDGRating);
                MoviesManager.Genres.Add(genres);
                MoviesManager.Trailers.Add(Trailer);
                MoviesManager.TotalMovies++;
            }


        public static void AddMovie(string SmallImage, string Number, string Title, string Description, Int32 CleanYear, Int32 CleanRuntime, string URL, string Image, string Rating, string TheaterStatus, string ComingSoon, string IMDGRating, string genres, string Trailer)
        {
            /*
            Array genresArray = genres.Split('|');
            Movie aMovie = new Movie();
            aMovie.SmallImage = SmallImage;
            aMovie.number = Number;
            aMovie.Title = Title;
            aMovie.Description = Description;
            aMovie.Year = CleanYear;
            aMovie.RunTime = CleanRuntime;
            aMovie.URL = URL;
            aMovie.Image = Image;
            aMovie.Rating = Rating;
            aMovie.TheaterStatus = TheaterStatus;
            aMovie.ComingSoon = ComingSoon;
            aMovie.IMDBRating = IMDGRating;
            aMovie.Genres = genresArray;
            aMovie.Trailers = Trailer;
            string postInfo = "RunTime=" + RunTime + "&SmallImage=" + SmallImage + "&Number=" + Number + "&Title=" + Title + "&Description=" + Description + "&Year=" + CleanYear.ToString() + "&RunTime=" + CleanRuntime.ToString() + "&URL=" + URL + "&SmallImage=" + SmallImage + "&Image=" + Image + "&Rating=" + Rating + "&TheaterStatus=" + TheaterStatus + "&ComingSoon=" + ComingSoon + "&IMDBRating=" + IMDGRating + "&Genres=" + genres + "&Trailers=" + Trailer + "&Submit=AddMovie";
           
            string response = HTTP.DoPOST("https://secure2025.hostgator.com/~czzplnm/moviemanager.php", postInfo);
            Form1.MoviesCollection.Add(aMovie);

            */
        }
        /*
        public static void AddMyMovie(string SmallImage, string Number, string Title, string Description, Int32 CleanYear, Int32 CleanRuntime, string URL, string Image, string Rating, string TheaterStatus, string ComingSoon, string IMDGRating, string genres, string Trailer, string AirDate, Int16 Episode, Int16 Season, string EpisodeTitle)
        {
            Array genresArray = genres.Split('|');
            MyMovie aMovie = new MyMovie();
            aMovie.SmallImage = SmallImage;
            aMovie.number = Number;
            aMovie.Title = Title;
            aMovie.Description = Description;
            aMovie.Year = CleanYear;
            aMovie.RunTime = CleanRuntime;
            aMovie.URL = URL;
            aMovie.Image = Image;
            aMovie.Rating = Rating;
            aMovie.TheaterStatus = TheaterStatus;
            aMovie.ComingSoon = ComingSoon;
            aMovie.IMDBRating = IMDGRating;
            aMovie.Genres = genresArray;
            aMovie.Trailers = Trailer;
            aMovie.AirDate = AirDate;
            aMovie.Episode = Episode;
            aMovie.EpisodeTitle = EpisodeTitle;
            aMovie.Season = Season;

            MyMoviesCount++;
            Form1.MyMoviesCollection.Add(aMovie);
            //add to list view         
        }
          */
        public static bool BlackList(string Title, bool addBlacklist, string MyDocuments)
        {
            if (File.Exists(MyDocuments +  "BlackList\\" +Title + ".blacklist"))
                return true;

            if (addBlacklist)
            {
                File.Create(MyDocuments + "BlackList\\" + Title + ".blacklist").Dispose();
                File.Delete(MyDocuments + "images\\large\\" + Title + ".jpg");
                File.Delete(MyDocuments + "images\\small\\" + Title + ".jpg");
                File.Delete(MyDocuments + "Data\\" + Title + ".dat");
            }

            return false;
        }


        public static void RemoveMovie(int index)
        {
            Form1.MoviesCollection.RemoveAt(index);
        }

        public static void RemoveMovie2(int index)
        {
            MoviesManager.SmallImage.RemoveAt(index);
            MoviesManager.number.RemoveAt(index);
            MoviesManager.Title.RemoveAt(index);
            MoviesManager.Description.RemoveAt(index);
            MoviesManager.Year.RemoveAt(index);
            MoviesManager.RunTime.RemoveAt(index);
            MoviesManager.URL.RemoveAt(index);
            MoviesManager.Image.RemoveAt(index);
            MoviesManager.Rating.RemoveAt(index);
            MoviesManager.TheaterStatus.RemoveAt(index);
            MoviesManager.ComingSoon.RemoveAt(index);
            MoviesManager.IMDBRating.RemoveAt(index);
            MoviesManager.Genres.RemoveAt(index);
            MoviesManager.TotalMovies--;
        }

        public static Int32 CleanYear(string yearString)
        {
            Match FindDigit = Regex.Match(yearString, "[0-9]{1,30}");
            if (FindDigit.Success)
                return Convert.ToInt32(FindDigit.Value.ToString());
            else
                return 0;

        }

        public static Int32 CleanRuntime(string runTimeString)
        {
            Match FindDigit = Regex.Match(runTimeString, "[0-9]{1,30}");
            if (FindDigit.Success)
                return Convert.ToInt32(FindDigit.Value.ToString());
            else
                return 0;

        }


        public static void CleanYear2(string yearString)
        {
            Match FindDigit = Regex.Match(yearString, "[0-9]{1,30}");
            if (FindDigit.Success)
                Year.Add(Convert.ToInt32(FindDigit.Value.ToString()));
         
        }

        public static void CleanRuntime2(string runTimeString)
        {
            Match FindDigit = Regex.Match(runTimeString, "[0-9]{1,30}");
            if (FindDigit.Success)
                RunTime.Add(Convert.ToInt32(FindDigit.Value.ToString()));
            
        }
    }
}
