using AutoMapper;
using MStore.Application.Dtos.CatalogDtos.Brand;
using MStore.Application.Dtos.CatalogDtos.Category;
using MStore.Application.Dtos.CatalogDtos.Product;
using MStore.Application.Dtos.CatalogDtos.ProductAttribute;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeValue;
using MStore.Application.Dtos.CatalogDtos.TaxCategory;
using MStore.Application.Dtos.CMSDtos.Slider;
using MStore.Application.Dtos.CustomerDto;
using MStore.Application.Dtos.SubscriptionDtos;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Domain.Entities.CMS.Commons;
using MStore.Domain.Entities.Customers;
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
            CreateMap<PostProductDto, Product>()
                .ForMember(x=>x.ProductAttributeCombinations,y=>y.MapFrom(x=>x.ProductAttributeCombinations));
            CreateMap<Product, GetProductDto>()
                .ForMember(x => x.AttributeCombination, y => y.MapFrom(x => x.ProductAttributeCombinations));
            CreateMap<ProductAttribute, GetProductAttributeDto>()
                .ForMember(x=>x.ProductAttributeValue, y=>y.MapFrom(x=>x.ProductAttributeValues));
            CreateMap<PostProductAttributeDto, ProductAttribute>()
                .ForMember(x => x.ProductAttributeValues, y => y.MapFrom(x => x.AttributeValues));
            CreateMap<PostProductAttributeValues, ProductAttributeValue>();
            CreateMap<ProductAttributeValue, GetProductAttributeValueDto>();
            CreateMap<PostProductAttributeCombinationDto, ProductAttributeCombination>();
            CreateMap<ProductAttributeCombination, GetProductAttributeCombinationDto>();
            CreateMap<PostTaxCategoryDto,TaxCategory>();
            CreateMap<TaxCategory, GetTaxCategoryDto>();
            CreateMap<Slider, GetSliderDto>();
            CreateMap<PostSliderDto, Slider>();
            CreateMap<PostCustomerDto,Customer>();
            CreateMap<Customer, GetCustomerDto>();

        }
    }
}
