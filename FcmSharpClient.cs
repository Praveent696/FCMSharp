using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FCMSharp
{
    public class FcmSharpClient : IFcmSharpClient
    {
        private IFcmUtility _fcmUtility;
        public FcmSharpClient(string appId,string senderID)
        {
            _fcmUtility = new FcmUtility(appId, senderID);
        }
        public async Task<FcmResponse> SendNotificationAsync(NotificationConfig config)
        {
            var response = await _fcmUtility.SendNotificationAsync(config);
            return response;
        }
        public async Task<List<FcmResponse>> SendBatchNotificationsAsync(List<NotificationConfig> configs)
        {
            var response = await _fcmUtility.SendBatchNotificationsAsync(configs);
            return response;
        }
    }
}
