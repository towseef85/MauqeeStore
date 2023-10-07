using FluentValidation;
using MStore.Application.Dtos.FinanceDto.TaxCategoryDto;

namespace MStore.Application.FinanceBL.TaxCategoryBL
{
    public class TaxCategoryValidation : AbstractValidator<PostTaxCategoryDto>
    {
        public TaxCategoryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty();
            RuleFor(x => x.Value).NotEmpty();
        }
    }
}
