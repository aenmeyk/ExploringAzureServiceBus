using System;
using System.Diagnostics;
using Common;

namespace ScatterGatherOrchestrator
{
    class Orchestrator
    {
        static void Main()
        {
            Console.Title = "Orchestrator";
            var busManager = new BusManager();

            Console.WriteLine("Creating Topic...");
            busManager.DeleteAndCreateTopic(TopicPaths.SCATTER_GATHER_DEMO);

            Console.WriteLine("Creating Vendor A Subscription...");
            busManager.DeleteAndCreateSubscription(TopicPaths.SCATTER_GATHER_DEMO, SubscriptionNames.VENDOR_A);

            Console.WriteLine("Creating Vendor B Subscription...");
            busManager.DeleteAndCreateSubscription(TopicPaths.SCATTER_GATHER_DEMO, SubscriptionNames.VENDOR_B);

            Console.WriteLine("Creating Aggregator Queue...");
            busManager.DeleteAndCreateSessionQueue(QueuePaths.SCATTER_GATHER_AGGREGATOR_DEMO);

            Console.WriteLine("Starting Sender...");
            Process.Start("ScatterGatherSender.exe");

            Console.WriteLine("Starting Vendor A Receiver...");
            Process.Start("ScatterGatherVendorA.exe");

            Console.WriteLine("Starting Vendor B Receiver...");
            Process.Start("ScatterGatherVendorB.exe");

            Console.WriteLine("Starting Aggregator...");
            Process.Start("ScatterGatherAggregator.exe");
        }
    }
}
