using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CatalogDtos.CategoryDto;
using MStore.Application.Dtos.CMSDtos.Navigations;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.CMS.Commons;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class NavigationRepository : INavigationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NavigationRepository(ApplicationDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddNavigation(PostNavigationDto PostNavigationDto, CancellationToken cancellationToken)
        {
            _context.Navigations.Add(_mapper.Map<Navigation>(PostNavigationDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public Task<bool> DeleteNavigation(Guid NavigationId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetNavigationDto>> GetAllNavigation(Guid subscriptionId)
        {
            var result = await _context.Navigations.Where(x => x.SubscriptionId == subscriptionId).ToListAsync();
            var resultData = _mapper.Map<List<GetNavigationDto>>(result);
            return resultData;
        }

        public async Task<GetNavigationDto> GetNavigationById(Guid NavigationId)
        {
            var result = await _context.Navigations.Where(x => x.Id == NavigationId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetNavigationDto>(result);
            return resultData;
        }


        public Task<bool> UpdateNavigation(PostNavigationDto PostNavigationDto)
        {
            throw new NotImplementedException();
        }
    }
}
