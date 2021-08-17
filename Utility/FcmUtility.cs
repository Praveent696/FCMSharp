using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FCMSharp
{
    public class FcmUtility : IFcmUtility
    {
        private string _appID;
        private string _senderID;
        private IHttpHelper _httpHelper;
        public FcmUtility(string appId, string senderId)
        {
            _appID = appId;
            _senderID = senderId;
            _httpHelper = HttpHelper.Instance;
        }
        public async Task<List<FcmResponse>> SendBatchNotificationsAsync(List<NotificationConfig> configs)
        {
            List<FcmResponse> response = new List<FcmResponse>();
            foreach (var item in configs)
            {
                var resp = await SendNotificationAsync(item);
                response.Add(resp);
            }
            return response;
        }

        public async Task<FcmResponse> SendNotificationAsync(NotificationConfig config)
        {
            FcmResponse fcmResponse = await SendAsync(config.FcmDeviceToken, config.Message, config.Priority.ToString(), config.Title, config.customPayload,config.ignoreNotificationPayload);
            return fcmResponse;
        }

        private async Task<FcmResponse> SendAsync(string fcmDeviceToken, string message, string priority, string title, object dataPayload = null, bool ignoreNotificationPayload = false)
        {
            FcmResponse response = new FcmResponse()
            {
                DeviceId = fcmDeviceToken
            };
            var applicationID = _appID;
            var senderId = _senderID;
          
            var data = new NotificationPayload();
            if (!ignoreNotificationPayload)
            {
                data.notification = new Notification()
                {
                    body = message,
                    title = title
                };
            }
            data.data = dataPayload != null ? dataPayload : null;
            data.to = fcmDeviceToken;
            data.priority = priority;
            var json = JsonConvert.SerializeObject(data,
                Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            var headers = new Dictionary<string, string>();
            headers.Add(Constants.FcmRequestHeaders.AUTH_HEADER, applicationID);
            headers.Add(Constants.FcmRequestHeaders.SENDER_KEY, senderId);
            try
            {
                var fcmResponse = await _httpHelper.PostJson(Constants.HttpConstants.FCM_ENDPOINT, json, headers);
                JObject fcmResponseJson = JObject.Parse(fcmResponse);
                response.Success = Convert.ToInt32(fcmResponseJson["success"]) == 1;
                response.ResponseData = fcmResponseJson;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.HaveException = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
