using System;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace DeadLetteringReceiver
{
    class Receiver
    {
        static void Main(string[] args)
        {
            Console.Title = "Receiver";

            var busManager = new BusManager();
            var queueClient = busManager.CreateQueueClient(QueuePaths.DEAD_LETTERING_DEMO, ReceiveMode.PeekLock);

            queueClient.OnMessage(message =>
            {
                var order = message.GetBody<Order>();

                if (order.Id%10 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    message.Abandon();
                }
                else
                {
                    Console.ForegroundColor = order.Color;
                    message.Complete();
                }

                Console.WriteLine(order.ToString());
            });

            Console.ReadLine();
        }
    }
}
