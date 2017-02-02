using FCMSharp.DataObject;
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
    public class FCMSharp
    {

        private string appID = "";
        private string senderID = "";
        public void ConfigureFCMSharp(FCMConfig config)
        {
            appID = config.ApplicationID;
            senderID = config.SenderID;
        }
        public bool SendToSingle(FCMDevice fcmdevice)
        {
            bool status = SendNotification(fcmdevice);
            return status;
        }
        public bool SendToMultiple(List<FCMDevice> fcmdevices)
        {
            bool status = false;
            foreach (var device in fcmdevices)
            {
                status = SendNotification(device);
            } 
            return status;
        }
        private bool SendNotification(FCMDevice fcmdevices)
        {
            bool status = true;
            try
            {
                var applicationID = appID;
                var senderId = senderID;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = fcmdevices.DeviceToken,
                    priority = fcmdevices.Priority,
                    notification = new
                    {
                        body = fcmdevices.Message,
                        title = fcmdevices.Title
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                JObject sResponse = JObject.Parse(sResponseFromServer);
                                if (Convert.ToInt32(sResponse["success"]) == 1)
                                {
                                    status = true;
                                }
                                else
                                {
                                    status = false;
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                status = false;
            }

            return status;
        }

    }


}
