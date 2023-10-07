using System;
using MStore.Domain.Entities.Marketing.Affiliates;

namespace MStore.Application.Dtos.MarketingDto.AffiliateDto
{
    public class PostAffiliateDto
    {   
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string Name { get; set; }
        public string OtherName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPercentCommission { get; set; }
        public decimal CommissionPercent  { get; set; }
        public decimal CommissionAmount { get; set; }
        public bool OnlyForFirstOrder { get; set; }
        public string AdminComment { get; set; }
        public string FriendlyUrlName { get; set; }
        public bool IsActive { get; set; }
    }
}