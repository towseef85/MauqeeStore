using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CountryDto;

namespace MStore.Application.Interfaces
{
    public interface ICountryRepository
    {
        Task<ServiceStatus<List<GetCountryDto>>> GetAllCountry(Guid subscriptionId);
        Task<ServiceStatus<GetCountryDto>> GetCountryById(Guid CountryId);
        Task<ServiceStatus<Unit>> AddCountry(PostCountryDto PostCountryDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateCountry(PostCountryDto PostCountryDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteCountry(Guid CountryId);
    }
}
