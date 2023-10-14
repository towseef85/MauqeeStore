using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Marketing.Affiliates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Persistence.EntityConfig
{
    public class AffiliateEnitityConfiguration : IEntityTypeConfiguration<Affiliate>
    {
        public void Configure(EntityTypeBuilder<Affiliate> builder)
        {
            builder.HasOne(x => x.Customers).WithMany(x => x.Affiliates).HasForeignKey(x => x.CustomerId);
        }
    }
}
