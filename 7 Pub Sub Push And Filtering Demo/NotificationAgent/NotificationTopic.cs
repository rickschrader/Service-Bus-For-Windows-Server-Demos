using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace NotificationAgent
{
    public enum NotificationMessageType
    {
        All,
        Important,
        Unimportant
    }

    public class NotificationTopic
    {
        private const string MessagePropertyType = "Type";

        public delegate bool ReceiverCallback(NotificationMessage message, NotificationMessageType type);
        private ReceiverCallback _receiverCallback;

        private IAsyncResult _asyncResult;

        private readonly NamespaceManager _namespaceManager;
        private readonly MessagingFactory _messagingFactory;
        private readonly TopicClient _topicClient;
        private SubscriptionClient _subscriptionClient;

        public NotificationTopic(string topicName)
        {
            
            //TODO: Add security
            _namespaceManager = NamespaceManager.Create();
            _messagingFactory = MessagingFactory.Create();

            try
            {
                // doesn't always work, so wrap it
                if (!_namespaceManager.TopicExists(topicName))
                    _namespaceManager.CreateTopic(topicName);
            }
            catch (MessagingEntityAlreadyExistsException)
            {
                // ignore, timing issues could cause this
            }

            _topicClient = _messagingFactory.CreateTopicClient(topicName);      
        }

        public bool SendMessage(string message, NotificationMessageType messageType, TimeSpan msgLifespan)
        {
            var msg = new NotificationMessage { Body = message, Date = DateTime.Now };
            bool success;
            BrokeredMessage bm = null;

            try
            {
                bm = new BrokeredMessage(msg) {TimeToLive = msgLifespan};
                // used for filtering
                bm.Properties[MessagePropertyType] = messageType.ToString(); 
                _topicClient.Send(bm);
                success = true;
            }
            catch (Exception)
            {
                success = false;
                // TODO: do something
            }
            finally
            {
                if (bm != null) // if was created successfully
                    bm.Dispose();
            }

            return success;
        }

        public void StartReceiving(ReceiverCallback callback, SubscriptionClient subscriptionClient, NotificationMessageType msgType = NotificationMessageType.All)
        {
            StartReceiving(callback, subscriptionClient, new TimeSpan(5000));
        }

        public void StartReceiving(ReceiverCallback callback, SubscriptionClient subscriptionClient, TimeSpan waitTime)
        {

            _subscriptionClient = subscriptionClient;

            //TODO: Find a way to do this now that subscription client is moved to the subscriber
            //if (_subscriptionClient != null) // we already have a subscription
            //    throw new InvalidOperationException("Already Receiving. Stop previous operation first");

            if (_subscriptionClient == null) // we already have a subscription
                throw new InvalidOperationException("Subscription Client was not set.");

            
            _receiverCallback = callback;

            
            // make initial async call
            _asyncResult = _subscriptionClient.BeginReceive(waitTime, ReceiveDone, _subscriptionClient);
        }

        public void ReceiveDone(IAsyncResult result)
        {
            if (result != null)
            {
                var tmpClient = result.AsyncState as SubscriptionClient;

                if (tmpClient != null)
                {
                    var brokeredMessage = tmpClient.EndReceive(result);
                    
                    if (brokeredMessage != null)
                    {
                        //TODO: Handle both peeklock and receiveanddelete modes
                        brokeredMessage.Complete();

                        var tmpMessage = brokeredMessage.GetBody<NotificationMessage>();

                        #region translate the property back into a type
                        var tmpType = NotificationMessageType.All;
                        if (brokeredMessage.Properties[MessagePropertyType].ToString().Equals(NotificationMessageType.Important.ToString()))
                            tmpType = NotificationMessageType.Important;
                        else if (brokeredMessage.Properties[MessagePropertyType].ToString().Equals(NotificationMessageType.Unimportant.ToString()))
                            tmpType = NotificationMessageType.Unimportant;
                        #endregion

                        _receiverCallback(tmpMessage, tmpType);
                    }
                }
            }

            // do receive for next message
            if (_subscriptionClient != null)
                _asyncResult = _subscriptionClient.BeginReceive(ReceiveDone, _subscriptionClient);
        }

        public void StopReceiving()
        {

            if (_subscriptionClient == null) // we already have a subscription
                throw new InvalidOperationException("Subscription Client was not set.  You must call StartReceiving first.");


            if (_asyncResult != null)
            {
                _subscriptionClient.EndReceive(_asyncResult);
            }

            //if (_namespaceManager != null && _subscriptionClient != null)
            //{
            //    this.DeleteSubscription();
            //}
        }
    }


}
