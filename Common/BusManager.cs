using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Common
{
    public class BusManager
    {
        private NamespaceManager _namespaceManager;
        private MessagingFactory _messagingFactory;

        public BusManager()
        {
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Tcp;
        }

        public NamespaceManager NamespaceManager
        {
            get
            {
                if (_namespaceManager == null)
                {
                    // Create the namespace manager which gives you access to management operations
                    _namespaceManager = NamespaceManager.CreateFromConnectionString(Settings.CONNECTION_STRING_AMQP);
                }

                return _namespaceManager;
            }
        }

        public MessagingFactory MessagingFactory
        {
            get
            {
                if (_messagingFactory == null)
                {
                    // This is the anchor class used for run-time operations that send and receive messages to and from queues, topics, or subscriptions.
                    _messagingFactory = MessagingFactory.Create(NamespaceManager.Address, NamespaceManager.Settings.TokenProvider);
                }

                return _messagingFactory;
            }
        }

        public void DeleteAndCreateQueue(string queuePath)
        {
            DeleteQueueIfExists(queuePath);
            NamespaceManager.CreateQueue(queuePath);
        }

        public void DeleteAndCreateSessionQueue(string queuePath)
        {
            DeleteQueueIfExists(queuePath);

            var queueDescription = new QueueDescription(queuePath)
            {
                RequiresSession = true
            };

            NamespaceManager.CreateQueue(queueDescription);
        }

        public void DeleteAndCreateTopic(string topicPath)
        {
            // Delete the topic if exists
            if (NamespaceManager.TopicExists(topicPath))
            {
                NamespaceManager.DeleteTopic(topicPath);
            }

            NamespaceManager.CreateTopic(topicPath);
        }

        public void DeleteAndCreateSubscription(string topicPath, string subscriptionName)
        {
            DeleteSubscriptionIfExists(topicPath, subscriptionName);
            NamespaceManager.CreateSubscription(topicPath, subscriptionName);
        }

        public void DeleteAndCreateSubscription(string topicPath, string subscriptionName, Filter filter)
        {
            DeleteSubscriptionIfExists(topicPath, subscriptionName);
            NamespaceManager.CreateSubscription(topicPath, subscriptionName, filter);
        }

        public QueueClient CreateQueueClient(string queuePath, ReceiveMode receiveMode = ReceiveMode.ReceiveAndDelete)
        {
            return MessagingFactory.CreateQueueClient(queuePath, receiveMode);
        }

        public TopicClient CreateTopicClient(string topicPath)
        {
            return MessagingFactory.CreateTopicClient(topicPath);
        }

        public SubscriptionClient CreateSubscriptionClient(string topicPath, string subscriptionName)
        {
            return MessagingFactory.CreateSubscriptionClient(topicPath, subscriptionName, ReceiveMode.ReceiveAndDelete);
        }

        private void DeleteSubscriptionIfExists(string topicPath, string subscriptionName)
        {
            // Delete the subscription if exists
            if (NamespaceManager.SubscriptionExists(topicPath, subscriptionName))
            {
                NamespaceManager.DeleteSubscription(topicPath, subscriptionName);
            }
        }

        private void DeleteQueueIfExists(string queuePath)
        {
            // Delete the queue if exists
            if (NamespaceManager.QueueExists(queuePath))
            {
                NamespaceManager.DeleteQueue(queuePath);
            }
        }
    }
}