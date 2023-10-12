using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.SalesDto.OrderItemDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Sales.Orders;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderItemRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddOrderItem(PostOrderItemDto PostOrderItemDto, CancellationToken cancellationToken)
        {
            _context.OrderItems.Add(_mapper.Map<OrderItem>(PostOrderItemDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }


        public async Task<bool> DeleteOrderItem(Guid OrderItemId)
        {
            var data = await _context.OrderItems.FindAsync(OrderItemId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetOrderItemDto>> GetAllOrderItem(Guid subscriptionId)
        {
            var result = await _context.OrderItems.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetOrderItemDto>>(result);
            return resultData;
        }

        public async Task<GetOrderItemDto> GetOrderItemById(Guid OrderItemId)
        {
            var result = await _context.OrderItems.Where(x => x.Id == OrderItemId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetOrderItemDto>(result);
            return resultData;
        }


        public Task<List<GetOrderItemDto>> GetProductsForOrderItem(Guid OrderItemId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrderItem(PostOrderItemDto PostOrderItemDto, CancellationToken cancellationToken)
        {
            var data = await _context.OrderItems.FindAsync(PostOrderItemDto.Id);
            if(data == null) return false;
            _mapper.Map(PostOrderItemDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

    }
}
