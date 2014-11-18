using System;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace ScatterGatherVendorB
{
    class VendorB
    {
        static void Main()
        {
            Console.Title = "Vendor B";

            var busManager = new BusManager();
            var subscriptionClient = busManager.CreateSubscriptionClient(TopicPaths.SCATTER_GATHER_DEMO, SubscriptionNames.VENDOR_B);
            var queueClient = busManager.CreateQueueClient(QueuePaths.SCATTER_GATHER_AGGREGATOR_DEMO);

            subscriptionClient.OnMessage(requestMessage =>
            {
                var quoteRequest = requestMessage.GetBody<QuoteRequest>();
                Console.ForegroundColor = quoteRequest.Product;

                var quoteResponse = new QuoteResponse(quoteRequest)
                {
                    Price = GetPrice(quoteRequest.Product),
                    Vendor = "VendorB"
                };

                var responseMessage = new BrokeredMessage(quoteResponse)
                {
                    SessionId = quoteResponse.QuoteId.ToString(),
                    MessageId = string.Format("{0}_{1}", quoteResponse.QuoteId, quoteResponse.Vendor)
                };

                queueClient.Send(responseMessage);

                Console.WriteLine(quoteResponse.ToString());
            });

            Console.ReadLine();
        }

        private static int GetPrice(ConsoleColor product)
        {
            switch (product)
            {
                case ConsoleColor.Cyan:
                    return 90;
                case ConsoleColor.Yellow:
                    return 60;
                default:
                    return 0;
            }
        }
    }
}
