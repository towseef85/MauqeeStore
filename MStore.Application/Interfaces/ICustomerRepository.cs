
using MStore.Application.Dtos.CustomerDto;

namespace MStore.Application.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<GetCustomerDto>> GetAllCustomer(Guid subscriptionId);
        Task<GetCustomerDto> GetCustomerById(Guid CusomerId);
        Task<List<GetCustomerDto>> GetProductsForCustomer(Guid CustomerId, Guid subscriptionId);
        Task<bool> AddCustomer(PostCustomerDto PostCustomerDto, CancellationToken cancellationToken);
        Task<bool> UpdateCustomer(PostCustomerDto PostCustomerDto, CancellationToken cancellationToken);
        Task<bool> DeleteCustomer(Guid CustomerId);
    }
}
