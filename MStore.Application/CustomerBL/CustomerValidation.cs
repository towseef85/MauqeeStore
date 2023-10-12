using FluentValidation;
using MStore.Application.Dtos.CustomerDto;

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

