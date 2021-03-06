﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace ScatterGatherAggregator
{
    class Aggregator
    {
        static void Main()
        {
            Console.Title = "Aggregator";

            var busManager = new BusManager();
            var queueClient = busManager.CreateQueueClient(QueuePaths.SCATTER_GATHER_AGGREGATOR_DEMO);

            while (true)
            {
                var quoteResponses = new Collection<QuoteResponse>();
                var messageSession = queueClient.AcceptMessageSession(TimeSpan.FromDays(365));
                BrokeredMessage message;

                while (quoteResponses.Count < 2 && (message = messageSession.Receive(TimeSpan.FromSeconds(5))) != null)
                {
                    var quoteResponse = message.GetBody<QuoteResponse>();
                    quoteResponses.Add(quoteResponse);
                }

                messageSession.Close();
                var lowestQuote = quoteResponses.OrderBy(x => x.Price).First();
                Console.ForegroundColor = lowestQuote.Product;
                Console.WriteLine(lowestQuote.ToString());
            }
        }
    }
}
