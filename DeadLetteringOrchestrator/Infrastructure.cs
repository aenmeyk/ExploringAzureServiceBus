using System;
using Common;

namespace DeadLetteringOrchestrator
{
    class Infrastructure
    {
        static void Main()
        {
            Console.Title = "Infrastructure";

            var busManager = new BusManager();
            busManager.DeleteAndCreateQueue(QueuePaths.DEAD_LETTERING_DEMO);

            Console.WriteLine("Queue created: {0}", QueuePaths.DEAD_LETTERING_DEMO);
            Console.ReadKey();
        }
    }
}
