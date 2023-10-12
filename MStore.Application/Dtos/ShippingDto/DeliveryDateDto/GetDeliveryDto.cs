using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.ShippingDto.DeliveryDateDto
{
    public class GetDeliveryDateDto
    {
        
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public int DisplayOrder { get; set; }
         
       
    }
}