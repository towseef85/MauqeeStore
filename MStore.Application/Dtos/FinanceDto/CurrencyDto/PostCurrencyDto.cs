using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.FinanceDto.CurrencyDto
{
    public class PostCurrencyDto
    {
        public Guid Id { get; set; } = new Guid();
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public bool IsActive { get; set; }
    }
}
