using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Movie_Management
{
    class FindMovies
    {
        private static string[] AllowedVideoTypes = new string[] {"\\.avi", "\\.mp4", "\\.wmp", "\\.mkv", "\\.m4v" };
        private static CheckBox cb;
        private static long minVideoLength = 1000000;
        public static List<string> crawlDirectory(string Path, CheckBox ignoreSamples, CheckBox replacePeriods)
        {
                
                cb = ignoreSamples;
                List<string> videosFound = new List<string>();
                foreach (var file in Directory.GetFiles(Path))
                {
                    string replacement = file;

                    if (replacePeriods.Checked)
                    {
                        string endString = file.Substring(file.Length - 4);
                        replacement = file.Substring(0, file.Length - 4);
                        replacement = replacement.Replace(".", " ");
                        replacement = replacement + endString;

                        if (file != replacement)
                            File.Move(file, replacement);
                    }
                    bool bigEnough = false;
                    FileInfo videoInfo = new FileInfo(replacement);
                    if (videoInfo.Length > minVideoLength)
                        bigEnough = true;


                    if (isVideo(replacement) && bigEnough)
                        videosFound.Add(replacement);

                }
                foreach (var dir in Directory.GetDirectories(Path))
                {

                    string cleanedDir = dir;
                    if (replacePeriods.Checked)
                    {
                        cleanedDir = dir.Replace(".", " ");

                        if (cleanedDir != dir)
                        {
                            try
                            {
                                Directory.Move(dir, cleanedDir);
                            }
                            catch (Exception)
                            {
                                break;
                            }

                        }

                    }

                    foreach (var file in Directory.GetFiles(cleanedDir))
                    {
                        string replacement = file;

                        if (replacePeriods.Checked)
                        {
                            string endString = file.Substring(file.Length - 4);
                            replacement = file.Substring(0, file.Length - 4);
                            replacement = replacement.Replace(".", " ");
                            replacement = replacement + endString;

                            try
                            {
                                if (file != replacement)
                                    File.Move(file, replacement);
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                        bool bigEnough = false;
                        FileInfo videoInfo = new FileInfo(replacement);
                        if (videoInfo.Length > minVideoLength)
                            bigEnough = true;


                        if (isVideo(replacement) && bigEnough)
                            videosFound.Add(replacement);


                    }
                }
                return videosFound;
         
        }

        public static void saveSettings(List<string> Folders, string Dir)
        {
            if (!Directory.Exists(Dir))
                Directory.CreateDirectory(Dir);

            string FilePath = Dir + "video_folders.dat";
            if (!File.Exists(FilePath))
                File.Create(FilePath).Dispose();

            StreamWriter file = new StreamWriter(FilePath);
            for (int i = 0; i < Folders.Count; i++)
            {
                file.WriteLine(Folders[i]);
            }
            file.Close();
        }


        public static string whatType(string input)
        {
            for (int i = 0; i < AllowedVideoTypes.Length; i++)
            {
                bool ignore = false;
                if (cb.Checked == true)
                {
                    Match containsSamples = Regex.Match(input, "sample", RegexOptions.IgnoreCase);
                    if(containsSamples.Success)
                        ignore = true;
                        
                }
               if(!ignore)
               {
                    Match rightType = Regex.Match(input, AllowedVideoTypes[i], RegexOptions.IgnoreCase);
                    if (rightType.Success)
                        return rightType.Value.ToString();
               }
                
            }
            return null;
        }

        private static bool isVideo(string File)
        {
            for (int i = 0; i < AllowedVideoTypes.Length; i++)
            {
                bool ignore = false;
                if (cb.Checked == true)
                {
                    Match containsSamples = Regex.Match(File, "sample", RegexOptions.IgnoreCase);
                    if (containsSamples.Success)
                    {
                        ignore = true;
                        return false;
                    }
                        
                }
                if (!ignore)
                {
                    Match rightType = Regex.Match(File, AllowedVideoTypes[i], RegexOptions.IgnoreCase);
                    if (rightType.Success)
                        return true;
                }
            }
            return false;
        }

    }
}
