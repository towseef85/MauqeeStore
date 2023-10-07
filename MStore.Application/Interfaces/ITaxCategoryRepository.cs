using MStore.Application.Dtos.FinanceDto.TaxCategoryDto;

namespace MStore.Application.Interfaces
{
    public interface ITaxCategoryRepository
    {
        Task<List<GetTaxCategoryDto>> GetAllTaxCategory(Guid subscriptionId);
        Task<GetTaxCategoryDto> GetTaxCategoryById(Guid TaxCategoryId);
        Task<bool> AddTaxCategory(PostTaxCategoryDto PostTaxCategoryDto, CancellationToken cancellationToken);
        Task<bool> UpdateTaxCategory(PostTaxCategoryDto PostTaxCategoryDto, CancellationToken cancellationToken);
        Task<bool> DeleteTaxCategory(Guid TaxCategoryId);
    }
}

