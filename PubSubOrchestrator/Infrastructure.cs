using System;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace PubSubOrchestrator
{
    class Infrastructure
    {
        static void Main()
        {
            Console.Title = "Orchestrator";

            var busManager = new BusManager();
            busManager.DeleteAndCreateTopic(TopicPaths.PUB_SUB_DEMO);
            Console.WriteLine("Topic created: {0}", TopicPaths.PUB_SUB_DEMO);

            var cyanSqlFilter = CreateColorFilter(ConsoleColor.Cyan);
            busManager.DeleteAndCreateSubscription(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.CYAN, cyanSqlFilter);
            Console.WriteLine("Subscription created: {0}", SubscriptionNames.CYAN);

            var yellowSqlFilter = CreateColorFilter(ConsoleColor.Yellow);
            busManager.DeleteAndCreateSubscription(TopicPaths.PUB_SUB_DEMO, SubscriptionNames.YELLOW, yellowSqlFilter);
            Console.WriteLine("Subscription created: {0}", SubscriptionNames.YELLOW);
            
            Console.ReadKey();
        }

        private static SqlFilter CreateColorFilter(ConsoleColor consoleColor)
        {
            var sqlExpression = string.Format(@"Color = '{0}'", consoleColor);
            var sqlFilter = new SqlFilter(sqlExpression);

            return sqlFilter;
        }
    }
}
