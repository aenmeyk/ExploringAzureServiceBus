using System;
using Common;

namespace QueueReceiver
{
    class Receiver
    {
        static void Main(string[] args)
        {
            Console.Title = "Receiver";
            Console.SetWindowSize(80, 25);

            var queueManager = new QueueManager();
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
