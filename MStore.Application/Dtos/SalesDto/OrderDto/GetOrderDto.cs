using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MStore.Application.Dtos.SalesDto.OrderDto
{
    public class GetOrderDto
    {
        public Guid SubscriptionId { get; set; }
        public Guid OrderGuid { get; set; }
        //public int StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid BillingAddressId { get; set; }
        public Guid? ShippingAddressId { get; set; }
        //public int? PickupAddressId { get; set; }
        //public bool PickupInStore { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid ShippingStatusId { get; set; }
        public Guid PaymentStatusId { get; set; }
        public Guid AffiliateId { get; set; }
        //public string CustomerCurrencyCode { get; set; }
        //public decimal CurrencyRate { get; set; }
        
        //public int CustomerTaxDisplayTypeId { get; set; }
        //public string VatNumber { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }
        public decimal OrderSubtotalExclTax { get; set; }
        public decimal OrderSubTotalDiscountInclTax { get; set; }
        public decimal OrderSubTotalDiscountExclTax { get; set; }
        public decimal OrderShippingInclTax { get; set; }
        public decimal OrderShippingExclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }
        public Guid TaxCategoryId { get; set; }
        //public decimal OrderTax { get; set; }
        public decimal DiscountId { get; set; }
        public decimal OrderNetTotal { get; set; }
        //public decimal RefundedAmount { get; set; }
        //public int? RewardPointsHistoryEntryId { get; set; }
        //public string CheckoutAttributeDescription { get; set; }
        //public string CheckoutAttributesXml { get; set; }
        //public int CustomerLanguageId { get; set; }
        
        //public string CustomerIp { get; set; }
        //public bool AllowStoringCreditCardNumber { get; set; }
        public string? CardType { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? MaskedCreditCardNumber { get; set; }
        public string? CardCvv2 { get; set; }
        public string? CardExpirationMonth { get; set; }
        public string? CardExpirationYear { get; set; }
        public string AuthorizationTransactionId { get; set; }
        public string AuthorizationTransactionCode { get; set; }
        public string AuthorizationTransactionResult { get; set; }
        public string CaptureTransactionId { get; set; }
        public string CaptureTransactionResult { get; set; }
        public string SubscriptionTransactionId { get; set; }
        public DateTime? PaidDate { get; set; }
        //public string ShippingMethod { get; set; }
        //public string ShippingRateComputationMethodSystemName { get; set; }
        
    
        //public string CustomOrderNumber { get; set; }
         //public int DownloadId { get; set; }

        public string Note { get; set; }
        public bool DisplayToCustomer { get; set; }


    }
}