using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FCMSharp
{
    public interface IHttpHelper
    {
        Task<string> Get(string uri);
        Task<string> PostJson(string uri, string json, Dictionary<string, string> headears);
    }
}
