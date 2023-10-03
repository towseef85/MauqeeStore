using System;
using MStore.Application.Dtos.CustomerDto.AddressDto;

namespace MStore.Application.Interfaces
{
    public interface IDiscountTypeRepository
        {
            Task<List<GetAddressDto>> GetAllAddress(Guid Customerid);
            Task<GetAddressDto> GetAddressById(Guid AddressId);
            //Task<List<GetBrandDto>> GetProductsForBrand(Guid BrandId, Guid subscriptionId);
            Task<bool> AddAddress(PostAddressDto PostAddressDto, CancellationToken cancellationToken);
            Task<bool> UpdateAddress(PostAddressDto PostAddressDto, CancellationToken cancellationToken);
            Task<bool> DeleteAddress(Guid AddressId);
        }
    }


