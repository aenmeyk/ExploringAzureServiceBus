using System;
using Common;

namespace QueueReceiver
{
    class Receiver
    {
        static void Main()
        {
            Console.Title = "Receiver";

            var busManager = new BusManager();
            var queueClient = busManager.CreateQueueClient(QueuePaths.QUEUE_DEMO);

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
