using FluentValidation;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.FinanceBL.PaymentStatusBL
{
    public class PaymentStatusValidation : AbstractValidator<PostPaymentStatusDto>
    {
        public PaymentStatusValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}