using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.IO;

namespace Movie_Management

{
    public static class HTTP
    {
        public static string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36";
        public static CookieContainer Cookies = new CookieContainer();
        public static string DoGET(string URL)
        {
            string responsezdd = "";
            try
            {

                string uridd = URL;
                HttpWebRequest requestdd = (HttpWebRequest)
                WebRequest.Create(uridd);
                requestdd.KeepAlive = false;

                requestdd.AllowAutoRedirect = true;
                requestdd.PreAuthenticate = true;
                requestdd.Pipelined = true;
                requestdd.CookieContainer = Cookies;
                requestdd.UserAgent = UserAgent;
                requestdd.ContentType = "application/x-www-form-urlencoded";
                requestdd.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                requestdd.Timeout = 10000;
                requestdd.Method = "GET";

                HttpWebResponse WebRespdd = (HttpWebResponse)requestdd.GetResponse();
                Stream Answerdd = WebRespdd.GetResponseStream();
                StreamReader _Answerdd = new StreamReader(Answerdd);
                responsezdd = _Answerdd.ReadToEnd();
                WebRespdd.Close();
            }
            catch (Exception)
            {
                return null;
            }

            return responsezdd;
        }

 
      
        public static string DoPOST(string URL, string POST_DATA)
        {
            try
            {
                string uri = URL;
                string post_datat = POST_DATA;
                byte[] buffert = Encoding.ASCII.GetBytes(post_datat);
                string responsez;

                HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(uri);
                request.KeepAlive = true;
                request.AllowAutoRedirect = true;
                request.PreAuthenticate = true;
                request.Pipelined = true;
                request.CookieContainer = Cookies;

                request.UserAgent = UserAgent;
                request.ContentLength = buffert.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Referer = "http://www.facebook.com/";

                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";
                Stream PostData = request.GetRequestStream();
                PostData.Write(buffert, 0, buffert.Length);
                PostData.Close();
                HttpWebResponse WebRespx1 = (HttpWebResponse)request.GetResponse();
                Stream Answerx1 = WebRespx1.GetResponseStream();
                StreamReader _Answerx1 = new StreamReader(Answerx1);
                responsez = _Answerx1.ReadToEnd();
                WebRespx1.Close();
                return responsez;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
