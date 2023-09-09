using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Offers;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.CMS.Commons;
using MStore.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Persistence.Repos
{
    public class OffersRepository : IOffersRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OffersRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddOffers(PostOffersDto PostOffersDto, CancellationToken cancellationToken)
        {
            try
            {
                _context.Offers.Add(_mapper.Map<Offers>(PostOffersDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Offers Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeleteOffers(Guid OffersId)
        {
            try
            {
                var data = await _context.Offers.FindAsync(OffersId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Offers Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetOffersDto>>> GetAllOffers(Guid subscriptionId)
        {
            var result = await _context.Offers.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetOffersDto>>(result);
            return new ServiceStatus<List<GetOffersDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Offers Fetch Successfully",
                Object = resultData
            };
        }

        public async Task<ServiceStatus<GetOffersDto>> GetOffersById(Guid OffersId)
        {
            try
            {
                var result = await _context.Offers.Where(x => x.Id == OffersId).FirstOrDefaultAsync();
                return new ServiceStatus<GetOffersDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Offer with Id ${OffersId} fetch successfully",
                    Object = _mapper.Map<GetOffersDto>(result)
                };

            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetOffersDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
        }

        public async Task<ServiceStatus<Unit>> UpdateOffers(PostOffersDto PostOffersDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Offers.FindAsync(PostOffersDto.Id);
                _mapper.Map(PostOffersDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Offer updated Successfully",
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
