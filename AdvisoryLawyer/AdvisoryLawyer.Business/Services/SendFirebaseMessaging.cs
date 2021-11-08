using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace AdvisoryLawyer.Business.Services
{
    public static class SendFirebaseMessaging
    {
        public static async Task<string> SendNotification(string uid, string title, string body, string channel)
        {          

            try
            {
                var message = new Message()
                {
                    Data = new Dictionary<string, string>()
                    {
                        ["channel"] = channel
                    },
                    Notification = new Notification
                    {
                        Title = title,
                        Body = body
                    },

                    Topic = uid
                };
                var messaging = FirebaseMessaging.DefaultInstance;
                return await messaging.SendAsync(message);
            }
            catch (Exception e)
            {
               return e.Message;
            }
        }
    }
}
