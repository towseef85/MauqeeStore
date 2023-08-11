using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.TaxCategory;

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
