using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Domain.Entities.Shipping
{
    public class Warehouse: BaseEntity
    {
        public Guid SubscriptionId { get; set; }
          /// <summary>
        /// Gets or sets the warehouse name
        /// </summary>
        public string Name { get; set; }
        public string OtherName { get; set; }

        /// <summary>
        /// Gets or sets the admin comment
        /// </summary>
        public string AdminComment { get; set; }

        /// <summary>
        /// Gets or sets the address identifier of the warehouse
        /// </summary>
        public Guid AddressId { get; set; }
        
    }
}