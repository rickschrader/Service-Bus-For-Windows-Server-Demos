using System;
using System.Windows.Forms;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Publisher
{
    public partial class Form1 : Form
    {
        const string TopicName = "LargeMessageImageTopic";
        private readonly MessagingFactory _messagingFactory = MessagingFactory.Create();
        private readonly NamespaceManager _namespaceManager = NamespaceManager.Create();
        private readonly TopicClient _topicClient;

        public Form1()
        {
            InitializeComponent();
            
            if (!DesignMode)
            {

                //Create a topic
                if (_namespaceManager == null)
                {
                    throw new FieldAccessException("NamespaceManager is NULL");
                }

                //Only uncomment this when testing creating a fresh topic
                if (_namespaceManager.TopicExists(TopicName))
                {
                    _namespaceManager.DeleteTopic(TopicName);
                }
                _namespaceManager.CreateTopic(TopicName);

                
                //Create a topic client
                _topicClient = _messagingFactory.CreateTopicClient(TopicName);

            }

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            var pictureBox = (PictureBox) sender;
            var sendMessage = new BrokeredMessage(pictureBox.Image);
            //_topicClient.Send(sendMessage);
            LargeMessageHelper.LargeMessageHelper.SendLargeMessage(_topicClient, sendMessage);

            statusLabel.Text = string.Format("Sent {0}", pictureBox.Tag);

        }


    }
}
