using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductAttribute;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.ProductAttributeBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostProductAttributeDto ProductAttribute { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductAttribute).SetValidator(new ProductAttributeValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IProductAttributeRepository _iProductAttributeRepo;
            public Handler(IProductAttributeRepository iProductAttributeRepo)
            {
                _iProductAttributeRepo = iProductAttributeRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iProductAttributeRepo.UpdateProductAttribute(request.ProductAttribute, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add ProductAttribute");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
