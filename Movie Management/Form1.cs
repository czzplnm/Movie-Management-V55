using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using AxAXVLC;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shell32;
using System.Xml;
using System.Xml.Serialization;
using TMDbLib;
using TMDbLib.Objects;
using TMDbLib.Client;
using TMDbLib.Utilities;
using TMDbLib.Objects.Movies;

namespace Movie_Management
{
    public partial class Form1 : Form
    {
        Settings SettingsClass = new Settings();
        List<string> selectedGenres;
        
        delegate void UIUpdaterDelegate();
        delegate void SetTextCallback(string text);

        string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Video Magination\\";
        string MyData = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Video Magination\\Data\\";
        string MyBlackList = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Video Magination\\BlackList\\";
        public static string MySettings = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Video Magination\\Settings\\";


        public static List<Movie> MoviesCollection = new List<Movie>();

        public static List<MyMovie> MyMoviesCollection = new List<MyMovie>();
        private static int MaxListViews = 18;
        public static Int32 totalLoadedInListView = 0;


        public Form1()
        {
            
            InitializeComponent();
            SettingsClass.init();        
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(150, 256);
            this.imageListMyMoviesLarge.ImageSize = new Size(150, 256);
            this.imageList2.ImageSize = new Size(64, 120);
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.SmallImageList = this.imageList2;
            this.listView2.LargeImageList = this.imageListMyMoviesLarge;
        }

    




        private void Form1_Load(object sender, EventArgs e)
        {
            IMDB.init();
            MoviesManager.Init();

            Settings.loadSettings();
            labelLastWatchedMovie.Text = "Last Watched: " + Settings.getLastWatchedMovie();

            bool loadOnDisk = false;
            if (loadOnDisk)
            {
                if (bgwLoadImages.IsBusy == false)
                    bgwLoadImages.RunWorkerAsync();

                if (bgwLoadData.IsBusy == false)
                    bgwLoadData.RunWorkerAsync();
            }

          if (bgwCrawlDirectory.IsBusy == false)
              bgwCrawlDirectory.RunWorkerAsync();


          if (!Directory.Exists(MyBlackList))
              Directory.CreateDirectory(MyBlackList);

          if (!Directory.Exists(MySettings))
              Directory.CreateDirectory(MySettings);

          if (!File.Exists(MySettings + "video_folders.dat"))
              File.Create(MySettings + "video_folders.dat").Dispose();
        }
        
      
        private void processSettings_DoWork(object sender, DoWorkEventArgs e)
        {

        }
       

        private void button1_Click(object sender, EventArgs e)
        {

            using (var imdbForm = new IMDBGenres())
            {
                var result = imdbForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    selectedGenres = imdbForm.sGenre; 
                }
                selectedGenres = imdbForm.sGenre; 
                imdbForm.Dispose();

                    string Items = "Selected Genres: ";
                    int Count = 0;
                    foreach (String item in selectedGenres)
                    {
                        if (Count == 0)
                            Items += item;
                        else
                            Items += ", " + item;
                        Count++;
                    }

                   

                    if (selectedGenres.Count > 0)
                    {
                        timerImdbCrawler.Interval = 1000;
                        timerImdbCrawler.Enabled = true;
                        if (bgwCrawlIMDB.IsBusy == false)
                            bgwCrawlIMDB.RunWorkerAsync();
                    }
                   
            }
          
        }

      

        public static void SetTextBoxText(TextBox tb, string Text)
        {
           tb.Invoke(new UIUpdaterDelegate(() =>
                {
                    tb.Text = Text;
                }));
        }
        public static void SetLabelText(Label lb, string Text)
        {
            lb.Invoke(new UIUpdaterDelegate(() =>
            {
                lb.Text = Text;
            }));
        }


        Int32 crawledMovies = 0;
        private void bgwLoadMovies_DoWork(object sender, DoWorkEventArgs e)
        {
           List<string> input = selectedGenres;
         
            for (int i = 0; i < input.Count; i++)
            {
                SetLabelText(labelCrawledGenres, "Searching Genre: " + input[i]);
                
                this.buttonCrawl.Invoke(new UIUpdaterDelegate(() =>
                    {
                        this.buttonCrawl.Enabled = true;
                        this.buttonCrawl.Text = "Stop Searching";
                    }));
                string URL = "http://www.imdb.com/search/title?at=0&genres=" + input[i] + "&sort=moviemeter,asc&start=" + IMDB.CurrentCrawl.ToString() + "&title_type=feature";
                string Response = HTTP.DoGET(URL);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(Response);
                HtmlNode TableNode = doc.DocumentNode.SelectSingleNode("//table[@class='results']");
                HtmlNodeCollection nodes = TableNode.SelectNodes("tr");
             
                if (nodes == null)
                    return;

                int loop = 0;
                foreach (HtmlNode node in nodes)
                {
                    if (loop > nodes.Count)
                        break;

                    if (node.ChildNodes.Count == 7)
                    {
                        string RunTime;
                        string Number = node.SelectSingleNode("td[@class='number']").InnerText;
                        HtmlNode titleNode = node.SelectSingleNode("td[@class='image']//a");
                        string Title = titleNode.GetAttributeValue("title", "");
                        Title = HtmlEntity.DeEntitize(Title);
                        //check the title and it is exists, load that data

                        string relativeHref = titleNode.GetAttributeValue("href", "");
                        HtmlNode imgNode = node.SelectSingleNode("td[@class='image']//a//img");
                        string imgSrc = imgNode.GetAttributeValue("src", "");
                        HtmlNode tdTitle = node.SelectSingleNode("td[@class='title']");
                        string Year = tdTitle.SelectSingleNode(".//span[@class='year_type']").InnerText;
                        string Description = "";
                        HtmlNode Desc = tdTitle.SelectSingleNode(".//span[@class='outline']");
                        if (Desc != null)
                            Description = Desc.InnerText;

                        HtmlNode RatingNode = tdTitle.SelectSingleNode(".//span[@class='certificate']//span");
                        string Rating = "";
                        if(RatingNode != null)
                        Rating = RatingNode.GetAttributeValue("title", "");
                        HtmlNode spanRuntime = tdTitle.SelectSingleNode(".//span[@class='runtime']");
                        if (spanRuntime == null)
                            RunTime = "0";
                        else
                            RunTime = spanRuntime.InnerText;
                        string MovieURL = "http://www.imdb.com" + relativeHref;
                        string GenresString = tdTitle.SelectSingleNode(".//span[@class='genre']").InnerText;
                        string IMDBRating = "";
                        HtmlNode imdbRating = tdTitle.SelectSingleNode(".//div//div//span//span[@class='value']");
                        if(imdbRating != null)
                            IMDBRating = imdbRating.InnerText;
                        //crawl to other web page and find the bigger image
                        string NextPageHTML = HTTP.DoGET(MovieURL);

                        if (NextPageHTML == null)
                            break;

                        HtmlAgilityPack.HtmlDocument nextPage = new HtmlAgilityPack.HtmlDocument();
                        nextPage.LoadHtml(NextPageHTML);

                        HtmlNode trailerNode = nextPage.DocumentNode.SelectSingleNode(".//a[@itemprop='trailer']");
                        string trailerURL = "";
                        if (trailerNode != null)
                        {
                            string trailerFirstHref = trailerNode.GetAttributeValue("href", "");
                            trailerURL = "http://www.imdb.com" + trailerFirstHref;
                        }
                       
                       //search
                        string ybrResponse = YouTube.SearchYouTube(Title + " trailer");
                        if (ybrResponse.Length <= 30)
                            trailerURL = ybrResponse;
                        else
                            trailerURL = "";

                        HtmlNode biggerImageNode = nextPage.DocumentNode.SelectSingleNode(".//div[@class='image']//a//img");
                        string BiggerImage = "http://blogs.ncs-nj.org/k4stemlab/files/2013/04/image-unavailable.jpg";

                        if(biggerImageNode != null)
                        BiggerImage = biggerImageNode.GetAttributeValue("src", "");

                        HtmlNode Theaters = nextPage.DocumentNode.SelectSingleNode(".//div[@class='showtime']");
                        string theaterStatus;
                        string ComingSoon;
                        if (Theaters == null)
                        {
                            theaterStatus = "";
                            ComingSoon = "";
                        }
                        else
                        {

                            theaterStatus = Theaters.SelectSingleNode(".//h2").InnerText;
                            ComingSoon = Theaters.SelectSingleNode(".//p").InnerText;
                            ComingSoon = ComingSoon.Replace("        ", "");
                            ComingSoon = ComingSoon.Replace("\n", "");
                            ComingSoon = ComingSoon.Replace("\r", "");
                            ComingSoon = ComingSoon.Replace("In", "In ");
                            ComingSoon = ComingSoon.Replace("Change location", "");
                            ComingSoon = ComingSoon.Replace("  ", "");
                        }
                        bool Add = false;

                        //check to see if movie was blacklist
                        if (MoviesManager.BlackList(Title, false, MyDocuments))
                            Add = false;

                        bool Exists = false;
                        for (int i3 = 0; i3 < IMDB.CollectedMovies.Count; i3++)
                            if (IMDB.CollectedMovies[i3] == MovieURL)
                                Exists = true;
                        if (!Exists)                     
                        {
                            Add= true;
                            IMDB.CollectedMovies.Add(MovieURL);
                        }  
                        if (IMDB.CollectedMovies.Count == 0)      
                        { 
                            Add = true;
                            IMDB.CollectedMovies.Add(MovieURL);
                        }                       
                       

                          string FileName;                         
                        FileName = Regex.Replace(BiggerImage, "http(.*)/", "");
                        Title = Title.Replace("\\", "");
                        Title = Title.Replace("/", "");
                        Title = Title.Replace("?", "");
                        Title = Title.Replace(":", "");
                        Title = Title.Replace("*", "");
                        Title = Title.Replace("\"", "");
                        Title = Title.Replace(">", "");
                        Title = Title.Replace("<", "");
                        Title = Title.Replace("|", "");

                        SetLabelText(labelSearching, "Searching:\r " + Title);

                     //   string[] Genres = GenresString.Split('|');

                        Int32 RunTimeInt = MoviesManager.CleanRuntime(RunTime);
                        Int32 YearInt = MoviesManager.CleanYear(Year);

                        string LargeImagePath = MyDocuments + "images\\small\\";


                        if (Add)
                        {
                            labelResult.ForeColor = Color.Green;
                            SetLabelText(labelResult, "Result: Added");
                            MoviesManager.AddMovie(imgSrc, Number, Title, Description, YearInt, RunTimeInt, MovieURL, BiggerImage, Rating, theaterStatus, ComingSoon, IMDBRating, GenresString, trailerURL);
                        }
                        else
                        {
                            labelResult.ForeColor = Color.Red;
                            SetLabelText(labelResult, "Result: Not Added");
                        }
                        
                      
                        string DataPath = MyData + Title + ".dat";
                        if (!Directory.Exists(MyData))
                            Directory.CreateDirectory(MyData);
                        if (!File.Exists(DataPath))
                            File.Create(DataPath).Dispose();
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(DataPath))
                        {
                            file.WriteLine(imgSrc);
                            file.WriteLine(Number);
                            file.WriteLine(Title);
                            file.WriteLine(Description);
                            file.WriteLine(Year);
                            file.WriteLine(RunTime);
                            file.WriteLine(MovieURL);
                            file.WriteLine(BiggerImage);
                            file.WriteLine(Rating);
                            file.WriteLine(theaterStatus);
                            file.WriteLine(ComingSoon);
                            file.WriteLine(IMDBRating);
                            file.WriteLine(GenresString);
                            file.WriteLine(trailerURL);
                            file.Dispose();
                        }
                        string ImagePath = MyDocuments + "images\\large\\" + Title + ".jpg";
                        string ImagePathSmall = MyDocuments + "images\\small\\"+ Title + ".jpg";
                        if (!Directory.Exists(MyDocuments))
                            Directory.CreateDirectory(MyDocuments); 
                        if (!File.Exists(ImagePath))
                        {
                                WebClient webClient = new WebClient();
                                webClient.DownloadFile(BiggerImage, @ImagePath);
                                webClient.DownloadFile(imgSrc, @ImagePathSmall);
                       //add to image view
                                AddToLV(ImagePath, true);
                                AddToLV(ImagePathSmall, false);
                                webClient.Dispose();
                        }
                        SetLabelText(labelTotalMovies, "Total Movies: " + MoviesCollection.Count.ToString());
                        crawledMovies++;
                        SetLabelText(labelCrawledCount, "Searched: " + crawledMovies.ToString());
                    }
                    loop++;  
                }
                IMDB.CurrentCrawl += 50;
            }
           
         
        }

     
        public void UpdateStats()
        {

            Movie aMovie = MoviesCollection[MoviesManager.CurrentMovie];
            SetTextBoxText(textBoxDesciption, aMovie.Overview);
            SetLabelText(labelCurrentMovie, "Current Movie: " + HtmlEntity.DeEntitize(aMovie.Title));
            SetLabelText(labelTotalMovies, "Total Movies: " + MoviesCollection.Count.ToString());
            SetLabelText(labelYear, "Year: " + aMovie.ReleaseDate.ToString());
            this.centerPb.Invoke(new UIUpdaterDelegate(() =>
            {
                this.centerPb.ImageLocation = aMovie.BackdropPath.ToString();
            }));
            string GenreList = IMDB.GetGenres();

            if (GenreList == null)
                return;

            SetLabelText(labelCurrentGenre, "Current Genre(s): " + GenreList);
       

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void LoadNextMovie(string Direction)

        {
            switch (Direction)
            {
                case "F":
                    if(MoviesManager.CurrentMovie < MoviesManager.TotalMovies)
                    MoviesManager.CurrentMovie++;
                    UpdateStats();
                    return;
                case "B":
                    if (MoviesManager.CurrentMovie > 0)
                    MoviesManager.CurrentMovie--;
                    UpdateStats();
                    return;

                default:
                    UpdateStats();
                    return;
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lastViewedIndex < 0)
                return;


            if (lastViewedIndex >= MoviesManager.TotalMovies)
                return;
            lastViewedIndex++;
            MoviesManager.CurrentMovie = lastViewedIndex;
            UpdateStats();
            
            /*
            if (Movies.CurrentMovie < Movies.TotalMovies)
                LoadNextMovie("F");
             */
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lastViewedIndex < 0)
                return;


            if (lastViewedIndex == 0)
                return;

            lastViewedIndex--;
            MoviesManager.CurrentMovie = lastViewedIndex;
            UpdateStats();
            /*
            if (Movies.CurrentMovie < Movies.TotalMovies)
                LoadNextMovie("B");
             */
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Video Files (*.avi)|*.avi|(*.mp4)|*.mp4|(*.mkv)|*.mkv|(*.wmp)|*.wmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
              
                //axVLCPlugin21.playlist.add("file:///" + ofd.FileName, ofd.SafeFileName, null);
             //   axVLCPlugin21.playlist.play();

                
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (domainUpDown1.Text)
            {
                case "LargeIcon":                
                
                    this.listView1.View = View.LargeIcon;
                    return;
                case "SmallIcon":                  
                    this.listView1.View = View.SmallIcon;        
                    return;
                case "Tile":
                    listView1.View = View.Tile;
                    return;
                case "List":
                    listView1.View = View.List;
                    return;
                case "Details":
                    listView1.View = View.Details;
                    return;
                default:
                    return;

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateMoviesInListView1()
        {
            this.labelMoviesInView.Invoke(new UIUpdaterDelegate(() =>
            {
                this.labelMoviesInView.Text = "Movies in view: " + listView1.Items.Count.ToString();
            }));
        }

        private void ListViewAlter(bool Forward)
        {
            if (Forward)
                   MoviesManager.currentPage++;              
            else
            {
                if (MoviesManager.currentPage == 0)
                    return;
                 MoviesManager.currentPage--;
            }
               

                this.listView1.Invoke(new UIUpdaterDelegate(() =>
                {
                    this.listView1.Items.Clear();         
                    this.imageList1.Images.Clear();             
                    this.imageList2.Images.Clear();
                }));
            
                for (int i = 0; i < MaxListViews; i++)
                {
                      if(Forward)
                        totalLoadedInListView++;
                    else 
                        totalLoadedInListView--;

            //        movieIndex = (MoviesManager.currentPage * MaxListViews) + i;

                      if (totalLoadedInListView >= MoviesCollection.Count)
                        return;

                      Movie aMovie = MoviesCollection[totalLoadedInListView];

                    string BigMovie = MyDocuments + "images\\large\\" + aMovie.Title + ".jpg";
                    string SmallMovie = MyDocuments + "images\\small\\" + aMovie.Title + ".jpg";
                    using (FileStream fs = new FileStream(BigMovie, FileMode.Open, FileAccess.Read))
                    {
                        using (Image original = Image.FromStream(fs))
                        {

                            this.Invoke(new Action(() =>
                                {
                                    this.imageList1.Images.Add(original);
                                }));
                            
                            ListViewItem item = new ListViewItem();
                            item.ImageIndex = listView1.Items.Count;
                            this.listView1.Invoke(new UIUpdaterDelegate(() =>
                            {
                                this.listView1.Items.Add(item);
                            }));

                            UpdateMoviesInListView1();
                        }
                    }
                    using (FileStream fs = new FileStream(SmallMovie, FileMode.Open, FileAccess.Read))
                    {
                        using (Image original = Image.FromStream(fs))
                        {

                            this.Invoke(new Action(() =>
                            {
                                this.imageList2.Images.Add(original);
                            }));

                        }
                    }




                }








                UpdateMoviesInListView1();
                
            
        }



        private void AddToLV(string Path, bool isBig)
        {
            try
            {

                int MaxListItems = Convert.ToInt16(MaxListViews);
                if (listView1.Items.Count >= MaxListItems)
                    return;

              
                

                Match testName = Regex.Match(Path, ".jpg", RegexOptions.IgnoreCase);
                if (testName.Success)
                {
                    using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                    {
                        using (Image original = Image.FromStream(fs))
                        {
                            

                            if (isBig)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    this.imageList1.Images.Add(original);
                                }));
                            }
                            else
                            {
                                this.Invoke(new Action(() =>
                                {
                                    this.imageList2.Images.Add(original);
                                }));
                                return;
                            }
                            ListViewItem item = new ListViewItem();
                            item.ImageIndex = listView1.Items.Count;
                            this.listView1.Invoke(new UIUpdaterDelegate(() =>
                            {
                                this.listView1.Items.Add(item);
                            }));

                            UpdateMoviesInListView1();

                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

     
     

        private void bgwLoadImages_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int MaxListItems = Convert.ToInt16(MaxListViews);
                if (listView1.Items.Count > MaxListItems)
                    return;

                if (!Directory.Exists(MyDocuments + "images\\large\\"))
                    Directory.CreateDirectory(MyDocuments + "images\\large\\");

                if (!Directory.Exists(MyDocuments + "images\\small\\"))
                    Directory.CreateDirectory(MyDocuments + "images\\small\\");

                foreach (var file in Directory.GetFiles(MyDocuments + "images\\large\\"))
                {                 
                    AddToLV(file, true);
                    Thread.Sleep(5);
                }
                foreach (var file in Directory.GetFiles(MyDocuments + "images\\small\\"))
                {
                    AddToLV(file, false);
                    Thread.Sleep(5);
                }
                MoviesManager.CurrentMovie = 0;
            }
            catch (Exception)
            {
            }
        }

        private int lastViewedIndex;
        private int hoveredIndex;
        private void listView1_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            try
            {

                Point p = listView1.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));
                hoveredIndex = listView1.GetItemAt(p.X, p.Y).Index;
                
               

                lastViewedIndex = hoveredIndex + totalLoadedInListView;

                if (MoviesManager.CurrentMovie == lastViewedIndex && MoviesManager.CurrentMovie != 0)                    
                    return;

                MoviesManager.CurrentMovie = lastViewedIndex;
                UpdateStats();

            }
            catch (Exception)
            {
              //  MessageBox.Show(ItemHover.ToString());
            }

        }

        private void bgwLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            if(Directory.Exists(MyData))
            foreach (var file in Directory.GetFiles(MyData))
            {
                string[] Data = File.ReadAllLines(file);
                IMDB.CollectedMovies.Add(Data[6]);
                        
                MoviesManager.AddMovie(Data[0], Data[1], Data[2], Data[3], MoviesManager.CleanYear(Data[4]), MoviesManager.CleanRuntime(Data[5]), Data[6], Data[7], Data[8], Data[9], Data[10], Data[11], Data[12], Data[13]);
                
                SetLabelText(labelTotalMovies, "Total Movies: " + MoviesCollection.Count.ToString());
            }
           
        }   



 

        private void button6_Click(object sender, EventArgs e)
        {
            Movie aMovie = MoviesCollection[lastViewedIndex];
            MoviesManager.BlackList(aMovie.Title, true, MyDocuments);

            MoviesManager.RemoveMovie(lastViewedIndex);
            listView1.Items.RemoveAt(hoveredIndex);
          //  imageList1.Images.RemoveAt(Movies.CurrentMovie);
           // imageList2.Images.RemoveAt(Movies.CurrentMovie);
            if (MoviesManager.CurrentMovie == 0)
                MoviesManager.CurrentMovie++;
            else
                MoviesManager.CurrentMovie--;
            
            UpdateStats();
        }

        public void getDigit(TextBox tb, string DefaultText)
        {
            Match isaDigit = Regex.Match(tb.Text, "[0-9]{1,30}", RegexOptions.IgnoreCase);
            if (isaDigit.Success)
            {
                tb.Text = isaDigit.Value.ToString();               
            }
            else
            {
                tb.Text = DefaultText;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            getDigit(textBoxMoviesPerPage, "18");
            MaxListViews = Convert.ToInt16(textBoxMoviesPerPage.Text);
        }

        private void buttonCrawl_Click(object sender, EventArgs e)
        {
            if (buttonCrawl.Text == "Stop Searching")
            {
                buttonCrawl.Text = "Start Searching";
                timerImdbCrawler.Enabled = false;
            }
            else
            {
                buttonCrawl.Text = "Stop Searching";
                timerImdbCrawler.Enabled = true;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
           // Movie aMovie = MoviesCollection[lastViewedIndex];
          //  if (aMovie.Videos != "")
           // {
           //     TrailersForm tFrm = new TrailersForm(aMovie.Trailers,aMovie.Title);
           //     tFrm.ShowDialog();
           // }
        }

        private void timerImdbCrawler_Tick(object sender, EventArgs e)
        {
            if (bgwCrawlIMDB.IsBusy == false)
                bgwCrawlIMDB.RunWorkerAsync();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ListViewAlter(true);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ListViewAlter(false);
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                int selectedCell = listView1.SelectedItems[0].Index;             

                int Volume = Convert.ToInt16(textBoxMoviesPerPage.Text);

                lastViewedIndex = selectedCell + (MoviesManager.currentPage * Volume);

                if (MoviesManager.CurrentMovie == lastViewedIndex && MoviesManager.CurrentMovie != 0)
                    return;

                MoviesManager.CurrentMovie = lastViewedIndex;
                UpdateStats();

            }
            catch (Exception)
            {
                //  MessageBox.Show(ItemHover.ToString());
            }
        }

        private void SaveVideoDirectories()
        {
            List<string> foldersFound = new List<string>();
            foreach (DataGridViewRow row in dgwVideoFolders.Rows)
            {
                foldersFound.Add(row.Cells[0].Value.ToString());
            }
            if (foldersFound == null)
                return;

            FindMovies.saveSettings(foldersFound, MySettings);
        }

        private void processFolders(string Folder, bool UpdateSettings)
        {
            //crawl the directory to find movies with bgw
            List<string> videosFound = FindMovies.crawlDirectory(Folder, checkBoxIgnoreSamples, checkBoxReplacePeriods);

            if (videosFound == null)
            {            
                MessageBox.Show("No videos found.");
                return;
            }

            string[] rows = new string[] { Folder, videosFound.Count.ToString() };

            this.dgwVideoFolders.Invoke(new UIUpdaterDelegate(() =>
                {
                    this.dgwVideoFolders.Rows.Add(rows);
                }));

            for (int i = 0; i < videosFound.Count; i++)            
                addToMoviesDatagrid(videosFound[i]);             
            
            if(UpdateSettings)
                SaveVideoDirectories();

            this.dgwMyVideos.Invoke(new UIUpdaterDelegate(() =>
            {
                this.dgwMyVideos.Refresh();
            }));
            this.dgwVideoFolders.Invoke(new UIUpdaterDelegate(() =>
            {
                this.dgwVideoFolders.Refresh();
            }));          
        }

        public string videosCache = MySettings + "videos_cache.dat";
        private void button4_Click_1(object sender, EventArgs e)
        {
            processFolderDialog();
        }

        private async void processFolderDialog()
        {
            //check to see if the cached videos are available
            if (!File.Exists(videosCache))
                File.Create(videosCache).Dispose();

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {                
                processSelectedPath(folderBrowserDialog1.SelectedPath);         
            }
        }

        void processSelectedPath(string Path)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                for (int i = 0; i < dgwVideoFolders.Rows.Count; i++)
                {
                    if (dgwVideoFolders.Rows[i].Cells[0].Value.ToString() == Path)
                        return;
                }
                processFolders(Path, true);
            }).Start();
        }

        private void dgwVideoFolders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }




        bool loaded = false;
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;
            if (selectedTabIndex == 1)
            {
           //     if (bgwCrawlDirectory.IsBusy == false)
              //      bgwCrawlDirectory.RunWorkerAsync();
            }
            else if(selectedTabIndex == 3)
            {
              //  if (bgwLoadMyMovies.IsBusy == false)
               //     bgwLoadMyMovies.RunWorkerAsync();
            }
        }

       
        private void bgwCrawlDirectory_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!loaded)
            {

                
                    //load settings file
                    string line;
                    StreamReader file = new StreamReader(MySettings + "video_folders.dat");
                    while ((line = file.ReadLine()) != null)
                    {
                        processFolders(line, false);
                    }
                    loaded = true;
                    file.Close();

              
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgwMyVideos.Rows.Count; i++)
            {
                Match hasPeriods = Regex.Match(dgwMyVideos.Rows[i].Cells[0].Value.ToString(), "\\.", RegexOptions.IgnoreCase);
                if(hasPeriods.Success)
                {

                   
                    string substringOf = dgwMyVideos.Rows[i].Cells[0].Value.ToString();
                    string endString = substringOf.Substring(substringOf.Length - 4);
                    string replacement = substringOf.Substring(0, substringOf.Length - 4);
                    replacement = replacement.Replace(".", " ");
                    replacement = replacement + endString;
                    File.Move(dgwMyVideos.Rows[i].Cells[0].Value.ToString(), replacement);
                    }
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgwMyVideos.SelectedRows)
            {

                File.SetLastAccessTime(row.Cells[0].Value.ToString(), DateTime.Now);


               // if (axVLCPlugin21.playlist.isPlaying)
                //    axVLCPlugin21.playlist.stop();
                    
               // if(axVLCPlugin21.playlist.items.count > 0)
               //     axVLCPlugin21.playlist.items.clear();

               // axVLCPlugin21.playlist.add("file:///" + row.Cells[0].Value.ToString(), row.Cells[0].Value.ToString(), null);
             //   axVLCPlugin21.playlist.play();
                tabControl1.SelectTab(2);

                Settings.setLastMovie(row.Cells[1].Value.ToString());
                Settings.saveSettings();             

            }
        }

        public static void updateProgramName(string Input)
        {
            Form thisForm = Form.ActiveForm;
            thisForm.Text = Input;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgwMyVideos.SelectedRows)
            {
                MovieCleaner mCleaner = new MovieCleaner(row);
                mCleaner.ShowDialog();

                if (MovieCleaner.Modified)
                {
                    int rowIndex = row.Index;

                    dgwMyVideos.Rows.RemoveAt(rowIndex);

                    string cleanedResponse = MovieCleaner.renamedMovie;
                    addToMoviesDatagrid(cleanedResponse);
                   
                }
                mCleaner.Dispose();
            }
        }

        public string getMovieDuration(string Pathx)
        {
            string videoLength;
            try
            {
                var shl = new Shell();
                var fldr = shl.NameSpace(Path.GetDirectoryName(Pathx));
                var itm = fldr.ParseName(Path.GetFileName(Pathx));

                // Index 27 is the video duration [This may not always be the case]
                var propValue = fldr.GetDetailsOf(itm, 27);
                // out TimeSpan duration;
                TimeSpan movieSpan;
                TimeSpan.TryParse(propValue, out movieSpan);
                videoLength = movieSpan.ToString("c");
            }
            catch (Exception)
            {
                videoLength = "";
            }
            return videoLength;
        }


        public void addToMoviesDatagrid(string Pathx)
        {
            string videoType = FindMovies.whatType(Pathx);

            FileInfo videoInfo = new FileInfo(Pathx);
            string lastWatched = videoInfo.LastAccessTime.ToString();
            string videoLength = getMovieDuration(Pathx);
            string dateAdded = videoInfo.LastWriteTime.ToString();
            string Season = "";
            string Episode = "";
            string Quality = "";
            string Year = "";

            string justMovieName = Regex.Replace(Pathx, "[A-Za-z](.*)\\\\", "");

            Match movieYear = Regex.Match(justMovieName, "\\((.*?)\\)", RegexOptions.IgnoreCase);
            if (movieYear.Success)
            {
                Year = Regex.Replace(movieYear.Value.ToString(), "\\(", "");
                Year = Regex.Replace(Year, "\\)", "");
            }

            Match movieQuality = Regex.Match(justMovieName, "\\[(.*?)\\]", RegexOptions.IgnoreCase);
            if (movieQuality.Success)
            {
                Quality = Regex.Replace(movieQuality.Value.ToString(), "\\[", "");
                Quality = Regex.Replace(Quality, "\\]", "");
            }

            bool qualityMatched = false;
            for (int i = 0; i < MovieCleaner.qualities.Length; i++)
            {
                if (Quality == MovieCleaner.qualities[i])
                    qualityMatched = true;
            }

            if (!qualityMatched)
                Quality = "";

            Match tvSeries = Regex.Match(Pathx, "S[0-9]{1,2}E[0-9]{1,2}", RegexOptions.IgnoreCase);
            if (tvSeries.Success)
            {
                Season = Regex.Replace(tvSeries.Value.ToString(), "E[0-9]{1,2}", "");
                Episode = Regex.Replace(tvSeries.Value.ToString(), "S[0-9]{1,2}", "");
            }

            string[] rows = new string[] { Pathx, justMovieName, Year, Quality, Season, Episode, videoType, videoLength.ToString(), lastWatched, dateAdded };
            //save file 
            string cacheDirect = MySettings + "/cache/";
            string videoFile = cacheDirect + justMovieName + ".dat";
            if (!Directory.Exists(cacheDirect))
                Directory.CreateDirectory(cacheDirect);

            if (!File.Exists(videoFile))
            {
                File.Create(videoFile).Dispose();
                string allInfo = "";
                for (int i = 0; i < rows.Length; i++)
                {
                    allInfo += rows[i] + "}^{";
                }

                using (TextWriter tw = new StreamWriter(videoFile))
                {
                    
                    tw.WriteLine(allInfo);
                    tw.Close();
                }
            }
           

            this.dgwMyVideos.Invoke(new UIUpdaterDelegate(() =>
            {
                this.dgwMyVideos.Rows.Add(rows);
                this.dgwMyVideos.Refresh();
            }));


            //save settings file for video directories
            Movie aMovie = MyMovie.loadTMDbLib(justMovieName);
            cacheVideo(aMovie);
        }
        
        public void cacheVideo(Movie movie)
        {
            try
            {
                
                /*
                //check if exists
                bool exists = false;
               // var movieJson = Newtonsoft.Json.JsonConvert.SerializeObject(movie);
                string line;
               // StreamReader file = new StreamReader(videosCache);
               // while ((line = file.ReadLine()) != null)
                {
                    var myLine = Newtonsoft.Json.JsonConvert.SerializeObject(line);
                    if (myLine == movieJson)
                        exists = true;
                }
                file.Dispose();
                if (!exists) {
                    using (System.IO.StreamWriter file2 = new System.IO.StreamWriter(videosCache))
                    {
                        file2.WriteLine(movieJson);
                    }
                }
                */
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private void addToMyVideos(string Name, string Year, string Season, string Episode)
        {

            this.labelTotalMyVideos.Invoke(new UIUpdaterDelegate(() =>
            {
                this.labelTotalMyVideos.Text = "My Videos: " + MoviesManager.MyMoviesCount.ToString();
            }));

            TMDbLib.Objects.Movies.Movie aMovie = new TMDbLib.Objects.Movies.Movie();
            Name = MovieCleaner.justMovieName(Name, Year);
            aMovie = MyMovie.loadTMDbLib(Name);
            if (MyMovie.lastImage != null)
            {
                //MyMoviesCollection.Add(aMovie);
                if (aMovie != null)
                {
                    if (!File.Exists(MySettings + "//cache//"))
                        AddOneEntryToMyVideos(aMovie, MyMovie.lastImage);
                }
                else
                    return;
            }
            /*


            Season = Season.Replace("S", "");
            Episode = Episode.Replace("E", "");
            if (Season == "")
                Season = "01";
            string RunTime = "";
            string Rating = "";
            string Title = "";
            string Description = "";
            string SmallImage = "";
            string RegularImage =  "http://blogs.ncs-nj.org/k4stemlab/files/2013/04/image-unavailable.jpg";
            string URL = "";
            string number = "";
            string IMDBRating = "";
            string ComingSoon = "";
            string TheaterStatus = "";
            string Trailers = "";
            string TheAirDate = "";
            string TheEpisodeTitle = "";
            string SeasonCover = "";
            Int32 theYear = 0;
            string Genres = "";
            if (Episode == "")
                Episode = "0";

            Name = MovieCleaner.justMovieName(Name, Year);
            //locate the movie in the database 
            string postInfo = "Title=" + Name + "&Submit=QueryMovie";
            HTTP http = new HTTP();
            string response = http.DoPOST("https://secure2025.hostgator.com/~czzplnm/moviemanager.php", postInfo);

            string[] Data = response.Split('|');

            if (Data.Length >= 13)
            {
                createMyMovie(Data[5], Data[8], Data[2], Data[4], Convert.ToInt32(Data[3]), Convert.ToInt16(Data[0]), Data[7], Data[6], Data[1], Data[12], Data[11], Data[10], Data[9], Data[13], TheEpisodeTitle, TheAirDate, 0, 0, SeasonCover);
                this.labelTotalMyVideos.Invoke(new UIUpdaterDelegate(() =>
                    {
                        this.labelTotalMyVideos.Text = "My Videos: " + MoviesManager.MyMoviesCount.ToString();
                    }));
            }*/
            //aMovie.loadConfig();//search moviedb
            //  if (!aMovie.loadMyMovieFromFile(Name, Year, Season, Episode))
            //  {
            //  aMovie.loadTMDbLib(Name, this);
            //aMovie.loadMovieDB(Name);
            /*
            if (!aMovie.loadOMDB(Name))
            {

                if(!aMovie.loadTvShowID(Name))       
                    aMovie.loadMovieID(Name);




            }
            */


            //}
            /*
            if (checkBoxIgnoreMovies.Checked)
                if (aMovie.movieType == MyMovie.mType.themoviedbMovie)
                    return;

            if (checkBoxIgnoreTVShows.Checked)
                if (aMovie.movieType == MyMovie.mType.themoviedbTV)
                    return;
                        

            if (aMovie.Image != null)
            {
                MyMoviesCollection.Add(aMovie);
                AddOneEntryToMyVideos(aMovie);
            }
                  */

            /*
             
                JToken titleToken = token.SelectToken("Title");
                if (titleToken != null)
                {
                    Title = titleToken.ToString();
                    int itemYear = (int)token.SelectToken("Year");
                }
                Int16 IntSeason = Convert.ToInt16(Season);
                Int16 IntEpisode = Convert.ToInt16(Episode);
            */
            //   createMyMovie(SmallImage, number, Title, Description, MoviesManager.CleanYear(theYear.ToString()), MoviesManager.CleanRuntime(RunTime), URL, RegularImage, Rating, TheaterStatus, ComingSoon, IMDBRating, Genres, Trailers, TheEpisodeTitle, TheAirDate, IntSeason, IntEpisode, SeasonCover);

        }

        public void AddOneEntryToMyVideos(TMDbLib.Objects.Movies.Movie aMovie, Uri biggestImage) {
            try
            {

                var request = WebRequest.Create(biggestImage);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    Image bigImage = Image.FromStream(stream);
                    this.Invoke(new Action(() =>
                    {
                        this.imageListMyMoviesLarge.Images.Add(bigImage);
                    }));

                    /*   this.Invoke(new Action(() =>
                       {
                           this.imageList2.Images.Add(aMovie.SmallImage);
                       }));
                      */

                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = listView2.Items.Count;
                    item.Name = aMovie.Title;

                    this.listView2.Invoke(new UIUpdaterDelegate(() =>
                    {
                        this.listView2.Items.Add(item);
                    }));

                    this.labelMoviesInView.Invoke(new UIUpdaterDelegate(() =>
                    {
                        this.labelMoviesInView.Text = "Movies in view: " + listView2.Items.Count.ToString();
                    }));

                    //set focus on added item
                    if (checkBoxSetMovieFocus.Checked == true)
                        this.listView2.Invoke(new UIUpdaterDelegate(() =>
                        {
                            this.listView2.Items[listView2.Items.Count - 1].Focused = true;
                            //this.listView2.TopItem = listView2.Items[listView2.Items.Count - 1];
                        }));



                    return;
                }
            }
            catch (Exception)
            {

                var request = WebRequest.Create("http://blogs.ncs-nj.org/k4stemlab/files/2013/04/image-unavailable.jpg");
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    Image bigImage = Image.FromStream(stream);
                    this.Invoke(new Action(() =>
                    {
                        this.imageListMyMoviesLarge.Images.Add(bigImage);
                    }));

                    /*   this.Invoke(new Action(() =>
                       {
                           this.imageList2.Images.Add(aMovie.SmallImage);
                       }));
                      */

                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = listView2.Items.Count;
                    item.Name = aMovie.Title;

                    this.listView2.Invoke(new UIUpdaterDelegate(() =>
                    {
                        this.listView2.Items.Add(item);
                    }));

                    this.labelMoviesInView.Invoke(new UIUpdaterDelegate(() =>
                    {
                        this.labelMoviesInView.Text = "Movies in view: " + listView2.Items.Count.ToString();
                    }));
                    return;
                }
            }
        }
            private void AddOneEntryToMyVideos(MyMovie aMovie)
        {
            //locate image
            try
            {
                var request = WebRequest.Create(aMovie.Image);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    Image bigImage = Image.FromStream(stream);
                    this.Invoke(new Action(() =>
                    {
                        this.imageListMyMoviesLarge.Images.Add(bigImage);
                    }));
                }
            }//failed to locate movie, use a image unavail
            catch (Exception e)
            {
                var request = WebRequest.Create("http://blogs.ncs-nj.org/k4stemlab/files/2013/04/image-unavailable.jpg");
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    Image bigImage = Image.FromStream(stream);
                    this.Invoke(new Action(() =>
                    {
                        this.imageListMyMoviesLarge.Images.Add(bigImage);
                    }));
                }
            }

            ListViewItem item = new ListViewItem();
            item.ImageIndex = listView2.Items.Count;
            item.Name = aMovie.number.ToString();

            this.listView2.Invoke(new UIUpdaterDelegate(() =>
            {
                this.listView2.Items.Add(item);
            }));

            this.labelMoviesInView.Invoke(new UIUpdaterDelegate(() =>
            {
                this.labelMoviesInView.Text = "Movies in view: " + listView2.Items.Count.ToString();
            }));

            //set focus on added item
            if (checkBoxSetMovieFocus.Checked == true)
                this.listView2.Invoke(new UIUpdaterDelegate(() =>
                {
                    this.listView2.Items[listView2.Items.Count - 1].Focused = true;
                    //this.listView2.TopItem = listView2.Items[listView2.Items.Count - 1];
                }));
        }

        private void dgwMyVideos_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        bool initialLoad = false;

       

        private void bgwLoadMyMovies_DoWork(object sender, DoWorkEventArgs e)
        {
            if (initialLoad)
                return;

            for (int i = 0; i < MyMoviesCollection.Count; i++)
            {
                if (i == 100)
                    break;
                MyMovie aMovie = MyMoviesCollection[i];
                if (checkBoxIgnoreMovies.Checked)
                    if (aMovie.movieType == MyMovie.mType.themoviedbMovie)
                        break;

                if (checkBoxIgnoreTVShows.Checked)
                    if (aMovie.movieType == MyMovie.mType.themoviedbTV)
                        break;
                        
                try
                {
                    var request = WebRequest.Create(aMovie.Image);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        Image bigImage = Image.FromStream(stream);
                        this.Invoke(new Action(() =>
                        {
                            this.imageListMyMoviesLarge.Images.Add(bigImage);
                        }));

                        /*   this.Invoke(new Action(() =>
                           {
                               this.imageList2.Images.Add(aMovie.SmallImage);
                           }));
                          */
                       


                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = listView2.Items.Count;
                        this.listView2.Invoke(new UIUpdaterDelegate(() =>
                        {
                            this.listView2.Items.Add(item);
                        }));

                        this.labelMoviesInView.Invoke(new UIUpdaterDelegate(() =>
                        {
                            this.labelMoviesInView.Text = "Movies in view: " + listView2.Items.Count.ToString();
                        }));
                    }
                }
                catch (Exception)
                {
                    //
                    var request = WebRequest.Create("http://blogs.ncs-nj.org/k4stemlab/files/2013/04/image-unavailable.jpg");
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        Image bigImage = Image.FromStream(stream);
                        this.Invoke(new Action(() =>
                        {
                            this.imageListMyMoviesLarge.Images.Add(bigImage);
                        }));

                        /*   this.Invoke(new Action(() =>
                           {
                               this.imageList2.Images.Add(aMovie.SmallImage);
                           }));                          */
                      

                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = listView2.Items.Count;
                        this.listView2.Invoke(new UIUpdaterDelegate(() =>
                        {
                            this.listView2.Items.Add(item);
                        }));

                        this.labelMoviesInView.Invoke(new UIUpdaterDelegate(() =>
                        {
                            this.labelMoviesInView.Text = "Movies in view: " + listView2.Items.Count.ToString();
                        }));
                    }
                }
            }
            initialLoad = true;
        }

        private void bgwFindVideos_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            // if (bgwPopulateMyMovies.IsBusy == false)
            // {
            //     bgwPopulateMyMovies.RunWorkerAsync();
            // }
            Thread movieThread = new Thread(new ThreadStart(populateVideosGrid));
            movieThread.Start();
            labelTotalMyVideos.Text = "My Videos: " + dgwMyVideos.Rows.Count.ToString();
          
        }

        private void populateVideosGrid()
        {
            for (int i = 0; i < dgwMyVideos.Rows.Count; i++)
            {
                if (i >= dgwMyVideos.Rows.Count)
                    return;

                string moviePath = "";
                string Year = "";
                string Season = "";
                string Episode = "";
                try
                {
                    moviePath = dgwMyVideos.Rows[i].Cells[1].Value.ToString();
                    Year = dgwMyVideos.Rows[i].Cells[2].Value.ToString();
                    Season = dgwMyVideos.Rows[i].Cells[4].Value.ToString();
                    Episode = dgwMyVideos.Rows[i].Cells[5].Value.ToString();
                    if (moviePath != "")
                        addToMyVideos(moviePath, Year, Season, Episode);
                }
                catch (Exception)
                {
                }
            }
        }
        private void bgwPopulateMyMovies_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dgwMyVideos.Rows.Count; i++)
            {
                if (i >= dgwMyVideos.Rows.Count)
                    return;

                string moviePath = "";
                string Year = "";
                string Season = "";
                string Episode = "";
                try
                {
                    moviePath = dgwMyVideos.Rows[i].Cells[1].Value.ToString();
                    Year = dgwMyVideos.Rows[i].Cells[2].Value.ToString();
                    Season = dgwMyVideos.Rows[i].Cells[4].Value.ToString();
                    Episode = dgwMyVideos.Rows[i].Cells[5].Value.ToString();
                    if (moviePath != "")
                        addToMyVideos(moviePath, Year, Season, Episode);
                }
                catch (Exception)
                {
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            imageListMyMoviesLarge.Images.Clear();
            listView2.Items.Clear();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                //MessageBox.Show(item.Name.ToString());
                //collect info
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Int32 value = Convert.ToInt16(textBoxMoviesPerPage.Text);
            if (value == 0)
                return;

            value--;
            textBoxMoviesPerPage.Text = value.ToString();

            if (listView1.Items.Count >= MaxListViews)
            {
                int difference = listView1.Items.Count - (MaxListViews + 1);
                for (int i = -1; i < difference;)
                {
                    int IndexLocation = MaxListViews + difference;
                    listView1.Items[IndexLocation].Remove();
                    imageList1.Images[IndexLocation].Dispose();
                 //   imageList2.Images[IndexLocation].Dispose();
                    difference--;
                }
            }
            UpdateMoviesInListView1();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Int32 value = Convert.ToInt16(textBoxMoviesPerPage.Text);
            value++;
            textBoxMoviesPerPage.Text = value.ToString();
            UpdateMoviesInListView1();
        }

        private void dgwMyVideos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
          
        }

        

       

   
    }
}
