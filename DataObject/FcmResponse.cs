using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMSharp
{
    public class FcmResponse
    {
        public string DeviceId { get; set; }
        public bool HaveException { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public object ResponseData { get; set; }
    }
}
