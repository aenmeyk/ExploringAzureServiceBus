using System;
using Common;

namespace DeadLetteringDeadLetterReceiver
{
    class DeadLetterReceiver
    {
        static void Main()
        {
            Console.Title = "Dead Letter Receiver";
            Console.ForegroundColor = ConsoleColor.Red;

            var busManager = new BusManager();
            var deadLetterQueueClient = busManager.CreateQueueClient(QueuePaths.DEAD_LETTERING_DEMO + "/$DeadLetterQueue");

            deadLetterQueueClient.OnMessage(message =>
            {
                var order = message.GetBody<Order>();
                Console.WriteLine(order.ToString());
            });

            Console.ReadLine();
        }
    }
}
