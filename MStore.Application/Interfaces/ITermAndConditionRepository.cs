using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.TermAndConditionDto;

namespace MStore.Application.Interfaces
{
    public interface ITermAndConditionRepository
    {
        Task<ServiceStatus<List<GetTermAndConditionDto>>> GetAllTermAndCondition(Guid subscriptionId);
        Task<ServiceStatus<GetTermAndConditionDto>> GetTermAndConditionById(Guid TermAndConditionId);
        Task<ServiceStatus<List<GetTermAndConditionDto>>> GetProductsForTermAndCondition(Guid TermAndConditionId, Guid subscriptionId);
        Task<ServiceStatus<Unit>> AddTermAndCondition(PostTermAndConditionDto PostTermAndConditionDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateTermAndCondition(PostTermAndConditionDto PostTermAndConditionDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteTermAndCondition(Guid TermAndConditionId);
    }
}
