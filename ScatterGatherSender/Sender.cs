using System;
using System.Threading;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace ScatterGatherSender
{
    class Sender
    {
        static void Main()
        {
            Console.Title = "Sender";

            var busManager = new BusManager();
            var topicClient = busManager.CreateTopicClient(TopicPaths.SCATTER_GATHER_DEMO);
            var id = 0;

            while (true)
            {
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.ForegroundColor = ColorGenerator.GetRandomColor();

                        var quoteRequest = new QuoteRequest
                        {
                            QuoteId = id,
                            Product = Console.ForegroundColor
                        };

                        var message = new BrokeredMessage(quoteRequest);
                        topicClient.Send(message);

                        Console.WriteLine(quoteRequest.ToString());
                        id++;

                        Thread.Sleep(300);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
             
                Console.ReadKey();
            }
        }
    }
}
