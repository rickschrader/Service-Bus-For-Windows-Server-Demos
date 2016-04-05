using System;
using System.Threading;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using NotificationAgent;

namespace SubscriberSample1
{
    class Program
    {
        static NotificationTopic _notifier;

        const string TopicName = "PushNotificationDemoTopic";
        const string SubscriptionName = "SubscriberSample1Subscription";

        private static bool NotificationReceived(NotificationMessage message, NotificationMessageType type)
        {
            Console.WriteLine(@"Received Message - {0}, Type={1}", message.Body, type);
            
            return true;
        }

        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            
            //TODO: Add security
            var namespaceManager = NamespaceManager.Create();
            var messagingFactory = MessagingFactory.Create();

            //Only uncomment below if you want to delete the subcription and start over
            //namespaceManager.DeleteSubscription(TopicName,SubscriptionName);

            try
            {
                if (!namespaceManager.SubscriptionExists(TopicName, SubscriptionName))
                {
                    //Create a new filter
                    var filter = new SqlFilter(string.Format("{0} = '{1}'", "Type", NotificationMessageType.Important));

                    //Create the subscription (including the filter)
                    namespaceManager.CreateSubscription(TopicName, SubscriptionName, filter);
                }
               
            }
            catch (MessagingEntityAlreadyExistsException)
            {
                throw new InvalidOperationException(string.Format("Subscription named {0} already exists for topic {1}. Please change the subscription name and try again.", SubscriptionName, TopicName));
            }

            var subscriptionClient = messagingFactory.CreateSubscriptionClient(TopicName, SubscriptionName, ReceiveMode.PeekLock);

            _notifier = new NotificationTopic(TopicName);
            _notifier.StartReceiving(NotificationReceived, subscriptionClient);

            while (true)
            {

                Thread.Sleep(10000);
            }

        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            try
            {
                if (_notifier != null)
                    _notifier.StopReceiving();
            }
            catch (Exception exc)
            {
                Console.WriteLine(@"Exception during Stop: " + exc.Message);
            }
        }

    }

    

}
