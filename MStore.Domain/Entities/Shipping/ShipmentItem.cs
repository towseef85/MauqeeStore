using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Shipping
{
    public class ShipmentItem : BaseEntity
    {
        public Guid SubscriptionId { get; set; }
        public Guid ShipmentId { get; set; }

        /// <summary>
        /// Gets or sets the order item identifier
        /// </summary>
        public Guid OrderItemId { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the warehouse identifier
        /// </summary>
        public Guid WarehouseId { get; set; }
    }
}