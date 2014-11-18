using System;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace PubSubReceiverCyan
{
    class ReceiverCyan
    {
        static void Main()
        {
            Console.Title = "Cyan Receiver";

            var busManager = new BusManager();
            var subscriptionClient = busManager.CreateSubscriptionClient(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.CYAN);

            subscriptionClient.OnMessage(message =>
            {
                var order = message.GetBody<Order>();
                Console.ForegroundColor = order.Color;
                Console.WriteLine(order.ToString());
            });

            Console.ReadLine();
        }
    }
}
