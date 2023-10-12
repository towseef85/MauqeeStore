using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.FinanceDto.CurrencyDto
{
    public class GetCurrencyDto
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Symbol { get; set; }
        public bool IsActive { get; set; }
    }
}
