using System;

namespace TestApp
{
    class Program
    {
        static void Main()
        {
            var client = new PublisherService.PublisherServiceClient();

            while (true)
            {
                Console.Write("Enter a message to send: ");
                var text = Console.ReadLine();
                if(!string.IsNullOrEmpty(text))
                    client.PublishString(text);
            }

        }
    }
}
