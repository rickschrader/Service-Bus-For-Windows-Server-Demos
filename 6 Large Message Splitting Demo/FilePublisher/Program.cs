using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace FilePublisher
{
    class Program
    {
        //This is just the file we're sending/receiving. It can be replaced with any arbitrary file larger than our splitting threshold
        private const string FileName = "SomeFile.ext";

        const string TopicName = "LargeMessageFileTopic";
        static private readonly MessagingFactory MessagingFactory = MessagingFactory.Create();
        static private readonly NamespaceManager NamespaceManager = NamespaceManager.Create();
        static private TopicClient _topicClient;

        private static void Main()
        {

            Console.WriteLine("Creating topic.");

            //Create a topic
            if (NamespaceManager == null)
            {
                throw new FieldAccessException("NamespaceManager is NULL");
            }

            //Only uncomment this when testing creating a fresh topic
            if (NamespaceManager.TopicExists(TopicName))
            {
                NamespaceManager.DeleteTopic(TopicName);
            }
            NamespaceManager.CreateTopic(TopicName);

            Console.WriteLine("Topic was created.");
            Console.WriteLine("Wait until the subscription is created, then press Enter when ready to send.");
            Console.ReadLine();

            //Create a topic client
            _topicClient = MessagingFactory.CreateTopicClient(TopicName);

            var hash = LargeMessageHelper.LargeMessageHelper.GetMd5HashFromFile(FileName);

            var bytes = System.IO.File.ReadAllBytes(FileName);
            var sendMessage = new BrokeredMessage(bytes);
            LargeMessageHelper.LargeMessageHelper.SendLargeMessage(_topicClient, sendMessage);

            //This proves that sending as one message will fail
            //_topicClient.Send(sendMessage);

            Console.WriteLine("Sent message (Hash={0}, Size={1} bytes)", hash, bytes.Length);
            Console.WriteLine();
            Console.WriteLine("Press Enter to close.");
            Console.ReadLine();

        }
    }
}
