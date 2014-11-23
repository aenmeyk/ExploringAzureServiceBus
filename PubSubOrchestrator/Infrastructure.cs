using System;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace PubSubOrchestrator
{
    class Infrastructure
    {
        static void Main()
        {
            Console.Title = "Infrastructure";

            var busManager = new BusManager();
            busManager.DeleteAndCreateTopic(TopicPaths.PUB_SUB_DEMO);
            Console.WriteLine("Topic created: {0}", TopicPaths.PUB_SUB_DEMO);

            busManager.DeleteAndCreateSubscription(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.ALL);
            Console.WriteLine("Subscription created: {0}", SubscriptionNames.ALL);

            var cyanFilter = new CorrelationFilter(ConsoleColor.Cyan.ToString());
            busManager.DeleteAndCreateSubscription(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.CYAN, cyanFilter);
            Console.WriteLine("Subscription created: {0}", SubscriptionNames.CYAN);

            var yellowFilter = new CorrelationFilter(ConsoleColor.Yellow.ToString());
            busManager.DeleteAndCreateSubscription(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.YELLOW, yellowFilter);
            Console.WriteLine("Subscription created: {0}", SubscriptionNames.YELLOW);
            
            Console.ReadKey();
        }
    }
}
