using System.Data.Entity.ModelConfiguration;
using App.Domain.Entities;

namespace App.Infra.Mappings
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItem");
            HasKey(x=>x.Id);
            Property(x=>x.Price).IsRequired().HasColumnType("money");
            Property(x=>x.Quantity).IsRequired();
            HasRequired(x=>x.Product);
             
        }
    }
}