﻿using System;
using System.Threading;
using Common;
using Microsoft.ServiceBus.Messaging;

namespace PubSubSender
{
    class Sender
    {
        static void Main()
        {
            Console.Title = "Sender";

            var busManager = new BusManager();
            var topicClient = busManager.CreateTopicClient(TopicPaths.PUB_SUB_DEMO);
            var id = 0;

            while (true)
            {
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        Console.ForegroundColor = ColorGenerator.GetRandomColor();

                        var order = new Order
                        {
                            Id = id,
                            Name = "Order Number " + id,
                            Color = Console.ForegroundColor
                        };

                        var message = new BrokeredMessage(order);
                        message.CorrelationId = Console.ForegroundColor.ToString();

                        topicClient.Send(message);

                        Console.WriteLine(order.ToString());
                        id++;

                        Thread.Sleep(300);
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

                Console.ReadKey();
            }
        }
    }
}
