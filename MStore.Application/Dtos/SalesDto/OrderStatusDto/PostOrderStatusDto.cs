using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.SalesDto.OrderStatusDto
{
    public class PostOrderStatusDto
    {
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public bool IsActive { get; set; }
    }
}