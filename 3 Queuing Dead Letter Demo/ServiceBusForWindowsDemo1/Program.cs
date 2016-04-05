using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusForWindowsDemo1
{
    class Program
    {

        static void Main()
        {
            const string queueName = "QueueDeadLetterDemo";
            
            //Create a NamespaceManager instance (for management operations)
            var namespaceManager = NamespaceManager.Create();


            var queue = new QueueDescription(queueName)
                {
                    //Make sure expired messages go to the dead letter queue
                    EnableDeadLetteringOnMessageExpiration = true,
                    //Set the expiration to 1 second so all messages expire quickly (1 second is the minimum for this)
                    //DefaultMessageTimeToLive = TimeSpan.FromSeconds(1)
           
                };

            
            if (namespaceManager.QueueExists(queueName))
            {
                namespaceManager.DeleteQueue(queueName);
            }
            queue = namespaceManager.CreateQueue(queue);

            Console.WriteLine("EnableDeadLetterOnExpiration = {0}", queue.EnableDeadLetteringOnMessageExpiration);
            //Console.WriteLine("DefaultMessageTimeToLive = {0}", queue.DefaultMessageTimeToLive);
            

            //Create a MessagingFactory instance (for sending and receiving messages)
            var messageFactory = MessagingFactory.Create();
            
            //Create a queue client to send and receive messages to and from the queue
            var queueClient = messageFactory.CreateQueueClient(queueName, ReceiveMode.ReceiveAndDelete);

            //Create a simple brokered message and send it to the queue
            var sendMessage = new BrokeredMessage("Hello World!");
          
            //Set an expiration on the message
            sendMessage.TimeToLive = TimeSpan.FromSeconds(1);
            queueClient.Send(sendMessage);
            Console.WriteLine("Message sent: Body = {0}", sendMessage.GetBody<string>());
            
            Console.WriteLine();
            Console.WriteLine("Waiting to begin receiving...");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Receiving...");

            //Verify the message did expire
            //NOTE: Messages are NOT expired/deadlettered until a client attempts to receive messages
            var receivedMessage = queueClient.Receive(TimeSpan.FromSeconds(5));
            if (receivedMessage != null)
            {
                Console.WriteLine("Queue message received: Body = {0}", receivedMessage.GetBody<string>());
                receivedMessage.Complete();
            }
            else
            {
                Console.WriteLine("No queue message received.");
            }

            //Create a queue client for the dead letter queue
            string deadLetterQueuePath = QueueClient.FormatDeadLetterPath(queueName);
            var deadletterQueueClient = messageFactory.CreateQueueClient(deadLetterQueuePath);

            //Receive the message from the dead letter queue
            BrokeredMessage deadLetterMessage = null;

            while (deadLetterMessage == null)
            {
                deadLetterMessage = deadletterQueueClient.Receive(TimeSpan.FromSeconds(5));
                if (deadLetterMessage != null)
                {
                    Console.WriteLine("Dead letter message received: Body = {0}", deadLetterMessage.GetBody<string>());
                    deadLetterMessage.Complete();
                }
                else
                {
                    Console.WriteLine("No message received yet... waiting...");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Trying again...");
                }
            }
            //Close the connection to the Service Bus
            messageFactory.Close();

            Console.WriteLine("Press Enter to close.");
            Console.ReadLine();

        }

    }
}
