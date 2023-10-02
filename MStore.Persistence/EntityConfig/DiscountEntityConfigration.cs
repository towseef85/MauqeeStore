using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Sales.Discounts;

namespace MStore.Persistence.EntityConfig
{
	public class DiscountEntityConfigration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasOne(x => x.DiscountType).WithMany(x => x.Discounts).HasForeignKey(x => x.DiscountTypeId);
        }
    }
}



