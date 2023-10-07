using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.FinanceDto.PaymentStatusDto
{
    public class GetPaymentStatusDto
    {
        public Guid Id { get; set; }
         //public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public bool IsActive { get; set; }
    }
}
