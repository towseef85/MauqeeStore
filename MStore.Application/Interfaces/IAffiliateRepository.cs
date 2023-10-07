
using System;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;

namespace MStore.Application.Interfaces
{
	public interface IAffiliateRepository
    { 
            Task<List<GetAffiliateDto>> GetAllAffiliate(Guid AffiliateId);
            Task<GetAffiliateDto> GetAffiliateById(Guid AffiliateId);
            //Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
            Task<bool> AddAffiliate(PostAffiliateDto PostAffiliateDto, CancellationToken cancellationToken);
            Task<bool> UpdateAffiliate(PostAffiliateDto PostAffiliateDto, CancellationToken cancellationToken);
            Task<bool> DeleteAffiliate(Guid AffiliateId);
        }
}
