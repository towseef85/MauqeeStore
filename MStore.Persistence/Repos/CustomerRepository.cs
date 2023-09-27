using AutoMapper;
using Microsoft.EntityFrameworkCore;

using MStore.Application.Dtos.CustomerDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Customers;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddCustomer(PostCustomerDto PostCustomerDto, CancellationToken cancellationToken)
        {
            _context.Customers.Add(_mapper.Map<Customer>(PostCustomerDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public Task<bool> DeleteCustomer(Guid CustomerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetCustomerDto>> GetAllCustomer(Guid subscriptionId)
        {
            var result = await _context.Customers.Where(x => x.SubscriptionId == subscriptionId && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetCustomerDto>>(result);
            return resultData;
        }

        public Task<GetCustomerDto> GetCustomerById(Guid CusomerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetCustomerDto>> GetProductsForCustomer(Guid CustomerId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateCustomer(PostCustomerDto PostCustomerDto, CancellationToken cancellationToken)
        {
            var data = await _context.Customers.FindAsync(PostCustomerDto.Id);
            if (data == null) return false;
            _mapper.Map(PostCustomerDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
}
