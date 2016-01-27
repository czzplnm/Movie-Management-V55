using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Search;

namespace Movie_Management
{
    public class MyMovie
    {
        public int RunTime { get; set; }
        public string Rating { get; set; }
        public string Title { get; set; }
        public Int32 Year { get; set; }
        public string Description { get; set; }
        public string SmallImage { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
        public Int32 number { get; set; }
        public string imdb_number { get; set; }
        public Array Genres { get; set; }
        public string IMDBRating { get; set; }
        public string ComingSoon { get; set; }
        public string TheaterStatus { get; set; }
        public string Trailers { get; set; }
        public string EpisodeTitle { get; set; }
        public string SeasonCover { get; set; }
        public Int16 Episode { get; set; }
        public Int16 Season { get; set; }
        public string AirDate { get; set; }
        public bool loaded = false;
        public static string movieDbApiKey = "deb9b3e3445df11f1f659a35c57dcea5";
        public string base_url = null;
        public bool isMovie = false;
        public bool themoviedb = false;
      
        public static int index = 0;
        public mType movieType;
        public enum mType { imdb, themoviedbMovie, themoviedbTV, mymobster, ondisk };
        public void loadConfig()
        {
            if (base_url == null)
            {
                string URL = "http://api.themoviedb.org/3/configuration?api_key=" + movieDbApiKey;
                string Response = HTTP.DoGET(URL);
                
                JObject configuration = JObject.Parse(Response);
                JToken baseURL = configuration.SelectToken("images");
                base_url = baseURL.SelectToken("base_url").ToString();
            }
        }

        public void loadMovieID(string Name)
        {
            string URL = "http://api.themoviedb.org/3/search/movie?api_key=" + movieDbApiKey + "&query=" + Name;
            string Response = HTTP.DoGET(URL);
            JObject videoObject = JObject.Parse(Response);
            JToken totalResults = videoObject.SelectToken("total_results");
            string total_results = totalResults.ToString();
            if (total_results != "0")
            {
                JToken movieToken = videoObject.SelectToken("results").First;
                //tv show not found found
               // isMovie = true;
               // themoviedb = true;
                imdb_number = movieToken.SelectToken("id").ToString();
                Image = base_url + "w780" + movieToken.SelectToken("poster_path").ToString();
                movieType = mType.themoviedbMovie;
                IncrementNumber();
            }
        }

        public void IncrementNumber()
        {
            this.number = index;
            index++;
        }

        public bool loadTvShowID(string Name)
        {
            /*
            string URL = "http://api.themoviedb.org/3/search/movie?api_key=" + movieDbApiKey + "&query=" + Name;
            string Response = HTTP.DoGET(URL);
            videoObject = JObject.Parse(Response);
            JToken totalResults = videoObject.SelectToken("total_results");
            string total_results = totalResults.ToString();
            if (total_results == "0")
            {
                */
                //Might be a TV show series
                string URL = "http://api.themoviedb.org/3/search/tv?api_key=" + movieDbApiKey + "&query=" + Name;
                string Response = HTTP.DoGET(URL);
                JObject tvObject = JObject.Parse(Response);
                string total_results = tvObject.SelectToken("total_results").ToString();
                if (total_results != "0")
                {
                 
                    JToken tvToken = tvObject.SelectToken("results").First;
                    Image = base_url + "w780" + tvToken.SelectToken("poster_path").ToString();
                    movieType = mType.themoviedbTV;
                   // isMovie = false;                   
                    if (tvToken != null)
                    {
                        imdb_number = tvToken.SelectToken("id").ToString();
                        IncrementNumber();
                        /*
                        //search again using ID
                        URL = "http://api.themoviedb.org/3/tv/" + ID + "/season/" + Season + "/episode/" + Episode + "?api_key=" + movieDbApiKey;
                        Response = http.DoGET(URL);
                        JToken finalObject = JToken.Parse(Response);
                        Description = finalObject.SelectToken("overview").ToString();
                        TheEpisodeTitle = finalObject.SelectToken("name").ToString();
                        TheAirDate = finalObject.SelectToken("air_date").ToString();
                        Season = finalObject.SelectToken("episode_number").ToString();
                        theYear = Convert.ToInt16(TheAirDate.Substring(0, 4));
                        number = finalObject.SelectToken("id").ToString();
                        string ybrResponse = YouTube.SearchYouTube(Name + " trailer");

                        if (ybrResponse.Length <= 30)
                            Trailers = ybrResponse;
                        */
                        return true;
                    }
                }//end of second total results          
                return false;
        }

        private static void FetchConfig(TMDbClient client)
        {
            FileInfo configXml = new FileInfo("config.xml");

            Console.WriteLine("Config file: " + configXml.FullName + ", Exists: " + configXml.Exists);

            if (configXml.Exists && configXml.LastWriteTimeUtc >= DateTime.UtcNow.AddHours(-1))
            {
                Console.WriteLine("Using stored config");
                string xml = File.ReadAllText(configXml.FullName, Encoding.Unicode);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                client.SetConfig(Serializer.Deserialize<TMDbConfig>(xmlDoc));
            }
            else
            {
                Console.WriteLine("Getting new config");
                client.GetConfig();

                Console.WriteLine("Storing config");
                XmlDocument xmlDoc = Serializer.Serialize(client.Config);
                File.WriteAllText(configXml.FullName, xmlDoc.OuterXml, Encoding.Unicode);
            }

        }
        private  void createMyMovie(string SmallImage, string Number, string Title, string Description, Int32 CleanYear, Int32 CleanRuntime, string URL, string Image, string Rating, string TheaterStatus, string ComingSoon, string IMDGRating, string genres, string Trailer, string EpisodeTitle, string AirDate, Int16 Episode, Int16 Season, string SeasonCover)
        {
            Array genresArray = genres.Split('|');
            
            this.SmallImage = SmallImage;
            this.imdb_number = Number;
            this.Title = Title;
            this.Description = Description;
            this.Year = CleanYear;
            this.RunTime = CleanRuntime;
            this.URL = URL;
            this.Image = Image;
            this.Rating = Rating;
            this.TheaterStatus = TheaterStatus;
            this.ComingSoon = ComingSoon;
            this.IMDBRating = IMDGRating;
            this.Genres = genresArray;
            this.Trailers = Trailer;
            this.EpisodeTitle = EpisodeTitle;
            this.AirDate = AirDate;
            this.Episode = Episode;
            this.Season = Season;
            this.SeasonCover = SeasonCover;
            
            IncrementNumber();
            MoviesManager.MyMoviesCount++;
           

        }

        public bool loadMovieDB(string Name)
        {
            return false;
        }

        public bool loadOMDB(string Name)
        {
          
            //search omdb api
            string URL = "http://www.omdbapi.com/?t=" + Name + "&y=JSON&tomatoes=true";
            string Response = HTTP.DoGET(URL);
            JObject parsed = JObject.Parse(Response);
            JToken token = parsed.First;

            return false;
        }

        private static TMDbClient client = new TMDbClient("deb9b3e3445df11f1f659a35c57dcea5");
        public static Uri lastImage = null;
        public static TMDbLib.Objects.Movies.Movie loadTMDbLib(string Name)
        {            
            FetchConfig(client);
            SearchContainer<SearchMovie> results = client.SearchMovie(Name).Result;
            foreach (SearchMovie result in results.Results.Take(1))
            {
                lastImage = FetchImages(result.Id);
                return FetchMovie(result.Id);
                //FetchImages(client, result.Id, myForm);
                /*
                Console.WriteLine(result.Id + ": " + result.Title);
                Console.WriteLine("\t Original Title: " + result.OriginalTitle);
                Console.WriteLine("\t Release date  : " + result.ReleaseDate);
                Console.WriteLine("\t Popularity    : " + result.Popularity);
                Console.WriteLine("\t Vote Average  : " + result.VoteAverage);
                Console.WriteLine("\t Vote Count    : " + result.VoteCount);
                Console.WriteLine();
                Console.WriteLine("\t Backdrop Path : " + result.BackdropPath);
                Console.WriteLine("\t Poster Path   : " + result.PosterPath);

                Console.WriteLine();
                */
            }
            return null;
        }

        private static TMDbLib.Objects.Movies.Movie FetchMovie(int movieId)
        {
            TMDbLib.Objects.Movies.Movie aMovie = client.GetMovie(movieId, MovieMethods.Images).Result;
            return aMovie;
        }
        private static Uri FetchImages(int movieId)
        {
            //const int movieId = 76338; // Thor: The Dark World (2013)

            // In the call below, we're fetching the wanted movie from TMDb, but we're also doing something else.
            // We're requesting additional data, in this case: Images. This means that the Movie property "Images" will be populated (else it will be null).
            // We could combine these properties, requesting even more information in one go:
            //      client.GetMovie(movieId, MovieMethods.Images);
            //      client.GetMovie(movieId, MovieMethods.Images | MovieMethods.Releases);
            //      client.GetMovie(movieId, MovieMethods.Images | MovieMethods.Trailers | MovieMethods.Translations);
            //
            // .. and so on..
            // 
            // Note: Each method normally corresponds to a property on the resulting object. If you haven't requested the information, the property will most likely be null.

            // Also note, that while we could have used 'client.GetMovieImages()' - it was better to do it like this because we also wanted the Title of the movie.
            TMDbLib.Objects.Movies.Movie movie = client.GetMovie(movieId, MovieMethods.Images).Result;
            // Images come in two forms, each dispayed below
            //Console.WriteLine("Displaying Backdrops");
           // ProcessImages(client, movie.Images.Backdrops.Take(3), client.Config.Images.BackdropSizes);

            //Console.WriteLine("Displaying Posters");
            Uri biggestImage = ProcessImages(client, movie.Images.Posters.Take(1), client.Config.Images.PosterSizes);
            return biggestImage;
            //myForm.AddOneEntryToMyVideos(movie, biggestImage);
        }

        private static Uri ProcessImages(TMDbClient client, IEnumerable<ImageData> images, IEnumerable<string> sizes)
        {
            // Displays basic information about each image, as well as all the possible adresses for it.
            // All images should be available in all the sizes provided by the configuration.

            foreach (ImageData imageData in images)
            {
                //Console.WriteLine(imageData.FilePath);
                //Console.WriteLine("\t " + imageData.Width + "x" + imageData.Height);

                // Calculate the images path
                // There are multiple resizing available for each image, directly from TMDb.
                // There's always the "original" size if you're in doubt which to choose.

                string highestSize = sizes.Last<string>();
                Uri imageUri = client.GetImageUrl(highestSize, imageData.FilePath);
                return imageUri;
                //foreach (string size in sizes)
               // {
                  //  Uri imageUri = client.GetImageUrl(size, imageData.FilePath);
                    Console.WriteLine("\t -> " + imageUri);
                //}

                //Console.WriteLine();
            }
            return null;
        }

        public  bool loadMyMovieFromFile(string Name, string Year, string Season, string Episode)
        {
            if(!loadTvShowID(Name))
                loadMovieID(Name);
            /*
            //locate the movie in the database 
            string postInfo = "Title=" + Name + "&Submit=QueryMovie";
       
            string response = HTTP.DoPOST("https://secure2025.hostgator.com/~czzplnm/moviemanager.php", postInfo);

            string[] Data = response.Split('|');

            if (Data.Length >= 13)
            {
                createMyMovie(Data[5], Data[8], Data[2], Data[4], Convert.ToInt32(Data[3]), Convert.ToInt16(Data[0]), Data[7], Data[6], Data[1], Data[12], Data[11], Data[10], Data[9], Data[13], "", "", 0, 0, "");
                movieType = mType.ondisk;

                return true;
            }
            */
            return false;
        }
    }
}
