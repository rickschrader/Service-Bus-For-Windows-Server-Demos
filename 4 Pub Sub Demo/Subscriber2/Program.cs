using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Subscriber2
{
    class Program
    {
        private const string ServerFqdn = "REPLACE WITH FULLY-QUALIFIED SERVER NAME";
        private const int HttpPort = 9355;
        private const int TcpPort = 9354;
        private const string ServiceNamespace = "ServiceBusDefaultNamespace";

        static void Main()
        {

            //Build the Service Bus connection string (again, not necessary if using config from the config file)
            var connBuilder = new ServiceBusConnectionStringBuilder();
            connBuilder.ManagementPort = HttpPort;
            connBuilder.RuntimePort = TcpPort;
            connBuilder.Endpoints.Add(new UriBuilder { Scheme = "sb", Host = ServerFqdn, Path = ServiceNamespace }.Uri);
            connBuilder.StsEndpoints.Add(new UriBuilder { Scheme = "https", Host = ServerFqdn, Port = HttpPort, Path = ServiceNamespace }.Uri);


            var messageFactory = MessagingFactory.CreateFromConnectionString(connBuilder.ToString());
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connBuilder.ToString()); 

            const string topicName = "DemoTopic";
            const string subscriptionName = "Subscription2";

            //Give the publisher some time to create the topic
            System.Threading.Thread.Sleep(5000);

            //Create the subscription (if it doesn't exist)
            if (!namespaceManager.SubscriptionExists(topicName, subscriptionName))
            {
                //Do not filter messages at all, so it will be subscribed to ALL messages, regardless of type

                namespaceManager.CreateSubscription(topicName, subscriptionName);
            }

            // Create the subscription client
            var subscriptionClient = messageFactory.CreateSubscriptionClient(topicName, subscriptionName, ReceiveMode.PeekLock);

            Console.WriteLine(subscriptionName);
            Console.WriteLine("----------------");

            while (true)
            {
                var message = subscriptionClient.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    Console.WriteLine("{0} message received: Id = {1}, Body = {2}, Type = {3}", 
                        subscriptionName, message.MessageId, message.GetBody<string>(), message.Properties["Type"]);
                    message.Complete();
                }

                System.Threading.Thread.Sleep(10);

            }      
    
        }
    }
}
