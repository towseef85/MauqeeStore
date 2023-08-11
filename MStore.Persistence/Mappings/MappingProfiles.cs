using AutoMapper;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Dtos.CatalogDtos.Category;
using MStore.Application.Dtos.CatalogDtos.ProductAttribute;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeValue;
using MStore.Application.Dtos.CatalogDtos.TaxCategory;
using MStore.Application.Dtos.SubscriptionDtos;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Domain.Entities.Subscriptions;
using MStore.Domain.Financials;

namespace MStore.Persistence.Mappings
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<PostCategoryDto, Category>();
            CreateMap<Category, GetCategoriesDto>();
            CreateMap<PostPlanDto, Plans>();
            CreateMap<PostSubscriptionDto, Subscription>();
            CreateMap<Subscription, GetSubscriptionDto>()
                .ForMember(x=>x.UserName, y=>y.MapFrom(x=>x.Users.UserName))
                .ForMember(x=>x.EmailAddress, y=>y.MapFrom(x=>x.Users.Email));
            CreateMap<PostBrandDto, Brand>();
            CreateMap<Brand, GetBrandDto>();
            CreateMap<ProductAttribute, GetProductAttributeDto>()
                .ForMember(x=>x.ProductAttributeValue, y=>y.MapFrom(x=>x.ProductAttributeValues));
            CreateMap<ProductAttributeValue, GetProductAttributeValueDto>();
            CreateMap<PostProductAttributeCombinationDto, ProductAttributeCombination>();
            CreateMap<PostTaxCategoryDto,TaxCategory>();
            CreateMap<TaxCategory, GetTaxCategoryDto>();

        }
    }
}
