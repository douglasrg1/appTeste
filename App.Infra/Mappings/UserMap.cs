using System.Data.Entity.ModelConfiguration;
using App.Domain.Entities;

namespace App.Infra.Mappings
{
    public class Usermap : EntityTypeConfiguration<User>
    {
        public Usermap()
        {
            ToTable("Customer");
            HasKey(x=>x.Id);
            Property(x=>x.UserName).IsRequired().HasMaxLength(20);
            Property(x=>x.PassWord).IsRequired().HasMaxLength(20);
            Property(x=>x.Active);
             
        }
    }
}