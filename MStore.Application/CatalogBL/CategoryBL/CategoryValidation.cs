using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.CategoryDto;

namespace MStore.Application.CatalogBL.CategoryBL
{
    public class CategoryValidation : AbstractValidator<PostCategoryDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.OtherName).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}
