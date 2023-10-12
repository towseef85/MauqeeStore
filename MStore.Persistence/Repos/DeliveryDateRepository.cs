using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Shipping;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class DeliveryDateRepository : IDeliveryDateRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DeliveryDateRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddDeliveryDate(PostDeliveryDateDto PostDeliveryDateDto, CancellationToken cancellationToken)
        {
            _context.DeliveryDates.Add(_mapper.Map<DeliveryDate>(PostDeliveryDateDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }


        public async Task<bool> DeleteDeliveryDate(Guid DeliveryDateId)
        {
            var data = await _context.DeliveryDates.FindAsync(DeliveryDateId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetDeliveryDateDto>> GetAllDeliveryDate(Guid subscriptionId)
        {
            var result = await _context.DeliveryDates.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetDeliveryDateDto>>(result);
            return resultData;
        }

        public async Task<GetDeliveryDateDto> GetDeliveryDateById(Guid DeliveryDateId)
        {
            var result = await _context.DeliveryDates.Where(x => x.Id == DeliveryDateId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetDeliveryDateDto>(result);
            return resultData;
        }


        public Task<List<GetDeliveryDateDto>> GetProductsForDeliveryDate(Guid DeliveryDateId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDeliveryDate(PostDeliveryDateDto PostDeliveryDateDto, CancellationToken cancellationToken)
        {
            var data = await _context.DeliveryDates.FindAsync(PostDeliveryDateDto.Id);
            if(data == null) return false;
            _mapper.Map(PostDeliveryDateDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

    }
}
