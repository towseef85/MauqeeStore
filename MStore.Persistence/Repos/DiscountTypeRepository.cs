using System;
using AutoMapper;
using MStore.Application.Interfaces;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;
using MStore.Domain.Entities.Marketing.Discounts;
using MStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MStore.Persistence.Repos
{
        public class DiscountTypeRepository:IDiscountTypeRepository
        {
            public readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public DiscountTypeRepository(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<bool> AddDiscountType(PostDiscountTypeDto PostDiscountTypeDto, CancellationToken cancellationToken)
            {
                _context.DiscountTypes.Add(_mapper.Map<DiscountType>(PostDiscountTypeDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                return result;
            }

            public async Task<bool> DeleteDiscountType(Guid DiscountTypeId)
            {
                var data = await _context.DiscountTypes.FindAsync(DiscountTypeId);
                if (data == null) return false;
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                var result = await _context.SaveChangesAsync() > 0;
                return result;
            }

            public async Task<List<GetDiscountTypeDto>> GetAllDiscountType(Guid DiscountTypeId)
            {
                var result = await _context.DiscountTypes.Where(x => x.Id == DiscountTypeId && x.Deleted == false).ToListAsync();

                var resultData = _mapper.Map<List<GetDiscountTypeDto>>(result);
                return resultData;
            }

            public async Task<GetDiscountTypeDto> GetDiscountTypeById(Guid DiscountTypeId)
            {
            
            var result = await _context.DiscountTypes.Where(x => x.Id == DiscountTypeId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetDiscountTypeDto>(result);
            return resultData;
            
            }

            public Task<List<GetDiscountTypeDto>> GetProductsForDiscountType(Guid DiscountTypeId, Guid subscriptionId)
            {
                throw new NotImplementedException();
            }

            public async Task<bool> UpdateDiscountType(PostDiscountTypeDto PostDiscountTypeDto, CancellationToken cancellationToken)
            {
                var data = await _context.DiscountTypes.FindAsync(PostDiscountTypeDto.Id);
                if (data == null) return false;
                _mapper.Map(PostDiscountTypeDto, data);
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                return result;
            }
        }
    }

