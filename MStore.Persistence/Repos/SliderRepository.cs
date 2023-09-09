using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.CMSDtos.Slider;
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
    public class SliderRepository : ISliderRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SliderRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddSlider(PostSliderDto PostSliderDto, CancellationToken cancellationToken)
        {

            try
            {
                _context.Sliders.Add(_mapper.Map<Slider>(PostSliderDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                    return new ServiceStatus<Unit>
                    {
                        Code = System.Net.HttpStatusCode.OK,
                        Message = "Slider Added Successfully!",
                        Object = Unit.Value,

                    };
                
            }
            catch(Exception ex)
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

        public async Task<ServiceStatus<Unit>> DeleteSlider(Guid SliderId)
        {
            try
            {
                var data = await _context.Sliders.FindAsync(SliderId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Slider Deleted Successfully",
                    Object = Unit.Value,
                };
            }
            catch(Exception ex)
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

        public async Task<ServiceStatus<List<GetSliderDto>>> GetAllSlider(Guid subscriptionId)
        {
            var result = await _context.Sliders.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetSliderDto>>(result);
            return new ServiceStatus<List<GetSliderDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Sliders Fetch Successfully",
                Object = resultData
            };
        }

        public async Task<ServiceStatus<GetSliderDto>> GetSliderById(Guid SliderId)
        {
            try
            {
                var result = await _context.Sliders.Where(x => x.Id == SliderId).FirstOrDefaultAsync();
                return new ServiceStatus<GetSliderDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Slider with Id ${SliderId} fetch successfully",
                    Object = _mapper.Map<GetSliderDto>(result)
                };

            }
            catch(Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetSliderDto>
                {
                    Code =System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage= ex.InnerException.ToString(),
                    Object = null
                };
            }
 
        }

        public async Task<ServiceStatus<Unit>> UpdateSlider(PostSliderDto PostSliderDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.Sliders.FindAsync(PostSliderDto.Id);
                _mapper.Map(PostSliderDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"Slider updated Successfully",
                    Object = Unit.Value
                };
            }
            catch(Exception ex)
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
