using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMSharp.DataObject
{
    public class FCMConfig
    {
        public string ApplicationID { get; set; }
        public string SenderID { get; set; }
    }
    public class FCMDevice
    {
        public string DeviceToken { get; set; }
        public string Message { get; set; }
        public string Priority { get; set; }
        public string Title { get; set; }
    }
}
