using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.SalesDto.OrderDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Sales.Orders;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class OrderRepository : IOrderRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddOrder(PostOrderDto PostOrderDto, CancellationToken cancellationToken)
        {
            _context.Orders.Add(_mapper.Map<Order>(PostOrderDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }


        public async Task<bool> DeleteOrder(Guid OrderId)
        {
            var data = await _context.Orders.FindAsync(OrderId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetOrderDto>> GetAllOrder(Guid subscriptionId)
        {
            var result = await _context.Orders.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetOrderDto>>(result);
            return resultData;
        }

        public async Task<GetOrderDto> GetOrderById(Guid OrderId)
        {
            var result = await _context.Orders.Where(x => x.Id == OrderId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetOrderDto>(result);
            return resultData;
        }


        public Task<List<GetOrderDto>> GetProductsForOrder(Guid OrderId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateOrder(PostOrderDto PostOrderDto, CancellationToken cancellationToken)
        {
            var data = await _context.Orders.FindAsync(PostOrderDto.Id);
            if(data == null) return false;
            _mapper.Map(PostOrderDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

    }
}
