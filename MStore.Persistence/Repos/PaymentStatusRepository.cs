using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Core;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.CMS.Commons;
using MStore.Domain.Entities.Financials;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class PaymentStatusRepository : IPaymentStatusRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PaymentStatusRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceStatus<Unit>> AddPaymentStatus(PostPaymentStatusDto PostPaymentStatusDto, CancellationToken cancellationToken)
        {
            try
            {
                _context.PaymentStatuses.Add(_mapper.Map<PaymentStatus>(PostPaymentStatusDto));
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Payment Status Added Successfully!",
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

        public async Task<ServiceStatus<Unit>> DeletePaymentStatus(Guid PaymentStatusId)
        {
            try
            {
                var data = await _context.PaymentStatuses.FindAsync(PaymentStatusId);
                data.Deleted = true;
                data.DeleteDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = "Payment Status Deleted Successfully",
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

        public async Task<ServiceStatus<List<GetPaymentStatusDto>>> GetAllPaymentStatus(Guid subscriptionId)
        {
            var result = await _context.PaymentStatuses.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetPaymentStatusDto>>(result);
            return new ServiceStatus<List<GetPaymentStatusDto>>
            {
                Code = System.Net.HttpStatusCode.OK,
                Message = "Payment Statuss Fetch Successfully",
                Object = resultData
            };
        }

        public async Task<ServiceStatus<GetPaymentStatusDto>> GetPaymentStatusById(Guid PaymentStatusId)
        {
            try
            {
                var result = await _context.PaymentStatuses.Where(x => x.Id == PaymentStatusId).FirstOrDefaultAsync();
                return new ServiceStatus<GetPaymentStatusDto>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"PaymentStatus with Id ${PaymentStatusId} fetch successfully",
                    Object = _mapper.Map<GetPaymentStatusDto>(result)
                };

            }
            catch (Exception ex)
            {
                ex = ex.InnerException;
                return new ServiceStatus<GetPaymentStatusDto>
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    InnerMessage = ex.InnerException.ToString(),
                    Object = null
                };
            }
        }

        public async Task<ServiceStatus<Unit>> UpdatePaymentStatus(PostPaymentStatusDto PostPaymentStatusDto, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.PaymentStatuses.FindAsync(PostPaymentStatusDto.Id);
                _mapper.Map(PostPaymentStatusDto, data);
                await _context.SaveChangesAsync(cancellationToken);
                return new ServiceStatus<Unit>
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Message = $"PaymentStatus updated Successfully",
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
