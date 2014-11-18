using System;
using Common;

namespace PubSubReceiverYellow
{
    class ReceiverYellow
    {
        static void Main()
        {
            Console.Title = "Yellow Receiver";

            var busManager = new BusManager();
            var subscriptionClient = busManager.CreateSubscriptionClient(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.YELLOW);

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
