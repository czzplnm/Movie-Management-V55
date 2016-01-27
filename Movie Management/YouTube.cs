using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
namespace Movie_Management
{
   internal class YouTube
    {
       public static string SearchTerm;
       private static string results;


       public static string SearchYouTube(string keyword)
       {
           try
           {
               SearchTerm = keyword;
               new YouTube().Run().Wait();
               return results;
           }
           catch (AggregateException e)
           {
               return e.ToString();
           }
          
       }

       private async Task Run()
       {
           var youtubeService = new YouTubeService(new BaseClientService.Initializer()
           {
               ApiKey = "AIzaSyDj8H5Clpt8Z9woWm31xXZo4rfagRPzybE",
               ApplicationName = this.GetType().ToString()
           });

           var searchListRequest = youtubeService.Search.List("snippet");
           searchListRequest.Q = SearchTerm; // Replace with your search term.
           searchListRequest.MaxResults = 50;

           // Call the search.list method to retrieve results matching the specified query term.
           var searchListResponse = await searchListRequest.ExecuteAsync();

           List<string> videos = new List<string>();
           List<string> channels = new List<string>();
           List<string> playlists = new List<string>();

           // Add each result to the appropriate list, and then display the lists of
           // matching videos, channels, and playlists.
           foreach (var searchResult in searchListResponse.Items)
           {
               switch (searchResult.Id.Kind)
               {
                   case "youtube#video":
                       videos.Add(searchResult.Id.VideoId);
                       break;

                   case "youtube#channel":
                       channels.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.ChannelId));
                       break;

                   case "youtube#playlist":
                       playlists.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.PlaylistId));
                       break;
               }
           }
           results = videos[0];
         //  results = string.Join("\n", videos);
           //Console.WriteLine(String.Format("Videos:\n{0}\n", string.Join("\n", videos)));
          // Console.WriteLine(String.Format("Channels:\n{0}\n", string.Join("\n", channels)));
           //Console.WriteLine(String.Format("Playlists:\n{0}\n", string.Join("\n", playlists)));
       }
    }
}
