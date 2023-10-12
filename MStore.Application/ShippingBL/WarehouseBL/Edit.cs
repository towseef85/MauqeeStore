using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.ShippingDto.WarehouseDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.ShippingBL.WarehouseBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostWarehouseDto Warehouse { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Warehouse).SetValidator(new WarehouseValidation());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IWarehouseRepository _iWarehouseRepo;
            public Handler(IWarehouseRepository iWarehouseRepo)
            {
                _iWarehouseRepo = iWarehouseRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iWarehouseRepo.UpdateWarehouse(request.Warehouse, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Warehouse");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
