using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.CategoryDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.CategoryBL
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public PostCategoryDto Category { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Category).SetValidator(new CategoryValidation());
            }
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
                var result = await _iCategoryRepo.UpdateCategory(request.Category, cancellationToken);
                if (!result) return Result<Unit>.Failure("Unable to Update Category");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
