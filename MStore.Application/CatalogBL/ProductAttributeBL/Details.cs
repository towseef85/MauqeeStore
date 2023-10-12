using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeDto;
using MStore.Application.Interfaces;

namespace MStore.Application.CatalogBL.ProductAttributeBL
{
    public class Details
    {
        public class Query : IRequest<Result<GetProductAttributeDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<GetProductAttributeDto>>
        {
            private readonly IProductAttributeRepository _iProductAttributeRepo;
            public Handler(IProductAttributeRepository iProductAttributeRepo)
            {
                _iProductAttributeRepo = iProductAttributeRepo;
            }

            public async Task<Result<GetProductAttributeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _iProductAttributeRepo.GetProductAttributeById(request.Id);
                return Result<GetProductAttributeDto>.Success(result);

            }
        }
    }
}
