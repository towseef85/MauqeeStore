using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.FaqDto;

namespace MStore.Application.Interfaces
{
    public interface IFaqRepository
    {
        Task<ServiceStatus<List<GetFaqDto>>> GetAllFaq(Guid subscriptionId);
        Task<ServiceStatus<GetFaqDto>> GetFaqById(Guid FaqId);
        Task<ServiceStatus<List<GetFaqDto>>> GetProductsForFaq(Guid FaqId, Guid subscriptionId);
        Task<ServiceStatus<Unit>> AddFaq(PostFaqDto PostFaqDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateFaq(PostFaqDto PostFaqDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteFaq(Guid FaqId);
    }
}
