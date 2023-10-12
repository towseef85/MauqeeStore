using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CurrencyDto;

namespace MStore.Application.Interfaces
{
    public interface ICurrencyRepository
    {
        Task<ServiceStatus<List<GetCurrencyDto>>> GetAllCurrency(Guid subscriptionId);
        Task<ServiceStatus<GetCurrencyDto>> GetCurrencyById(Guid CurrencyId);
        Task<ServiceStatus<Unit>> AddCurrency(PostCurrencyDto PostCurrencyDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateCurrency(PostCurrencyDto PostCurrencyDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteCurrency(Guid CurrencyId);
    }
}
