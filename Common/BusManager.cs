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
            // Using Http to be friendly with outbound firewalls
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Http;
        }

        public NamespaceManager NamespaceManager
        {
            get
            {
                if (_namespaceManager == null)
                {
                    // Create the namespace manager which gives you access to management operations
                    _namespaceManager = NamespaceManager.CreateFromConnectionString(Settings.CONNECTION_STRING);
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
                    _messagingFactory = MessagingFactory.Create(NamespaceManager.Address, NamespaceManager.Settings.TokenProvider);
                }

                return _messagingFactory;
            }
        }

        public void DeleteAndCreateQueue(string queuePath)
        {
            // Delete the queue if exists
            if (NamespaceManager.QueueExists(queuePath))
            {
                NamespaceManager.DeleteQueue(queuePath);
            }

            NamespaceManager.CreateQueue(queuePath);
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

        public void DeleteAndCreateSubscription(string topicPath, string subscriptionName, Filter filter)
        {
            // Delete the subscription if exists
            if (NamespaceManager.SubscriptionExists(topicPath, subscriptionName))
            {
                NamespaceManager.DeleteSubscription(topicPath, subscriptionName);
            }

            NamespaceManager.CreateSubscription(topicPath, subscriptionName, filter);
        }

        public QueueClient CreateQueueClient(string queuePath)
        {
            return MessagingFactory.CreateQueueClient(queuePath);
        }

        public TopicClient CreateTopicClient(string topicPath)
        {
            return MessagingFactory.CreateTopicClient(topicPath);
        }

        public SubscriptionClient CreateSubscriptionClient(string topicPath, string subscriptionName)
        {
            return MessagingFactory.CreateSubscriptionClient(topicPath, subscriptionName);
        }
    }
}