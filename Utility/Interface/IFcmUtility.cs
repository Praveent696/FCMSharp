using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCMSharp
{
    public interface IFcmUtility
    {
        Task<FcmResponse> SendNotificationAsync(NotificationConfig config);
        Task<List<FcmResponse>> SendBatchNotificationsAsync(List<NotificationConfig> configs);
    }
}
