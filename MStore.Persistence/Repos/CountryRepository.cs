using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CountryDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class CountryRepository : ICountryRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CountryRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddCountry(PostCountryDto PostCountryDto, CancellationToken cancellationToken)
        {
            try
            {
                _context.Countries.Add(_mapper.Map<Country>(PostCountryDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Country Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeleteCountry(Guid CountryId)
        {
            try
            {
                var data = await _context.Countries.FindAsync(CountryId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Country Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetCountryDto>>> GetAllCountry(Guid subscriptionId)
        {
            var result = await _context.Countries.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetCountryDto>>(result);
            return new ServiceStatus<List<GetCountryDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Countrys Fetch Successfully",
                Object = resultData
            };
        }

        public async Task<ServiceStatus<GetCountryDto>> GetCountryById(Guid CountryId)
        {
            try
            {
                var result = await _context.Countries.Where(x => x.Id == CountryId).FirstOrDefaultAsync();
                return new ServiceStatus<GetCountryDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Country with Id ${CountryId} fetch successfully",
                    Object = _mapper.Map<GetCountryDto>(result)
                };

            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetCountryDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
        }

        public async Task<ServiceStatus<Unit>> UpdateCountry(PostCountryDto PostCountryDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Countries.FindAsync(PostCountryDto.Id);
                _mapper.Map(PostCountryDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Country updated Successfully",
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
