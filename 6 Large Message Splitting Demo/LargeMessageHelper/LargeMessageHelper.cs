using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.ServiceBus.Messaging;

namespace LargeMessageHelper
{
    static public class LargeMessageHelper
    {

        //Note: Max message size for SBWS is 50mb (see http://msdn.microsoft.com/en-us/library/windowsazure/jj193026(v=azure.10).aspx)

        //Using message size of 192 kb, convert to bytes since BrokeredMessage.Size is in bytes
        private const int SubMessageBodySize = 192 * 1024;

        static public void SendLargeMessage(TopicClient client, BrokeredMessage message)
        {
            var messageBodySize = message.Size;
            
            // Calculate the number of sub messages required.
            var numSubMessages = (int)(messageBodySize / SubMessageBodySize);
            if (messageBodySize % SubMessageBodySize != 0)
            {
                numSubMessages++;
            }

            // Create a unique session Id.
            var sessionId = Guid.NewGuid().ToString();
            var bodyStream = message.GetBody<Stream>();
            var messages = new List<BrokeredMessage>();

            for (int streamOffset = 0; streamOffset < messageBodySize; streamOffset += SubMessageBodySize)
            {
                // Get the stream chunk from the large message
                long arraySize = ((messageBodySize - streamOffset) > SubMessageBodySize) ? SubMessageBodySize : messageBodySize - streamOffset;

                var subMessageBytes = new byte[arraySize];
                bodyStream.Read(subMessageBytes, 0, (int)arraySize);
                var subMessageStream = new MemoryStream(subMessageBytes);

                // Create a new message using the session id
                var subMessage = new BrokeredMessage(subMessageStream, true) { SessionId = sessionId };

                //Set a property telling us the total number of messages in the "batch"
                subMessage.Properties["TotalCount"] = numSubMessages;

                // Send the submessage
                client.Send(subMessage);
                messages.Add(subMessage);

            }

            //Exception if more than 8 messages??
            //client.SendBatch(messages);

        }

        static public BrokeredMessage ReceiveLargeMessage(SubscriptionClient client)
        {
            // Create a memory stream to store the large message body.
            var largeMessageStream = new MemoryStream();

            // Accept a message session from the queue.
            MessageSession session;
            try
            {
                session = client.AcceptMessageSession(TimeSpan.FromSeconds(5));
            }
            catch (TimeoutException)
            {
                //If getting a session times out, just return from the method.  
                //This timeout generally means there were no session-ful messages waiting 
                return null;
            }

            
            var noMoreMessagesAvailable = false;
            //Set to an absurdly high value initially. Will be set to the correct count after the first message is received
            int totalNumMessages = int.MaxValue;
            int numMessagesReceived = 0;

            //Keep a list of the messages so we can Complete them once we've received all
            var subMessages = new List<BrokeredMessage>();
            
            while ((numMessagesReceived < totalNumMessages) && !noMoreMessagesAvailable)
            {
               
                // Receive a sub message
                var subMessage = session.Receive(TimeSpan.FromSeconds(5));

                if (subMessage != null)
                {
                    if (subMessage.Properties.ContainsKey("TotalCount"))
                        totalNumMessages = (int)subMessage.Properties["TotalCount"];
                    
                    // Copy the sub message body to the large message stream.
                    var subMessageStream = subMessage.GetBody<Stream>();
                    subMessageStream.CopyTo(largeMessageStream);

                    // Mark the message as complete.
                    //subMessage.Complete();

                    subMessages.Add(subMessage);

                    numMessagesReceived++;
                }
                else
                {
                    //Bail out of the loop if no more messages are found. Note: this waits on the 5 second timeout.
                    noMoreMessagesAvailable = true;
                }
            }

            //If we didn't receive all the messages, abandon so they'll be picked up again
            if (numMessagesReceived != totalNumMessages)
            {
                foreach (var message in subMessages)
                    message.Abandon();

                return null;
            }

            //If we did receive all the messages, then complete them
            foreach (var message in subMessages)
                message.Complete();

            // Create an aggregated message from the large message stream.
            var largeMessage = new BrokeredMessage(largeMessageStream, true);
            return largeMessage;

        }

        static public string GetMd5HashFromFile(string fileName)
        {
            var file = new FileStream(fileName, FileMode.Open);
            var md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            var sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                //Append in hex format
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        static public string GetMd5HashFromBytes(byte[] bytes)
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(bytes);
            
            var sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                //Append in hex format
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

    }
}
