
using MStore.Application.Dtos.CMSDtos.Navigations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Interfaces
{
    public interface INavigationRepository
    {
        Task<List<GetNavigationDto>> GetAllNavigation(Guid subscriptionId);
        Task<GetNavigationDto> GetNavigationById(Guid NavigationId);
        Task<bool> AddNavigation(PostNavigationDto PostNavigationDto, CancellationToken cancellationToken);
        Task<bool> UpdateNavigation(PostNavigationDto PostNavigationDto);
        Task<bool> DeleteNavigation(Guid NavigationId);
    }
}
