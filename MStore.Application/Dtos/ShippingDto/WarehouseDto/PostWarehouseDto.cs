using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.ShippingDto.WarehouseDto
{
    public class PostWarehouseDto
    {
        public Guid Id { get; set; }
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
        public int AddressId { get; set; }
    }
}