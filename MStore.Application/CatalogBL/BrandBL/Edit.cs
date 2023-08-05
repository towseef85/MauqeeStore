﻿using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.BrandBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
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

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IBrandRepository _iBrandRepo;
            public Handler(IBrandRepository iBrandRepo)
            {
                _iBrandRepo = iBrandRepo;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _iBrandRepo.UpdateBrand(request.Brand, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to add Brand");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
