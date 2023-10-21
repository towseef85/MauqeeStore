using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.StoreDto;

namespace MStore.Application.Interfaces
{
    public interface IStoreRepository
    {
        Task<ServiceStatus<List<GetStoreDto>>> GetAllStore(Guid subscriptionId);
        Task<ServiceStatus<GetStoreDto>> GetStoreById(Guid StoreId);
        Task<ServiceStatus<List<GetStoreDto>>> GetProductsForStore(Guid StoreId, Guid subscriptionId);
        Task<ServiceStatus<Unit>> AddStore(PostStoreDto PostStoreDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateStore(PostStoreDto PostStoreDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteStore(Guid StoreId);
    }
}
