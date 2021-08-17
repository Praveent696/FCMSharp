using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FCMSharp.Constants;

namespace FCMSharp
{
    public class NotificationConfig
    {
        /// <summary>
        /// FCM Dveice token that is genrated at iOS/ Android/ Web end.
        /// </summary>
        public string FcmDeviceToken { get; set; }
        public string Message { get; set; }
        public MessagePriority Priority { get; set; }
        public string Title { get; set; }

        public bool ignoreNotificationPayload { get; set; }
        public object customPayload { get; set; }
    }
}
