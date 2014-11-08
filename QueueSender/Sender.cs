using System;
using System.Threading;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace QueueSender
{
    class Sender
    {
        static void Main(string[] args)
        {
            Console.Title = "Sender";
            Console.SetWindowSize(80, 25);
            
            var queueManager = new QueueManager();
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
