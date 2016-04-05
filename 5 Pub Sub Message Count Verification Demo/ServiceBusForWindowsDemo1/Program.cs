using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusForWindowsDemo1
{
    class Program
    {

        //Could uncomment the configuration in the config file to use instead of coding the configuration
        private const string ServerFQDN = "REPLACE WITH FULLY-QUALIFIED SERVER NAME";
        const int HttpPort = 9355;
        const int TcpPort = 9354;
        const string ServiceNamespace = "ServiceBusDefaultNamespace";
        

        static void Main(string[] args)
        {
            
            //Build the Service Bus connection string (again, not necessary if using config from the config file)
            var connBuilder = new ServiceBusConnectionStringBuilder();
            connBuilder.ManagementPort = HttpPort;
            connBuilder.RuntimePort = TcpPort;
            connBuilder.Endpoints.Add(new UriBuilder { Scheme = "sb", Host = ServerFQDN, Path = ServiceNamespace }.Uri);
            connBuilder.StsEndpoints.Add(new UriBuilder { Scheme = "https", Host = ServerFQDN, Port = HttpPort, Path = ServiceNamespace }.Uri);
            

            //Create a NamespaceManager instance (for management operations) and a MessagingFactory instance (for sending and receiving messages)
            //MessagingFactory messageFactory = MessagingFactory.Create(); 
            var messageFactory = MessagingFactory.CreateFromConnectionString(connBuilder.ToString()); 
            //NamespaceManager namespaceManager = NamespaceManager.Create();
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connBuilder.ToString()); 

            //Create a topic
            const string TopicName = "DemoTopic";
            if (namespaceManager == null)
            {
                Console.WriteLine("\nUnexpected Error: NamespaceManager is NULL");
                return;
            }

            TopicDescription demoTopic;

            if (!namespaceManager.TopicExists(TopicName))
            {
                demoTopic = namespaceManager.CreateTopic(TopicName);
            }
            else
            {
                demoTopic = namespaceManager.GetTopic(TopicName);
            }


            
            //Create a topic client
            var topicClient = messageFactory.CreateTopicClient(demoTopic.Path);

            Console.Write("Number of messages to send: ");

            var countString = Console.ReadLine();
            int count;

            while(!string.IsNullOrWhiteSpace(countString) && int.TryParse(countString, out count))
            {

                int numMessages = 0;

                for(int i = 1; i <= count; i++)
                {
                    //Create a simple brokered message and send it
                    var sendMessage = new BrokeredMessage(string.Format("Message {0}", i));
                    topicClient.Send(sendMessage);
                    Console.WriteLine("Message sent: Body = {0}", sendMessage.GetBody<string>());

                    numMessages++;
                }
                Console.WriteLine("Sent {0} messages.", numMessages);

                Console.WriteLine();
                Console.Write("Number of messages to send: ");

                countString = Console.ReadLine();
            }
           
        }
    }
}
