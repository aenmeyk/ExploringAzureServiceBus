using System;
using System.Diagnostics;
using Common;

namespace DeadLetteringOrchestrator
{
    class Orchestrator
    {
        static void Main(string[] args)
        {
            Console.Title = "Orchestrator";
            var busManager = new BusManager();

            Console.WriteLine("Creating Queue...");
            busManager.DeleteAndCreateQueue(QueuePaths.DEAD_LETTERING_DEMO);

            Console.WriteLine("Starting Sender...");
            Process.Start("DeadLetteringSender.exe");

            Console.WriteLine("Starting Receiver...");
            Process.Start("DeadLetteringReceiver.exe");

            Console.WriteLine("Starting Dead Letter Receiver...");
            Process.Start("DeadLetteringDeadLetterReceiver.exe");
        }
    }
}
