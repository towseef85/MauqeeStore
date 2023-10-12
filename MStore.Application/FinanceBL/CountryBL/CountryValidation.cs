using FluentValidation;
using MStore.Application.Dtos.FinanceDto.CountryDto;

namespace MStore.Application.FinanceBL.CountryBL
{
    public class CountryValidation : AbstractValidator<PostCountryDto>
    {
        public CountryValidation()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.OtherName).NotEmpty();
        }
    }
}