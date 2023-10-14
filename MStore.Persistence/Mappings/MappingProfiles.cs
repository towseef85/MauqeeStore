using AutoMapper;
using MStore.Application.Dtos.CatalogDtos.BrandDto;
using MStore.Application.Dtos.CatalogDtos.CategoryDto;
using MStore.Application.Dtos.CatalogDtos.ProductDto;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeDto;
using MStore.Application.Dtos.CatalogDtos.ProductAttributeValueDto;
using MStore.Application.Dtos.CatalogDtos.ProductWarehouseInventoryDto;
using MStore.Application.Dtos.FinanceDto.TaxCategoryDto;
using MStore.Application.Dtos.FinanceDto.PaymentStatusDto;
using MStore.Application.Dtos.CMSDtos.Slider;
using MStore.Application.Dtos.CustomerDto;
using MStore.Application.Dtos.SubscriptionDtos;
using MStore.Domain.Entities.Catalog.Common;
using MStore.Domain.Entities.Catalog.Products;
using MStore.Domain.Entities.CMS.Commons;
using MStore.Domain.Entities.Customers;
using MStore.Domain.Entities.Subscriptions;
using MStore.Domain.Financials;
using MStore.Domain.Entities.Financials;
using MStore.Application.Dtos.SalesDto.OrderStatusDto;
using MStore.Domain.Entities.Sales.Orders;
using MStore.Application.Dtos.MarketingDto.AffiliateDto;
using MStore.Domain.Entities.Marketing.Affiliates;
using MStore.Application.Dtos.MarketingDto.DiscountTypeDto;
using MStore.Domain.Entities.Marketing.Discounts;
using MStore.Application.Dtos.MarketingDto.DiscountDto;
using MStore.Application.Dtos.SalesDto.OrderItemDto;
using MStore.Application.Dtos.SalesDto.OrderDto;
using MStore.Domain.Entities.Shipping;
using MStore.Application.Dtos.ShippingDto.DeliveryDateDto;
using MStore.Application.Dtos.ShippingDto.ProductAvailabilityRangeDto;
using MStore.Application.Dtos.ShippingDto.ShipmentDto;
using MStore.Application.Dtos.ShippingDto.WarehouseDto;
using MStore.Application.Dtos.FinanceDto.CountryDto;


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

            CreateMap<PostProductWarehouseInventoryDto, ProductWarehouseInventory>();
            CreateMap<ProductWarehouseInventory, GetProductWarehouseInventoryDto>();

            CreateMap<PostTaxCategoryDto,TaxCategory>();
            CreateMap<TaxCategory, GetTaxCategoryDto>();
            CreateMap<Slider, GetSliderDto>();
            CreateMap<PostSliderDto, Slider>();
            CreateMap<PostCustomerDto,Customer>();
            CreateMap<Customer, GetCustomerDto>();

            CreateMap<PostPaymentStatusDto,PaymentStatus>();
            CreateMap<PaymentStatus, GetPaymentStatusDto>();

            CreateMap<PostOrderStatusDto,OrderStatus>();
            CreateMap<OrderStatus, GetOrderStatusDto>();

            
            CreateMap<PostOrderDto,Order>();
            CreateMap<Order, GetOrderDto>();

            CreateMap<PostOrderItemDto,OrderItem>();
            CreateMap<OrderItem, GetOrderItemDto>();
            
            CreateMap<PostAffiliateDto,Affiliate>();
            CreateMap<Affiliate, GetAffiliateDto>();
            
            CreateMap<PostDiscountTypeDto,DiscountType>();
            CreateMap<DiscountType, GetDiscountTypeDto>();
            
            CreateMap<PostDiscountDto,Discount>();
            CreateMap<Discount, GetDiscountDto>();

            CreateMap<PostDeliveryDateDto,DeliveryDate>();
            CreateMap<DeliveryDate, GetDeliveryDateDto>();

            CreateMap<PostProductAvailabilityRangeDto,ProductAvailabilityRange>();
            CreateMap<ProductAvailabilityRange, GetProductAvailabilityRangeDto>();

            CreateMap<PostShipmentDto,Shipment>();
            CreateMap<Shipment, GetShipmentDto>();


            CreateMap<PostWarehouseDto,Warehouse>();
            CreateMap<Warehouse, GetWarehouseDto>();

            CreateMap<PostCountryDto,Country>();
            CreateMap<Country, GetCountryDto>();

            //CreateMap<PostCityDto,City>();
            //CreateMap<City, GetCityDto>();
            

            
            

        }
    }
}
