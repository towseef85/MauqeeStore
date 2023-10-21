using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.FinanceDto.TermAndConditionDto
{
    public class GetTermAndConditionDto
    {   
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Published { get; set; }
        public int DisplayOrder { get; set; }
    }
}