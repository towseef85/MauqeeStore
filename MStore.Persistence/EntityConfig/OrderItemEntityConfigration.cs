using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Sales.Orders;
namespace MStore.Persistence.EntityConfig
{
    public class OrderItemEntityConfigration: IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(x => x.Orders).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderItemId);
        }
    }
}
