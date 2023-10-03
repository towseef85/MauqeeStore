using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MStore.Application.Dtos.CustomerDto.AddressDto;
using MStore.Application.Interfaces;
using MStore.Domain.Entities.Customers;
using MStore.Persistence.Context;

namespace MStore.Persistence.Repos
{
	public class AddressRepository:IAddressRepository
	{
		public readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AddressRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddAddress(PostAddressDto PostAddressDto, CancellationToken cancellationToken)
        {
            _context.Customers.Add(_mapper.Map<Customer>(PostAddressDto));
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }

        public async Task<bool> DeleteAddress(Guid AddressId)
        {
            var data = await _context.Addresses.FindAsync(AddressId);
            if (data == null) return false;
            data.Deleted = true;
            data.DeleteDate = DateTime.Now;
            var result = await _context.SaveChangesAsync() > 0;
            return result;
        }

        public async Task<List<GetAddressDto>> GetAllAddress(Guid Customerid)
        {
            var result = await _context.Addresses.Where(x => x.CustomerId  == Customerid && x.Deleted == false).ToListAsync();

            var resultData = _mapper.Map<List<GetAddressDto>>(result);
            return resultData;
        }

        public async Task<GetAddressDto> GetAddressById(Guid AddressId)
        {
            
            var result = await _context.Addresses.Where(x => x.Id == AddressId).FirstOrDefaultAsync();
            var resultData = _mapper.Map<GetAddressDto>(result);
            return resultData;
            
        }

        public Task<List<GetAddressDto>> GetProductsForCustomer(Guid AddressId, Guid subscriptionId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAddress(PostAddressDto PostAddressDto, CancellationToken cancellationToken)
        {
            var data = await _context.Addresses.FindAsync(PostAddressDto.Id);
            if (data == null) return false;
            _mapper.Map(PostAddressDto, data);
            var result = await _context.SaveChangesAsync(cancellationToken) > 0;
            return result;
        }
    }
	}


