using FluentValidation;
using MediatR;
using MStore.Application.CatalogBL.ProductBL;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.Product;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.ProductBL
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostProductDto Product { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Product).SetValidator(new ProductValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IProductRepository _iProductRepo;
            public Handler(IProductRepository iProductRepo)
            {
                _iProductRepo = iProductRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iProductRepo.AddProduct(request.Product, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Product, Please Check Name");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
