using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace FileSubscriber1
{
    class Program
    {
        //This is just the file we're sending/receiving. It can be replaced with any arbitrary file larger than our splitting threshold
        private const string FileName = "SomeFile.ext";
        
        const string TopicName = "LargeMessageFileTopic";
        const string SubscriptionName = "Subscription1";
        static private readonly MessagingFactory MessagingFactory = MessagingFactory.Create();
        static private readonly NamespaceManager NamespaceManager = NamespaceManager.Create();
        static private SubscriptionClient _subscriptionClient;

        static void Main()
        {

            Console.WriteLine("Wait until the topic is created, then press Enter when ready to create subscription.");
            Console.ReadLine();

            //Create the subscription if it doesn't exist
            if (!NamespaceManager.SubscriptionExists(TopicName, SubscriptionName))
            {
                var subscription = new SubscriptionDescription(TopicName, SubscriptionName) { RequiresSession = true };
                NamespaceManager.CreateSubscription(subscription);
            }

            Console.WriteLine("Subscription created.");
            Console.WriteLine("Wait until the message is sent, then press Enter when ready to receive.");
            Console.ReadLine();

            // Create the subscription client
            _subscriptionClient = MessagingFactory.CreateSubscriptionClient(TopicName, SubscriptionName, ReceiveMode.PeekLock);

            var message = LargeMessageHelper.LargeMessageHelper.ReceiveLargeMessage(_subscriptionClient);
            if (message != null)
            {
                var bytes = message.GetBody<Byte[]>();

                if (System.IO.File.Exists(FileName))
                    System.IO.File.Delete(FileName);
                System.IO.File.WriteAllBytes(FileName, bytes);

                Console.WriteLine("Received message (Hash={0}, Size={1} bytes)",
                                    LargeMessageHelper.LargeMessageHelper.GetMd5HashFromFile(FileName), bytes.Length);

                Console.WriteLine("Press Enter to close.");
                Console.ReadLine();
            }

        }
    }
}
