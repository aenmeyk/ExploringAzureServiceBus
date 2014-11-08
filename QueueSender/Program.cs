using System;
using System.Threading;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace QueueSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Sender";
            var queueManager = new QueueManager();
            queueManager.DeleteAndCreateQueue(QueueNames.QUEUE_DEMO);
            var queueClient = queueManager.CreateQueueClient(QueueNames.QUEUE_DEMO);
            var id = 0;

            do
            {
                while (!Console.KeyAvailable)
                {
                    Console.ForegroundColor = ColorGenerator.GetRandomColor();

                    var order = new Order
                    {
                        Id = id,
                        Name = "Order Number " + id,
                        Color = Console.ForegroundColor
                    };

                    var message = new BrokeredMessage(order);
                    queueClient.Send(message);

                    Console.WriteLine(order.ToString());
                    id++;

                    Thread.Sleep(300);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.ReadLine();
        }
    }
}
