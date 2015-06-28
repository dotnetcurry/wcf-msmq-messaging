using System;
using System.Configuration;
using System.Messaging;
using System.Transactions;
using Acme.Shared.Contracts;

namespace DNCDispatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a fake order, for simulation:
            var anOrder = new Order { OrderID = 1, ShipToAddress = "123 Abc avenue", ShipToCity = "DNC", ShipToCountry = "A country", ShipToZipCode = "12345", SubmittedOn = DateTime.UtcNow };
            
            // create a MessageQueue to tell MSMQ where to send the message and how to connect to it
            var queue = new MessageQueue(ConfigurationManager.AppSettings["MessageQueuePath"]);

            // Create a Message and set the body to the order object above
            var msg = new Message { Body = anOrder };

            // Create a transaction
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                queue.Send(msg, MessageQueueTransactionType.Automatic); // send the message
                ts.Complete(); // complete the transaction
            }

            Console.WriteLine("Message Sent");
            Console.ReadLine();
        }
    }
}
