using iVM.Vehicle.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class BrandModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<Brand> builder)
    {
      builder.HasKey(p => p.ID);
      builder.HasMany(b => b.Models).WithOne(m => m.Brand);
      builder.Property(p => p.Name).IsRequired();
    }
  }
}
