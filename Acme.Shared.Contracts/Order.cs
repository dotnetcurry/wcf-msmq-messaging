using System;
using System.Runtime.Serialization;

namespace Acme.Shared.Contracts
{
    [DataContract]
    public class Order
    {
        public Order()
        {
        }

        [DataMember(IsRequired = true)]
        public int OrderID { get; set; }
        
        [DataMember(IsRequired = true)]
        public DateTime SubmittedOn { get; set; }
        
        [DataMember(IsRequired = true)]
        public string ShipToAddress { get; set; }

        [DataMember(IsRequired = true)]
        public string ShipToCity { get; set; }

        [DataMember(IsRequired = true)]
        public string ShipToCountry { get; set; }

        [DataMember(IsRequired = true)]
        public string ShipToZipCode { get; set; }

    }
}
