using FluentValidation;
using MStore.Application.Dtos.FinanceDto.CurrencyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.CurrencyBL
{
    public class CurrencyValidation : AbstractValidator<PostCurrencyDto>
    {
        public CurrencyValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Symbol).NotEmpty();
        }
    }
}