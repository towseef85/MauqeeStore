using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Marketing.Affiliates;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class AffiliateRepository : IAffiliateRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AffiliateRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddAffiliate(PostAffiliateDto PostAffiliateDto, CancellationToken cancellationToken)
        {
            _context.Affiliates.Add(_mapper.Map<Affiliate>(PostAffiliateDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteAffiliate(Guid AffiliateId)
        {
            var data = await _context.Affiliates.FindAsync(AffiliateId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetAffiliateDto>> GetAllAffiliate(Guid AffiliateId)
        {
            var result = await _context.Affiliates.Where(x => x.Id == AffiliateId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetAffiliateDto>>(result);
            return resultData;
        }

        public async Task<GetAffiliateDto> GetAffiliateById(Guid AffiliateId)
        {
            
            var result = await _context.Affiliates.Where(x => x.Id == AffiliateId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetAffiliateDto>(result);
            return resultData;
            
        }

        public Task<List<GetAffiliateDto>> GetProductsForCustomer(Guid AffiliateId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAffiliate(PostAffiliateDto PostAffiliateDto, CancellationToken cancellationToken)
        {
            var data = await _context.Affiliates.FindAsync(PostAffiliateDto.Id);
            if (data == null) return false;
            _mapper.Map(PostAffiliateDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}