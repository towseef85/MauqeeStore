using FluentValidation;
using MStore.Application.Dtos.CMSDtos.Offers;

namespace MStore.Application.CMSBL.OffersBL
{
    public class OffersValidation : AbstractValidator<PostOffersDto>
    {
        public OffersValidation()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.SubscriptionId).NotEmpty();
            RuleFor(x => x.RedirectTo).NotEmpty();
            RuleFor(x => x.ImageData).NotEmpty();
        }
    }
}

