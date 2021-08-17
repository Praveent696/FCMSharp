using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMSharp
{
    public static class Constants
    {
        public enum MessagePriority
        {
            high,
            normal,
            low
        }
        public class HttpConstants
        {
            public const string FCM_ENDPOINT = "https://fcm.googleapis.com/fcm/send";
            public const string POST_METHOD = "POST";
        }

        public class ContentType
        {
            public const string APPLICATION_JSON = "application/json";
            public const string APPLICATION_XML = "application/xml";
        }

        public class FcmRequestHeaders
        {
            public const string AUTH_HEADER = "Authorization: key={0}";
            public const string SENDER_KEY = "Sender: id={0}";
        }
    }
}
