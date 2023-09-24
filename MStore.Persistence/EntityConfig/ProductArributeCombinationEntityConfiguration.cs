using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MStore.Domain.Entities.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStore.Persistence.EntityConfig
{
    public class ProductArributeCombinationEntityConfiguration : IEntityTypeConfiguration<ProductAttributeCombination>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeCombination> builder)
        {
            builder.HasOne(x=>x.Products).WithMany(x=>x.ProductAttributeCombinations).HasForeignKey(x=>x.ProductId);
        }
    }
}
