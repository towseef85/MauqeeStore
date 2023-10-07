using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CurrencyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
