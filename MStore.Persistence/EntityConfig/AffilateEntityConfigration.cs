using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Marketing.Affiliates;
using MStore.Domain.Entities.Sales.Orders;

namespace MStore.Persistence.EntityConfig
{
    public class AffilateEntityConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.Affiliate).WithMany(x => x.Orders).HasForeignKey(x => x.AffiliateId);
        }
    }
}
