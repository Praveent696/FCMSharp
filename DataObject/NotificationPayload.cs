using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMSharp
{
    public class NotificationPayload
    {
        public string to { get; set; }
        public string priority { get; set; }
        public Notification notification { get; set; }
        public object data { get; set; }

    }

    public class Notification
    {
        public string body { get; set; }
        public string title { get; set; }
    }
}
