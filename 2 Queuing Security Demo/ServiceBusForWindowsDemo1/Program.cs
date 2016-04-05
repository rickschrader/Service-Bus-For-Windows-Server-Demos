using System;
using System.Collections.Generic;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusForWindowsDemo1
{
    class Program
    {

        static void Main()
        {
            const string queueName = "ServiceBusSecurityQueueSample";
            
            //Create a NamespaceManager instance (for management operations)
            // NOTE: Namespace-level security is handled via PowerShell configuration on the namespace itself
            var namespaceManager = NamespaceManager.Create();
          

            // Example of granting a domain user listen permissions to a queue
            var queue = new QueueDescription(queueName);
            const string issuer = "ServiceBusDefaultNamespace";
            var domainUser = string.Format(@"{0}@{1}", "REPLACE WITH USERNAME", Environment.GetEnvironmentVariable("USERDNSDOMAIN"));
            var accessRights = new List<AccessRights> {AccessRights.Listen};

            AuthorizationRule listenRule = new AllowRule(issuer, "nameidentifier", domainUser, accessRights);
            queue.Authorization.Add(listenRule);
            
            if (namespaceManager.QueueExists(queueName))
            {
                namespaceManager.DeleteQueue(queueName);
            }
            queue = namespaceManager.CreateQueue(queue);


            //List out the access rules for the queue
            ListAccessRules(queue);
            

            //Create a MessagingFactory instance (for sending and receiving messages)
            const string hostname = "REPLACE WITH FULLY-QUALIFIED SERVER NAME";
            const string sbNamespace = "ServiceBusDefaultNamespace";
            var stsUris = new List<Uri> {new Uri(string.Format(@"sb://{0}:9355/", hostname))};
            var tokenProvider = TokenProvider.CreateWindowsTokenProvider(stsUris);

            var runtimeAddress = string.Format("sb://{0}:9354/{1}/", hostname, sbNamespace);
            //var messageFactory = MessagingFactory.Create(runtimeAddress, 
            //    new MessagingFactorySettings() { TokenProvider = tokenProvider, 
            //        OperationTimeout = TimeSpan.FromMinutes(30) });
            var messageFactory = MessagingFactory.Create(runtimeAddress, tokenProvider);
            
            
            
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

        private static void ListAccessRules(QueueDescription queue)
        {
            foreach (var rule in queue.Authorization)
            {
                Console.WriteLine(@"Auth rule: ClaimType={0}, ClaimValue={1}, IssuerName={2}, Rights={3}", rule.ClaimType, rule.ClaimValue, rule.IssuerName, rule.Rights);
            }
        }

    }
}
