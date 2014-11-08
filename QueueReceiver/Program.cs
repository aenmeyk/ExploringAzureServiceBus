using System;
using Common;

namespace QueueReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Receiver";
            var queueManager = new QueueManager();
            queueManager.CreateQueue(QueueNames.QUEUE_DEMO);
            var queueClient = queueManager.CreateQueueClient(QueueNames.QUEUE_DEMO);

            queueClient.OnMessage(message =>
            {
                var order = message.GetBody<Order>();
                Console.ForegroundColor = order.Color;
                Console.WriteLine(order.ToString());
            });

            Console.ReadLine();
        }
    }
}
