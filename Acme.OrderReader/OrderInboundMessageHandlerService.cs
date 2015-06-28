using System;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using Acme.OrderReader.Interfaces;
using Acme.Shared.Contracts;

namespace Acme.OrderReader
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
    public class OrderInboundMessageHandlerService : IOrderInboundMessageHandlerService
    {
        #region IOrderInboundMessageHandlerService Members

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<Order> incomingOrderMessage)
        {
            var orderRequest = incomingOrderMessage.Body;
            Console.WriteLine(orderRequest.OrderID);
            Console.WriteLine(orderRequest.ShipToAddress);
            Console.WriteLine(orderRequest.ShipToCity);
            Console.WriteLine(orderRequest.ShipToCountry);
            Console.WriteLine(orderRequest.ShipToZipCode);
            Console.WriteLine(orderRequest.SubmittedOn);
        }

        #endregion
    }
}
