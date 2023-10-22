using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.FaqDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class FaqRepository : IFaqRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FaqRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddFaq(PostFaqDto PostFaqDto, CancellationToken cancellationToken)
        {
            try
            {
                var hasName = await _context.Faqs.Where(x=>x.Question == PostFaqDto.Question).AnyAsync();
                if (hasName)
                {
                    return new ServiceStatus<Unit>
                    {
                        Code = System.Net.HttpStatusCode.Conflict,
                        Message = "Faq Name Already Exists",
                        Object = Unit.Value
                    };
                }
                
                _context.Faqs.Add(_mapper.Map<Faq>(PostFaqDto));
                 await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Faq Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeleteFaq(Guid FaqId)
        {
            try
            {
                var data = await _context.Faqs.FindAsync(FaqId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Faq Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetFaqDto>>> GetAllFaq(Guid subscriptionId)
        {
            var result = await _context.Faqs.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetFaqDto>>(result);
            return new ServiceStatus<List<GetFaqDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Offers Fetch Successfully",
                Object = resultData
            };
           
        }

        public async Task<ServiceStatus<GetFaqDto>> GetFaqById(Guid FaqId)
        {
            try
            {
                var result = await _context.Faqs.Where(x => x.Id == FaqId).FirstOrDefaultAsync();
                return new ServiceStatus<GetFaqDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Offer with Id ${FaqId} fetch successfully",
                    Object = _mapper.Map<GetFaqDto>(result)
                };
            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetFaqDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
          

        }

        public Task<ServiceStatus<List<GetFaqDto>>> GetProductsForFaq(Guid FaqId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceStatus<Unit>> UpdateFaq(PostFaqDto PostFaqDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Faqs.FindAsync(PostFaqDto.Id);
                _mapper.Map(PostFaqDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Faq updated Successfully",
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
