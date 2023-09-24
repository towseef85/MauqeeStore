using FluentValidation;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Dtos.CustomerDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CustomerBL
{
    public class CustomerValidation : AbstractValidator<PostCustomerDto>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Email).NotEmpty();
            
        }
    }
}

