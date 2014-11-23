using System;
using Common;

namespace ScatterGatherOrchestrator
{
    class Infrastructure
    {
        static void Main()
        {
            Console.Title = "Infrastructure";
            var busManager = new BusManager();

            busManager.DeleteAndCreateTopic(TopicPaths.SCATTER_GATHER_DEMO);
            Console.WriteLine("Topic created: {0}", TopicPaths.SCATTER_GATHER_DEMO);

            busManager.DeleteAndCreateSubscription(TopicPaths.SCATTER_GATHER_DEMO, SubscriptionNames.VENDOR_A);
            Console.WriteLine("Subscription created: {0}", SubscriptionNames.VENDOR_A);

            busManager.DeleteAndCreateSubscription(TopicPaths.SCATTER_GATHER_DEMO, SubscriptionNames.VENDOR_B);
            Console.WriteLine("Subscription created: {0}", SubscriptionNames.VENDOR_B);

            busManager.DeleteAndCreateSessionQueue(QueuePaths.SCATTER_GATHER_AGGREGATOR_DEMO);
            Console.WriteLine("Queue created: {0}", QueuePaths.SCATTER_GATHER_AGGREGATOR_DEMO);

            Console.ReadKey();
        }
    }
}
