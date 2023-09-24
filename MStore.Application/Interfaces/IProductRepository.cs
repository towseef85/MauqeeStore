using MStore.Application.Dtos.CatalogDtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<GetProductDto>> GetAllProduct(Guid subscriptionId);
        Task<GetProductDto> GetProductById(Guid ProductId);
        Task<bool> AddProduct(PostProductDto PostProductDto, CancellationToken cancellationToken);
        Task<bool> UpdateProduct(PostProductDto PostProductDto, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(Guid ProductId);
    }
}
