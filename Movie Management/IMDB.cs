using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
namespace Movie_Management
{
    class IMDB
    {
       
       public static List<string> CollectedMovies { get; set; }


       public static int CurrentPage {get; set;}
       static int FocusedMovie = 0;
       public static Int32 TotalCrawled { get; set; }
       public static Int32 CrawlBlockSize { get; set; }
       public static Int32 CurrentCrawl  { get; set; }

       public static void init()
       {
           TotalCrawled = new Int32();
           CrawlBlockSize = 50;
           CurrentCrawl = 0;
           CollectedMovies = new List<string>();
       }

       public static string GetGenres()
       {

           if (CollectedMovies.Count == 0)
               return null;
        

           string Response = HTTP.DoGET(CollectedMovies[FocusedMovie]);
           MatchCollection Genres = Regex.Matches(Response, "<span class=\"itemprop\" itemprop=\"genre\">(.*?)</span>", RegexOptions.IgnoreCase);
           string GenresOf = "";
           for (int i = 0; i < Genres.Count; i++)
           {
               string Genre = Regex.Replace(Genres[i].Value.ToString(), "<(.*?)>", "");
               if (i == 0)
                   GenresOf += Genre;
               else
                   GenresOf += ", " + Genre;
           }
           return GenresOf;
       }

      

        

    }
}
