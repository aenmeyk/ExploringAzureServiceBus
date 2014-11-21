using System;
using Common;

namespace QueueOrchestrator
{
    class Infrastructure
    {
        static void Main()
        {
            Console.Title = "Infrastructure";

            var busManager = new BusManager();
            busManager.DeleteAndCreateQueue(QueuePaths.QUEUE_DEMO);

            Console.WriteLine("Queue created: {0}", QueuePaths.QUEUE_DEMO);
            Console.ReadKey();
        }
    }
}
