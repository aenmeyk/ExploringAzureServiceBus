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
            var busManager = new BusManager();

            Console.WriteLine("Creating Queue...");
            busManager.DeleteAndCreateQueue(QueuePaths.QUEUE_DEMO);

            Console.WriteLine("Starting Sender...");
            Process.Start("QueueSender.exe");

            Console.WriteLine("Starting Receiver...");
            Process.Start("QueueReceiver.exe");
        }
    }
}
