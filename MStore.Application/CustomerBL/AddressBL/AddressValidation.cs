using System;
using FluentValidation;
using MStore.Application.Dtos.CustomerDto.AddressDto;

namespace MStore.Application.CustomerBL.AddressBL
{
    public class AddressValidation : AbstractValidator<PostAddressDto>
    {
        public AddressValidation()
        {
            RuleFor(x => x.EngDesc).NotEmpty();
            //RuleFor(x => x.SubscriptionId).NotEmpty();
        }
    }
}

