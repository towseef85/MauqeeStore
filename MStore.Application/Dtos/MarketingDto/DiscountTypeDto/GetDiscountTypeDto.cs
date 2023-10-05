using System;
using MStore.Domain.Entities.Marketing.Discounts;

namespace MStore.Application.Dtos.MarketingDto.DiscountTypeDto;

public class GetDiscountTypeDto
{
    public Guid Id { get; set; }
    public Guid SubscriptionId { get; set; }
    public string Name { get; set; }
    public string OtherName { get; set; }
    public string Type { get; set; }
    public ICollection<Discount> Discounts { get; set; }

}
