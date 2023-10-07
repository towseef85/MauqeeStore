using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Sales.Orders;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OrderStatusRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddOrderStatus(PostOrderStatusDto PostOrderStatusDto, CancellationToken cancellationToken)
        {
            _context.OrderStatuses.Add(_mapper.Map<OrderStatus>(PostOrderStatusDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteOrderStatus(Guid OrderStatusId)
        {
            var data = await _context.OrderStatuses.FindAsync(OrderStatusId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetOrderStatusDto>> GetAllOrderStatus(Guid OrderStatusId)
        {
            var result = await _context.OrderStatuses.Where(x => x.Id == OrderStatusId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetOrderStatusDto>>(result);
            return resultData;
        }

        public async Task<GetOrderStatusDto> GetOrderStatusById(Guid OrderStatusId)
        {
            
            var result = await _context.OrderStatuses.Where(x => x.Id == OrderStatusId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetOrderStatusDto>(result);
            return resultData;
            
        }

        public Task<List<GetOrderStatusDto>> GetProductsForCustomer(Guid OrderStatusId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateOrderStatus(PostOrderStatusDto PostOrderStatusDto, CancellationToken cancellationToken)
        {
            var data = await _context.OrderStatuses.FindAsync(PostOrderStatusDto.Id);
            if (data == null) return false;
            _mapper.Map(PostOrderStatusDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}