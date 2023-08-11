using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.CategoryBL
{
    public class CategoryValidation : AbstractValidator<PostCategoryDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.EngName).NotEmpty();
            RuleFor(x => x.OtherName).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}
