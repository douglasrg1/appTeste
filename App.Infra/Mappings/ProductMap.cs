using System.Data.Entity.ModelConfiguration;
using App.Domain.Entities;

namespace App.Infra.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(x=>x.Id);
            Property(x=>x.Price).IsRequired().HasColumnType("money");
            Property(x=>x.Image).IsRequired().HasMaxLength(1024);
            Property(x=>x.QuantityOnHand);
            Property(x=>x.Title).IsRequired().HasMaxLength(80);
             
        }
    }
}