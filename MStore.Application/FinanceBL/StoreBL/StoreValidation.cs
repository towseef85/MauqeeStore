using FluentValidation;

using MStore.Application.Dtos.FinanceDto.StoreDto;

namespace MStore.Application.FinanceBL.StoreBL
{
    public class StoreValidation : AbstractValidator<PostStoreDto>
    {
        public StoreValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.OtherName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.CurrencyId).NotEmpty();
            
        }
    }
}
