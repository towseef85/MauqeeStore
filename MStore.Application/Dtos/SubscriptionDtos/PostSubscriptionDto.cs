using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.SubscriptionDtos
{
    public class PostSubscriptionDto
    {
        public Guid Id { get; set; }
        public Guid PlanId { get; set; }
        public Guid ClientId { get; set; }
        public DateOnly SubscriptionStartDate { get; set; }
        public DateOnly SubscriptionEndDate { get; set; }
        public string Remarks { get; set; }
    }
}
