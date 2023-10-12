using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CurrencyDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class CurrencyRepository : ICurrencyRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CurrencyRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddCurrency(PostCurrencyDto PostCurrencyDto, CancellationToken cancellationToken)
        {
            try
            {
                _context.Currencies.Add(_mapper.Map<Currency>(PostCurrencyDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Currency Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeleteCurrency(Guid CurrencyId)
        {
            try
            {
                var data = await _context.Currencies.FindAsync(CurrencyId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Currency Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetCurrencyDto>>> GetAllCurrency(Guid subscriptionId)
        {
            var result = await _context.Currencies.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetCurrencyDto>>(result);
            return new ServiceStatus<List<GetCurrencyDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Currencys Fetch Successfully",
                Object = resultData
            };
        }

        public async Task<ServiceStatus<GetCurrencyDto>> GetCurrencyById(Guid CurrencyId)
        {
            try
            {
                var result = await _context.Currencies.Where(x => x.Id == CurrencyId).FirstOrDefaultAsync();
                return new ServiceStatus<GetCurrencyDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Currency with Id ${CurrencyId} fetch successfully",
                    Object = _mapper.Map<GetCurrencyDto>(result)
                };

            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetCurrencyDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
        }

        public async Task<ServiceStatus<Unit>> UpdateCurrency(PostCurrencyDto PostCurrencyDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Currencies.FindAsync(PostCurrencyDto.Id);
                _mapper.Map(PostCurrencyDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Currency updated Successfully",
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
