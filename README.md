# FCMSharp

FCMSharp is C# based library, that enables you to send push notification over diffrent plateform like Android, iOS. 
It is integrated solution for all your push notification problem.

## Getting Started

<ul>
<li>Setup FCM app on https://firebase.google.com/ . </li>
<li>To use FCMSharp you just have to add reference of library using Nuget Package Manager. </li>
<ul>

### Prerequisites

.NET Framework 4.0 and above.

### Installing

Open Nuget Pakage Manager and Install FCMSharp using following command

```
PM> Install-Package Praveent696.FCMSharp

```

## Language Used

* C#.

## Example Code 

* You can use FCMSharp like this
 
 * 1. Send Push To single device
  ```C#
            FCMSharp.FCMSharp fcmSharp = new FCMSharp.FCMSharp();

            FCMSharp.DataObject.FCMConfig config = new FCMSharp.DataObject.FCMConfig();
            config.ApplicationID = "AIxxxxxxxxxxxxxxxxxxxxxxxxxxxxxjxs";
            config.SenderID = "";  // Sender ID can be blank
            fcmSharp.ConfigureFCMSharp(config);

            FCMSharp.DataObject.FCMDevice device = new FCMSharp.DataObject.FCMDevice  { 
            new FCMSharp.DataObject.FCMDevice{ 
            Priority = "high",
            DeviceToken = "exxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxP",
            Message = "Hi User, this test notification is sent by FCMSharp Nuget",
            Title = "Alert"
            }
            };

            bool status = fcmSharp.SendToSingle(device);
  
  ```
  * 2. Send Push To Multiple devices
  
  ```C#
            FCMSharp.FCMSharp fcmSharp = new FCMSharp.FCMSharp();

            FCMSharp.DataObject.FCMConfig config = new FCMSharp.DataObject.FCMConfig();
            config.ApplicationID = "AIxxxxxxxxxxxxxxxxxxxxxxxxxxxxxjxs";
            config.SenderID = "";  // Sender ID can be blank
            fcmSharp.ConfigureFCMSharp(config);

            List<FCMSharp.DataObject.FCMDevice> device = new List<FCMSharp.DataObject.FCMDevice>  { 
            new FCMSharp.DataObject.FCMDevice{ 
            Priority = "high",
            DeviceToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
            Message = "Hi User, this test notification is sent by FCMSharp Nuget",
            Title = "Alert"
            //}
            },
             new FCMSharp.DataObject.FCMDevice{ 
            Priority = "high",
            DeviceToken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
            Message = "QHi User, this test notification is sent by FCMSharp Nuget",
            Title = "AlertQ"
            }
            };

            bool status = fcmSharp.SendToMultiple(device);
  
  ```

## Authors

* **Praveen Tiwari** - [Praveent696](https://github.com/Praveent696)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details
