using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.BrandDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.BrandBL
{
    public class Edit
    {
        public class Command : IRequest<ServiceStatus<Unit>>
        {
            public PostBrandDto Brand { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Brand).SetValidator(new BrandValidation());
            }
        }

        public class Handler : IRequestHandler<Command, ServiceStatus<Unit>>
        {
            private readonly IBrandRepository _iBrandRepo;
            public Handler(IBrandRepository iBrandRepo)
            {
                _iBrandRepo = iBrandRepo;
            }
            public async Task<ServiceStatus<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iBrandRepo.UpdateBrand(request.Brand, cancellationToken);
                return result;
            }
        }
    }
}
