using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;


namespace MStore.Application.Interfaces
{
    public interface IPaymentStatusRepository
    {
        Task<ServiceStatus<List<GetPaymentStatusDto>>> GetAllPaymentStatus(Guid subscriptionId);
        Task<ServiceStatus<GetPaymentStatusDto>> GetPaymentStatusById(Guid PaymentStatusId);
        Task<ServiceStatus<Unit>> AddPaymentStatus(PostPaymentStatusDto PostPaymentStatusDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdatePaymentStatus(PostPaymentStatusDto PostPaymentStatusDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeletePaymentStatus(Guid PaymentStatusId);
    }
}
