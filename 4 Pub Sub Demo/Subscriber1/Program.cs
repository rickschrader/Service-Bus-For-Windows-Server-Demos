using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Subscriber1
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
            //const string subscriptionName = "status_verifications";
            const string subscriptionName = "Subscription1";

            //Give the publisher some time to create the topic
            System.Threading.Thread.Sleep(5000);

            //Only uncomment to reset the subscription
            //namespaceManager.DeleteSubscription(topicName, subscriptionName);

            
            //Create the subscription (if it doesn't exist)
            if (!namespaceManager.SubscriptionExists(topicName, subscriptionName))
            {
                //Only subscribe to messages that are Type1
                var filter = new SqlFilter("Type = 'Type1'");

                namespaceManager.CreateSubscription(topicName, subscriptionName, filter);
            }
            

            // Create the subscription client
            var subscriptionClient = messageFactory.CreateSubscriptionClient(topicName, subscriptionName, ReceiveMode.PeekLock);

            Console.WriteLine(subscriptionName);
            Console.WriteLine("----------------");

            while(true)
            {
                var message = subscriptionClient.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    Console.WriteLine("{0} message received: Id = {1}; delivery count = {2}", 
                        subscriptionName, message.MessageId, message.DeliveryCount);
                    message.Abandon();
                }

                System.Threading.Thread.Sleep(10);

            }
                                   
        }
    }
}
