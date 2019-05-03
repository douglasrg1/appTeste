using System.Data.Entity.ModelConfiguration;
using App.Domain.Entities;

namespace App.Infra.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x=>x.Id);
            Property(x=>x.Document.Number).IsRequired().HasMaxLength(11).IsFixedLength();
            Property(x=>x.BirthDate).IsOptional();
            Property(x=>x.Email.Address).IsRequired().HasMaxLength(100);
            Property(x=>x.Name.FirstName).IsRequired().HasMaxLength(60);
            Property(x=>x.Name.LastName).IsRequired().HasMaxLength(60);
            HasRequired(x=>x.User);
             
        }
    }
}