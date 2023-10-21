using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.CityDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class CityRepository : ICityRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CityRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddCity(PostCityDto PostCityDto, CancellationToken cancellationToken)
        {
            try
            {
                _context.Cities.Add(_mapper.Map<City>(PostCityDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "City Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeleteCity(Guid CityId)
        {
            try
            {
                var data = await _context.Cities.FindAsync(CityId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "City Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetCityDto>>> GetAllCity(Guid subscriptionId)
        {
            var result = await _context.Cities.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetCityDto>>(result);
            return new ServiceStatus<List<GetCityDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Citys Fetch Successfully",
                Object = resultData
            };
        }

        public async Task<ServiceStatus<GetCityDto>> GetCityById(Guid CityId)
        {
            try
            {
                var result = await _context.Cities.Where(x => x.Id == CityId).FirstOrDefaultAsync();
                return new ServiceStatus<GetCityDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"City with Id ${CityId} fetch successfully",
                    Object = _mapper.Map<GetCityDto>(result)
                };

            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetCityDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
        }

        public async Task<ServiceStatus<Unit>> UpdateCity(PostCityDto PostCityDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Cities.FindAsync(PostCityDto.Id);
                _mapper.Map(PostCityDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"City updated Successfully",
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
