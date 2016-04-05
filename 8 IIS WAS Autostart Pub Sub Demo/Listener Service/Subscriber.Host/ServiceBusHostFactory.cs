using System;
using System.Globalization;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Subscriber.Host
{
    public class ServiceBusHostFactory : ServiceHostFactoryBase
    {
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var messageFactory = MessagingFactory.Create();
            var namespaceManager = NamespaceManager.Create();

            const string topicName = "WASPublisherServiceDemoTopic";
            const string subscriptionName = "Subscription1";

            if (!namespaceManager.TopicExists(topicName))
                namespaceManager.CreateTopic(topicName);

            if (!namespaceManager.SubscriptionExists(topicName, subscriptionName))
                namespaceManager.CreateSubscription(topicName, subscriptionName);

            var subscriptionClient = messageFactory.CreateSubscriptionClient(topicName, subscriptionName, ReceiveMode.PeekLock);

            subscriptionClient.BeginReceive(subscriptionClient_EndReceive, subscriptionClient);

            return new ServiceHost(typeof(NullService.NullService), baseAddresses);
        }

        void subscriptionClient_EndReceive(IAsyncResult ar)
        {
            var subscriptionClient = (SubscriptionClient) ar.AsyncState;

            if (subscriptionClient != null)
            {
                var message = subscriptionClient.EndReceive(ar);

                if (message != null)
                {
                    using (var fs = new FileStream(@"C:\ServiceBusListenerLog.txt", FileMode.Append, FileAccess.Write))
                    {
                        using (var sw = new StreamWriter(fs))
                        {
                            sw.WriteLine("{0} - {1}", DateTime.Now.ToString(CultureInfo.InvariantCulture), message.GetBody<string>());
                            sw.Flush();
                        }
                    }

                    message.Complete();
                }

                subscriptionClient.BeginReceive(subscriptionClient_EndReceive, subscriptionClient);
            }
        }
    }
}