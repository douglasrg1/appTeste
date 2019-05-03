using System.Data.Entity.ModelConfiguration;
using App.Domain.Entities;

namespace App.Infra.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");
            HasKey(x=>x.Id);
            Property(x=>x.Deliveryfee).IsRequired().HasColumnType("money");
            Property(x=>x.CreateDate);
            Property(x=>x.Discount).IsRequired().HasColumnType("money");
            Property(x=>x.Number).IsRequired().HasMaxLength(8).IsFixedLength();
            Property(x=>x.Status).IsRequired();
            HasMany(x=>x.Items);
            HasRequired(x=>x.Customer);
             
        }
    }
}