using MediatR;
using MStore.Application.Core;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.CatalogBL.CategoryBL
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ICategoryRepository _iCategoryRepo;
            public Handler(ICategoryRepository iCategoryRepo)
            {
                _iCategoryRepo = iCategoryRepo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {

                var result = await _iCategoryRepo.DeleteCategory(request.Id);
                if (!result) return Result<Unit>.Failure("Failed to Delete Category");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
