using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Subscriber2
{
    class Program
    {

        static System.Timers.Timer timer = new System.Timers.Timer(5000);
        static int numMessages = 0;

        static string ServerFQDN = "REPLACE WITH FULLY-QUALIFIED SERVER NAME";
        static int HttpPort = 9355;
        static int TcpPort = 9354;
        static string ServiceNamespace = "ServiceBusDefaultNamespace";

        static void Main(string[] args)
        {

            timer.Elapsed += TimerElapsed;

            //Build the Service Bus connection string (again, not necessary if using config from the config file)
            var connBuilder = new ServiceBusConnectionStringBuilder();
            connBuilder.ManagementPort = HttpPort;
            connBuilder.RuntimePort = TcpPort;
            connBuilder.Endpoints.Add(new UriBuilder() { Scheme = "sb", Host = ServerFQDN, Path = ServiceNamespace }.Uri);
            connBuilder.StsEndpoints.Add(new UriBuilder() { Scheme = "https", Host = ServerFQDN, Port = HttpPort, Path = ServiceNamespace }.Uri);


            var messageFactory = MessagingFactory.CreateFromConnectionString(connBuilder.ToString());
            var namespaceManager = NamespaceManager.CreateFromConnectionString(connBuilder.ToString()); //connBuilder.ToString()

            const string TopicName = "DemoTopic";
            const string SubscriptionName = "Subscription2";

            //Create the subscription (if it doesn't exist)
            if (!namespaceManager.SubscriptionExists(TopicName, SubscriptionName))
            {
                var inventorySubscription = namespaceManager.CreateSubscription(TopicName, SubscriptionName);
            }

            // Create the subscription client
            var agentSubscriptionClient = messageFactory.CreateSubscriptionClient(TopicName, SubscriptionName, ReceiveMode.PeekLock);

            Console.WriteLine(SubscriptionName);
            Console.WriteLine("----------------");

            while (true)
            {
                var message = agentSubscriptionClient.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    Console.WriteLine(string.Format("{0} message received: Id = {1}, Body = {2}", SubscriptionName, message.MessageId, message.GetBody<string>()));
                    message.Complete();
                    
                    numMessages++;

                    //When we receive a message, stop and restart the timer.  If the timer ever ticks, then display how many messages were processed
                    timer.Stop();
                    timer.Start();

                }

                System.Threading.Thread.Sleep(10);

            }
        }

        static void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            Console.WriteLine("Processed {0} messages.", numMessages);
            numMessages = 0;
        }

    }
}
