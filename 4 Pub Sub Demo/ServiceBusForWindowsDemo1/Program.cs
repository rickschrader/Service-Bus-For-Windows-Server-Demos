using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusForWindowsDemo1
{
    class Program
    {

        //Could uncomment the configuration in the config file to use instead of coding the configuration
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
            

            //Create a NamespaceManager instance (for management operations) and a MessagingFactory instance (for sending and receiving messages)
            //MessagingFactory messageFactory = MessagingFactory.Create(); 
            var messageFactory = MessagingFactory.CreateFromConnectionString(connBuilder.ToString()); //connBuilder.ToString()
            //NamespaceManager namespaceManager = NamespaceManager.Create();
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connBuilder.ToString()); //connBuilder.ToString()

            //Create a topic
            const string topicName = "DemoTopic";
            if (namespaceManager == null)
            {
                Console.WriteLine("\nUnexpected Error: NamespaceManager is NULL");
                return;
            }

            //Only uncomment this when testing recreating a fresh topic
            //if (namespaceManager.TopicExists(topicName))
            //{
            //    namespaceManager.DeleteTopic(topicName);
            //}

            if (!namespaceManager.TopicExists(topicName))
            {
                namespaceManager.CreateTopic(topicName);
            }
           
            //Create a topic client
            var topicClient = messageFactory.CreateTopicClient(topicName);

            Console.Write("Type a message and press Enter to send (type EXIT to quit): ");

            var message = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(message) && (message != "EXIT"))
            {
                //Create a simple brokered message and send it
                var sendMessage1 = new BrokeredMessage(message);
                //Set a property so that we can filter on it in the subscription
                sendMessage1.Properties["Type"] = "Type1";
                topicClient.Send(sendMessage1);
                Console.WriteLine("Message sent: Body = {0}, Type = {1}", sendMessage1.GetBody<string>(), sendMessage1.Properties["Type"]);
                
                //Create another simple brokered message and send it (with a different property value)
                var sendMessage2 = new BrokeredMessage(message);
                //Set a property so that we can filter on it in the subscription
                sendMessage2.Properties["Type"] = "Type2";
                topicClient.Send(sendMessage2);
                Console.WriteLine("Message sent: Body = {0}, Type = {1}", sendMessage2.GetBody<string>(), sendMessage2.Properties["Type"]);

                
                Console.WriteLine();
                Console.Write("Type a message and press Enter to send (type EXIT to quit): ");
                message = Console.ReadLine();
            }

           
        }
    }
}
