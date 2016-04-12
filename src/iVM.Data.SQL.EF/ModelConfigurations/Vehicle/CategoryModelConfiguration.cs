using iVM.Vehicle.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class CategoryModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<Category> builder)
    {
      builder.HasKey(p => p.ID);
      builder.HasMany(p => p.Types).WithOne(p => p.Category);
      builder.Property(p => p.Name).IsRequired();
    }
  }
}
