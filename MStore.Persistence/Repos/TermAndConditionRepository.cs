using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.TermAndConditionDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class TermAndConditionRepository : ITermAndConditionRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TermAndConditionRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddTermAndCondition(PostTermAndConditionDto PostTermAndConditionDto, CancellationToken cancellationToken)
        {
            try
            {
                var hasName = await _context.TermsAndConditions.Where(x=>x.Name == PostTermAndConditionDto.Name).AnyAsync();
                if (hasName)
                {
                    return new ServiceStatus<Unit>
                    {
                        Code = System.Net.HttpStatusCode.Conflict,
                        Message = "TermAndCondition Name Already Exists",
                        Object = Unit.Value
                    };
                }
                
                _context.TermsAndConditions.Add(_mapper.Map<TermAndCondition>(PostTermAndConditionDto));
                 await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "TermAndCondition Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeleteTermAndCondition(Guid TermAndConditionId)
        {
            try
            {
                var data = await _context.TermsAndConditions.FindAsync(TermAndConditionId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "TermAndCondition Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetTermAndConditionDto>>> GetAllTermAndCondition(Guid subscriptionId)
        {
            var result = await _context.TermsAndConditions.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetTermAndConditionDto>>(result);
            return new ServiceStatus<List<GetTermAndConditionDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Offers Fetch Successfully",
                Object = resultData
            };
           
        }

        public Task<ServiceStatus<List<GetTermAndConditionDto>>> GetProductsForTermAndCondition(Guid TermAndConditionId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceStatus<GetTermAndConditionDto>> GetTermAndConditionById(Guid TermAndConditionId)
        {
            try
            {
                var result = await _context.TermsAndConditions.Where(x => x.Id == TermAndConditionId).FirstOrDefaultAsync();
                return new ServiceStatus<GetTermAndConditionDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Offer with Id ${TermAndConditionId} fetch successfully",
                    Object = _mapper.Map<GetTermAndConditionDto>(result)
                };
            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetTermAndConditionDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
          

        }

        // public Task<ServiceStatus<List<GetTermAndConditionDto>>> GetProductsForTermAndCondition(Guid TermAndConditionId, Guid subscriptionId)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<ServiceStatus<Unit>> UpdateTermAndCondition(PostTermAndConditionDto PostTermAndConditionDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.TermsAndConditions.FindAsync(PostTermAndConditionDto.Id);
                _mapper.Map(PostTermAndConditionDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"TermAndCondition updated Successfully",
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
