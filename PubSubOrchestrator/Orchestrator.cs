using System;
using System.Diagnostics;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace PubSubOrchestrator
{
    class Orchestrator
    {
        static void Main(string[] args)
        {
            Console.Title = "Orchestrator";
            var busManager = new BusManager();

            Console.WriteLine("Creating Topic...");
            busManager.DeleteAndCreateTopic(TopicPaths.PUB_SUB_DEMO);

            Console.WriteLine("Creating Cyan Subscription...");
            var cyanSqlExpression = string.Format(@"Color = '{0}'", ConsoleColor.Cyan);
            var cyanSqlFilter = new SqlFilter(cyanSqlExpression);
            busManager.DeleteAndCreateSubscription(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.CYAN, cyanSqlFilter);

            Console.WriteLine("Creating Yellow Subscription...");
            var yellowSqlExpression = string.Format(@"Color = '{0}'", ConsoleColor.Yellow);
            var yellowSqlFilter = new SqlFilter(yellowSqlExpression);
            busManager.DeleteAndCreateSubscription(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.YELLOW, yellowSqlFilter);

            Console.WriteLine("Starting Sender...");
            Process.Start("PubSubSender.exe");

            Console.WriteLine("Starting Cyan Receiver...");
            Process.Start("PubSubReceiverCyan.exe");

            Console.WriteLine("Starting Yellow Receiver...");
            Process.Start("PubSubReceiverYellow.exe");
        }
    }
}
