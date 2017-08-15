using System;
using System.Linq;
using Microsoft.ServiceBus.Messaging;

namespace Azure.Web.Helper
{
    public static class TopicsServiceBusHelper
    {
        private static string ServiceBusConnString = "Endpoint=sb://pwnsb11.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=xypMiV2LnRk+Y9KGih2x4SPHatsDbIC0R0bT7jZBhOU=";
        private static string TopicName = "tp1";
        private static string SubscriberName = "sb1";
        private static readonly Random random = new Random();

        public static TopicClient TopicClient
        {
            get
            {
                return TopicClient.CreateFromConnectionString(ServiceBusConnString,TopicName);
            }
        }

        public static SubscriptionClient SubscriptionClient
        {
            get { return SubscriptionClient.CreateFromConnectionString(ServiceBusConnString,TopicName,SubscriberName); }
        }

        public static void SendMsgToTopics(string msg)
        {
            TopicClient.Send(new BrokeredMessage(msg));
        }
        public static TopicsMessage ReadMsgFromTopics()
        {
            TopicsMessage message =new TopicsMessage();
            SubscriptionClient.OnMessage(msg =>
            {
                message.MsgContent = msg.GetBody<string>();
                message.BrokeredMessage = msg;
            });
            return message;
        }

        private static void callback(BrokeredMessage obj)
        {
            throw new NotImplementedException();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public class TopicsMessage
    {
        public BrokeredMessage BrokeredMessage { get; set; }
        public string MsgContent { get; set; }
    }
}