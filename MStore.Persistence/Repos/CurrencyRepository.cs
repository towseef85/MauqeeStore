using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.CurrencyDto;
using MStore.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Persistence.Repos
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public CurrencyRepository()
        {

        }
        public Task<ServiceStatus<Unit>> AddCurrency(PostCurrencyDto PostCurrencyDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceStatus<Unit>> DeleteCurrency(Guid CurrencyId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceStatus<List<GetCurrencyDto>>> GetAllCurrency(Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceStatus<GetCurrencyDto>> GetCurrencyById(Guid CurrencyId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceStatus<Unit>> UpdateCurrency(PostCurrencyDto PostCurrencyDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
