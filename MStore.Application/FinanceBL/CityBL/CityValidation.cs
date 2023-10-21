using FluentValidation;
using MStore.Application.Dtos.FinanceDto.CityDto;

namespace MStore.Application.FinanceBL.CityBL
{
    public class CityValidation : AbstractValidator<PostCityDto>
    {
        public CityValidation()
        {
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.OtherName).NotEmpty();
        }
    }
}