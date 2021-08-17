using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FCMSharp
{
    public sealed class HttpHelper : IHttpHelper
    {
        private static HttpHelper _instance;
        private HttpHelper() { }

        private static readonly object lockObject = new Object();
        public static HttpHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new HttpHelper();
                        }
                    }
                }
                return _instance;
            }
        }
        public async Task<string> Get(string uri)
        {
            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(new Uri(uri));

            string result = await execute(httpWReq);
            return result;
        }

        public async Task<string> PostJson(string uri, string json, Dictionary<string,string> headears)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(json);

            HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/json";
            httpWReq.ContentLength = bytes.Length;
            if (headears.Count > 0)
            {
                foreach (var item in headears)
                {
                    httpWReq.Headers.Add(string.Format(item.Key, item.Value));
                }
            }
            using (Stream stream = httpWReq.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }

            string result = await execute(httpWReq);
            return result;
        }

        private async Task<string> execute(HttpWebRequest httpWReq)
        {
            HttpWebResponse response = (HttpWebResponse)(await httpWReq.GetResponseAsync());
            string charset = response.CharacterSet;
            Stream inputStream = response.GetResponseStream();

            string responseString;
            if (string.IsNullOrWhiteSpace(charset))
            {
                responseString = new StreamReader(inputStream, true).ReadToEnd();
            }
            else
            {
                Encoding encoding = Encoding.GetEncoding(charset);
                responseString = new StreamReader(inputStream, encoding).ReadToEnd();
            }
            return responseString;
        }

    }
}
