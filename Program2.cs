using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XServiceBusQueueSender
{
    class Program
    {
        static async Task 
        XMain(string[] args)
        {
            // Create a list of variable values
            var variableValues = new List<string> { "XYZ", "ABC", "DEF" };

            // Send the messages to the queue
            await SendMessagesAsync(variableValues);

            Console.WriteLine("Messages sent successfully. Press any key to exit.");
            Console.ReadKey();
        }

        public static async Task SendMessagesAsync(List<string> variableValues)
        {


            // Create a QueueClient instance
            QueueClient queueClient = new QueueClient("connectionString", "queueName");

            try
            {
                // Create a list of messages to send
                var messages = new List<Message>();
                foreach (var value in variableValues)
                {
string messageBody = $@"
{{
    ""I_EXT_REF32"": ""DispatchContainer"",
    ""I_TEST"": null,
    ""ET_BIT_SRCTA_BIT0"": null,
    ""ET_RETURN"": null,
    ""IT_BIT_IT"": [
        {{
            ""ExtensionData"": ""{value}"",
            ""SRCTATYPE"": ""ZCPMD"",
            ""SRCTAID"": ""YYYYMMDD"",
            ""SRCTASUBID"": ""0001"",
            ""SUBPROCESS"": ""ARRT""
        }}
    ]
}}";



                    Console.WriteLine(messageBody);
                    Message message = new Message(Encoding.UTF8.GetBytes(messageBody));
                    messages.Add(message);
                }

                // Send the messages to the queue
          //      await queueClient.SendAsync(messages);
            }
            finally
            {
                // Close the QueueClient instance
                await queueClient.CloseAsync();
            }
        }
    }
}