using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Subscriber1
{
    public partial class Subscriber1 : Form
    {

        const string TopicName = "LargeMessageImageTopic";
        const string SubscriptionName = "Subscription1";
        private readonly MessagingFactory _messagingFactory = MessagingFactory.Create();
        private readonly NamespaceManager _namespaceManager = NamespaceManager.Create();
        private SubscriptionClient _subscriptionClient;

        public Subscriber1()
        {
            InitializeComponent();

            createSubscriptionTimer.Start();
        }

        private void createSubscriptionTimer_Tick(object sender, EventArgs e)
        {
            if (_namespaceManager.TopicExists(TopicName))
            {
                //Stop trying to create the subscription
                createSubscriptionTimer.Stop();

                
                //Create the subscription if it doesn't exist
                if (!_namespaceManager.SubscriptionExists(TopicName, SubscriptionName))
                {
                    var subscription = new SubscriptionDescription(TopicName, SubscriptionName) {RequiresSession = true};
                    _namespaceManager.CreateSubscription(subscription);
                }
                
                // Create the subscription client
                _subscriptionClient = _messagingFactory.CreateSubscriptionClient(TopicName, SubscriptionName,
                                                                                 ReceiveMode.PeekLock);

                statusLabel.Text = @"Created subscription.";
                
                //Start receiving
                fetchTimer.Start();

            }

        }

        private void fetchTimer_Tick(object sender, EventArgs e)
        {
            
            var message = LargeMessageHelper.LargeMessageHelper.ReceiveLargeMessage(_subscriptionClient);
            if (message != null)
                pictureBox.Image = message.GetBody<Bitmap>();

            //var message = _subscriptionClient.Receive(TimeSpan.FromSeconds(5));
            //if (message != null)
            //{
            //    pictureBox.Image = message.GetBody<Bitmap>();
            //    message.Complete();
            //}
        }

    }
}
