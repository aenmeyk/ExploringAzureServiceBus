using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Common
{
    public class QueueManager
    {
        private NamespaceManager _namespaceManager;

        public QueueManager()
        {
            // Using Http to be friendly with outbound firewalls
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Http;
        }

        private NamespaceManager NamespaceManager
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

        public void CreateQueue(string queueName)
        {
            // Create the queue if it does not exist
            if (!NamespaceManager.QueueExists(queueName))
            {
                NamespaceManager.CreateQueue(queueName);
            }
        }

        public void DeleteAndCreateQueue(string queueName)
        {
            // Delete the queue if exists
            if (NamespaceManager.QueueExists(queueName))
            {
                NamespaceManager.DeleteQueue(queueName);
            }

            CreateQueue(queueName);
        }

        public QueueClient CreateQueueClient(string queueName)
        {
            // Get a client to the queue
            var messagingFactory = MessagingFactory.Create(NamespaceManager.Address, NamespaceManager.Settings.TokenProvider);
            return messagingFactory.CreateQueueClient(queueName);
        }
    }
}