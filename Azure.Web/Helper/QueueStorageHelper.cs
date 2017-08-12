using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Web.Helper
{
    public class QueueStorageHelper
    {
        private static string CloudStorageString = "DefaultEndpointsProtocol=https;AccountName=pwnstorageaccount;AccountKey=gs8+19zH26niBDI4eMN0l94XylNLCxFOIXwmixQYnH7geFdke9Y2yyWmDK8RZTlyDvD2L4lk3uQYnXmsElvxpQ==;EndpointSuffix=core.windows.net";
        private static readonly Random random = new Random();

        public static CloudStorageAccount CloudStorageAccount
        {
            get
            {
                //return CloudStorageAccount.DevelopmentStorageAccount;
                return CloudStorageAccount.Parse(CloudStorageString);
            }
        }

        public static CloudQueueClient CloudQueueServiceClient
        {
            get
            {
                return CloudStorageAccount.CreateCloudQueueClient();
            }
        }

        public static CloudQueue GetQueueReference(string name)
        {
            var reference = CloudQueueServiceClient.GetQueueReference(name);
            reference.CreateIfNotExists();
            return reference;
        }

        public static void SendMsgToQueue(CloudQueue reference, string msg)
        {
            reference.AddMessage(new CloudQueueMessage(msg), TimeSpan.FromHours(3));
        }
        public static CloudQueueMessage ReadMsgFromQueue(CloudQueue reference)
        {
            var msg = reference.GetMessage();
            reference.DeleteMessage(msg);
            return msg;
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}