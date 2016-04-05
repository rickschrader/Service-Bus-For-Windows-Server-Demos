using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusForWindowsDemo1
{
    class Program
    {
        //The configuration in the config file can be uncommented to use instead of coding the configuration like this
        private const string ServerFqdn = "REPLACE WITH FULLY QUALIFIED SERVER NAME";
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
            var messageFactory = MessagingFactory.CreateFromConnectionString(connBuilder.ToString());
            //NamespaceManager namespaceManager = NamespaceManager.Create();
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connBuilder.ToString());

            //Create a new queue
            const string queueName = "ServiceBusQueueSample";
            if (namespaceManager == null)
            {
                Console.WriteLine("\nUnexpected Error: NamespaceManager is NULL");
                return;
            }
            if (namespaceManager.QueueExists(queueName))
            {
                namespaceManager.DeleteQueue(queueName);
            }
            namespaceManager.CreateQueue(queueName);

            //Create a queue client to send and receive messages to and from the queue
            var myQueueClient = messageFactory.CreateQueueClient(queueName);

            //Create a simple brokered message and send it to the queue
            var sendMessage = new BrokeredMessage("Hello World!");
            myQueueClient.Send(sendMessage);
            Console.WriteLine("Message sent: Body = {0}", sendMessage.GetBody<string>());
            
            //Receive the message from the queue
            var receivedMessage = myQueueClient.Receive(TimeSpan.FromSeconds(5));
            if (receivedMessage != null)
            {
                Console.WriteLine("Message received: Body = {0}", receivedMessage.GetBody<string>());
                receivedMessage.Complete();
            }

            //Close the connection to the Service Bus
            messageFactory.Close();

            Console.WriteLine("Press Enter to close.");
            Console.ReadLine();

        }
    }
}
