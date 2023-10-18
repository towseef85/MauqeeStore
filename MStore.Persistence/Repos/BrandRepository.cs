using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.CatalogDtos.BrandDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class BrandRepository : IBrandRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public BrandRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddBrand(PostBrandDto PostBrandDto, CancellationToken cancellationToken)
        {
            try
            {
                _context.Brands.Add(_mapper.Map<Brand>(PostBrandDto));
                 await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Brand Added Successfully!",
                    Object = Unit.Value,

                };
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message.ToString(),
                    InnerMessage = exception.InnerException?.Message != null ? exception.InnerException.Message : null,
                    Object = Unit.Value,
                };
            }
        
           
        }

        public async Task<ServiceStatus<Unit>> DeleteBrand(Guid BrandId)
        {
            try
            {
                var data = await _context.Brands.FindAsync(BrandId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Brand Deleted Successfully",
                    Object = Unit.Value,
                };
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = $"Unable to Delete Error= ${ex.Message.ToString()}",
                    InnerMessage = exception.InnerException?.Message != null ? exception.InnerException.Message : null,
                    Object = Unit.Value,
                };
            }
          
        }

        public async Task<ServiceStatus<List<GetBrandDto>>> GetAllBrand(Guid subscriptionId)
        {
            var result = await _context.Brands.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetBrandDto>>(result);
            return new ServiceStatus<List<GetBrandDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Offers Fetch Successfully",
                Object = resultData
            };
           
        }

        public async Task<ServiceStatus<GetBrandDto>> GetBrandById(Guid BrandId)
        {
            try
            {
                var result = await _context.Brands.Where(x => x.Id == BrandId).FirstOrDefaultAsync();
                return new ServiceStatus<GetBrandDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Offer with Id ${BrandId} fetch successfully",
                    Object = _mapper.Map<GetBrandDto>(result)
                };
            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetBrandDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
          

        }

        public Task<ServiceStatus<List<GetBrandDto>>> GetProductsForBrand(Guid BrandId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceStatus<Unit>> UpdateBrand(PostBrandDto PostBrandDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Brands.FindAsync(PostBrandDto.Id);
                _mapper.Map(PostBrandDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Brand updated Successfully",
                    Object = Unit.Value
                };
            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = Unit.Value
                };
            }
           
        
        }
    }
}
