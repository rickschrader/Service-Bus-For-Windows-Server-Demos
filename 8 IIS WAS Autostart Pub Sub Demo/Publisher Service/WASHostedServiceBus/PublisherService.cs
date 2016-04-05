using System.ServiceModel;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace PublisherService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class PublisherService : IPublisherService
    {
        private readonly TopicClient _topicClient;
        private const string TopicName = "WASPublisherServiceDemoTopic";

        public PublisherService()
        {
            var messageFactory = MessagingFactory.Create();
            var namespaceManager = NamespaceManager.Create();

            TopicDescription demoTopic;

            ////Only uncomment this when testing creating a fresh topic
            //if (namespaceManager.TopicExists(TopicName))
            //{
            //    namespaceManager.DeleteTopic(TopicName);
            //}

            if (!namespaceManager.TopicExists(TopicName))
            {

                demoTopic = new TopicDescription(TopicName);

                //TODO: Add permissions
                //const string domainUser = "USERNAME@DOMAIN";
                //AuthorizationRule allowRule = new AllowRule("ServiceBusDefaultNamespace", "role", domainUser,
                //                                            new List<AccessRights> { AccessRights.Manage, AccessRights.Send, AccessRights.Listen });

                //demoTopic.Authorization.Add(allowRule);

                namespaceManager.CreateTopic(demoTopic);
            }
            else
            {
                demoTopic = namespaceManager.GetTopic(TopicName);
            }

            //Create a topic client
            _topicClient = messageFactory.CreateTopicClient(demoTopic.Path);
        }

        //TODO: Consider having a single Publish method that accepts BrokeredMessage or make generic
        public void PublishString(string data)
        {
            var sendMessage = new BrokeredMessage(data);
            _topicClient.Send(sendMessage);
        }
    }
}