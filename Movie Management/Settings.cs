using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Movie_Management
{
    public class Settings
    {
        static string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Movie Management\\";
        static string MySettings = MyDocuments + "\\settings.dat";

        private static string lastMovieWatched = null;

        public static string setLastMovie(string Input)
        {
            lastMovieWatched = Input;
            Form1.updateProgramName(Input);
            return lastMovieWatched;
        }

        public void init()
        {
            if (!Directory.Exists(MyDocuments))
                Directory.CreateDirectory(MyDocuments);

            if (!File.Exists(MySettings))
                File.Create(MySettings);
        }

        public static void saveSettings()
        {
            if (!File.Exists(MySettings))
                File.Create(MySettings).Dispose();

            using (FileStream fs = new FileStream(MySettings, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(lastMovieWatched+"\r\n");
            }
            Form1.updateProgramName(lastMovieWatched);
            /*
            StreamWriter file = new StreamWriter(MySettings);
            //file.WriteLine(lastMovieWatched + "\r\n");          
            file.Close();
            file.Dispose();
             * */
        }

        public static string getLastWatchedMovie()
        {
            return lastMovieWatched;
        }

        public static void loadSettings()
        {
            if (!File.Exists(MySettings))
                File.Create(MySettings).Dispose();

            //string[] mySettingsFile = File.ReadAllLines(MySettings);
            System.IO.StreamReader file =   new System.IO.StreamReader(MySettings);
            string line;
            int counter = 0;
            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    lastMovieWatched = line;                    
                    counter++;
                }
            }

            file.Close();
            /*
            using (StringReader reader = new StringReader(MySettings))
            {
                string line;
                int totalLines = 0;
                while ((line = reader.ReadLine()) != null)
                    if (line != "")
                    {
                        totalLines++;
                        lastMovieWatched = line;
                        Form1.updateProgramName(lastMovieWatched);
                    }
            }
             */


            //    Form1.loadFormSettings(mySettingsFile);
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;


            }).Start();
            
        }
    }
}
