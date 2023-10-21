using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CityDto;

namespace MStore.Application.Interfaces
{
    public interface ICityRepository
    {
        Task<ServiceStatus<List<GetCityDto>>> GetAllCity(Guid subscriptionId);
        Task<ServiceStatus<GetCityDto>> GetCityById(Guid CityId);
        Task<ServiceStatus<Unit>> AddCity(PostCityDto PostCityDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> UpdateCity(PostCityDto PostCityDto, CancellationToken cancellationToken);
        Task<ServiceStatus<Unit>> DeleteCity(Guid CityId);
    }
}
