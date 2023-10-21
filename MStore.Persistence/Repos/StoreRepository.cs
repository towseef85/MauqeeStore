using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.StoreDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class StoreRepository : IStoreRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StoreRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddStore(PostStoreDto PostStoreDto, CancellationToken cancellationToken)
        {
            try
            {
                var hasName = await _context.Stores.Where(x=>x.Name == PostStoreDto.Name).AnyAsync();
                if (hasName)
                {
                    return new ServiceStatus<Unit>
                    {
                        Code = System.Net.HttpStatusCode.Conflict,
                        Message = "Store Name Already Exists",
                        Object = Unit.Value
                    };
                }
                
                _context.Stores.Add(_mapper.Map<Store>(PostStoreDto));
                 await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Store Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeleteStore(Guid StoreId)
        {
            try
            {
                var data = await _context.Stores.FindAsync(StoreId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Store Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetStoreDto>>> GetAllStore(Guid subscriptionId)
        {
            var result = await _context.Stores.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetStoreDto>>(result);
            return new ServiceStatus<List<GetStoreDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Offers Fetch Successfully",
                Object = resultData
            };
           
        }

        public async Task<ServiceStatus<GetStoreDto>> GetStoreById(Guid StoreId)
        {
            try
            {
                var result = await _context.Stores.Where(x => x.Id == StoreId).FirstOrDefaultAsync();
                return new ServiceStatus<GetStoreDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Offer with Id ${StoreId} fetch successfully",
                    Object = _mapper.Map<GetStoreDto>(result)
                };
            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetStoreDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
          

        }

        public Task<ServiceStatus<List<GetStoreDto>>> GetProductsForStore(Guid StoreId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceStatus<Unit>> UpdateStore(PostStoreDto PostStoreDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Stores.FindAsync(PostStoreDto.Id);
                _mapper.Map(PostStoreDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Store updated Successfully",
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
