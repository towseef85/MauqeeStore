using System;
namespace MStore.Application.Dtos.CustomerDto.AddressDto
{
	public class GetAddressDto
	{
        public Guid Id { get; set; }
        public Guid SubscriptionId { get; set; }
        public string EngDesc { get; set; }
        public string ArbDesc { get; set; }
        public int? CountryId { get; set; }
        public int? StateProvinceId { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public Guid CustomerId { get; set; }
    }
}


