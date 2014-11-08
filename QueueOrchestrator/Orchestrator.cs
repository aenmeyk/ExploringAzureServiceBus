using System;
using System.Diagnostics;
using Common;

namespace QueueOrchestrator
{
    class Orchestrator
    {
        static void Main(string[] args)
        {
            Console.Title = "Orchestrator";

            Console.WriteLine("Creating Queue...");
            var busManager = new BusManager();
            busManager.DeleteAndCreateQueue(QueuePaths.QUEUE_DEMO);

            Console.WriteLine("Starting Sender...");
            Process.Start("QueueSender.exe");

            Console.WriteLine("Starting Receiver...");
            Process.Start("QueueReceiver.exe");
        }
    }
}
