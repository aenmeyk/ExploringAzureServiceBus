using System;
using Common;

namespace PubSubReceiverAll
{
    class ReceiverYellow
    {
        static void Main()
        {
            Console.Title = "Receiver (all messages)";

            var busManager = new BusManager();
            var subscriptionClient = busManager.CreateSubscriptionClient(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.ALL);

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
