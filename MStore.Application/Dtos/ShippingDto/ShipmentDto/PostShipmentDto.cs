using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.ShippingDto.ShipmentDto
{
    public class PostShipmentDto
    {

        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
         
        public Guid OrderId { get; set; }
        
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the total weight of this shipment
        /// It's nullable for compatibility with the previous version of mauqee where was no such property
        /// </summary>
        public decimal? TotalWeight { get; set; }
        public DateTime? ShippedDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

       
        public DateTime? ReadyForPickupDate { get; set; }

        public string AdminComment { get; set; }
    }
}