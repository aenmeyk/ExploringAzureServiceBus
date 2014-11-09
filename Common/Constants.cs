namespace Common
{
    public static class Settings
    {
        public const string CONNECTION_STRING_SBMP = "Endpoint=sb://aenmey.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=7+p7yKNF0vzMVGzabKURRqEk71YaHaaoG6dAZTezrWo=";
        public const string CONNECTION_STRING_AMQP = "Endpoint=sb://aenmey.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=7+p7yKNF0vzMVGzabKURRqEk71YaHaaoG6dAZTezrWo=;TransportType=Amqp";
    }

    public static class QueuePaths
    {
        public const string QUEUE_DEMO = "queue-demo";
    }

    public static class TopicPaths
    {
        public const string PUB_SUB_DEMO = "pub-sub-demo";
    }

    public static class SubscriptionNames
    {
        public const string CYAN = "cyan";
        public const string YELLOW = "yellow";
    }
}
