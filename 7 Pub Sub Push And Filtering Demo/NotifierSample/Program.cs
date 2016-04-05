using System;

using NotificationAgent;

namespace NotifierSample
{
    class Program
    {
        static void Main()
        {
            const string topicName = "PushNotificationDemoTopic";
            
            int msgCnt = 0;

            var notifier = new NotificationTopic(topicName);

            // cleanup
            //tmpNotifier.DeleteTopic(); // only uncomment this if you're running this first and want to reset the topic

            while (true) // loop to send messages every 3 seconds
            {

                var msg = "Message #: " + msgCnt++; // uniquely ID each message
                NotificationMessageType type;

                //TODO: make sure to set a reasonable time-to-live
                //Send a message with "Important" type
                type = NotificationMessageType.Important;
                notifier.SendMessage(msg, type, new TimeSpan(1000,0,0,0));

                Console.WriteLine(@"Sent Message - {0}, Type={1}", msg, type);
            

                
                msg = "Message #: " + msgCnt++; // uniquely ID each message

                //TODO: make sure to set a reasonable time-to-live
                //Send a message with "Unimportant" type
                type = NotificationMessageType.Unimportant;
                notifier.SendMessage(msg, type, new TimeSpan(1000,0,0,0));

                Console.WriteLine(@"Received Message - {0}, Type={1}", msg, type);
            

                System.Threading.Thread.Sleep(1000); // sleep for 1 second
            }

        }
    }
}
