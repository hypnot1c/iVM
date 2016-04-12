using iVM.Vehicle.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class TypeModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<Type> builder)
    {
      builder.HasKey(p => p.ID);
      builder.HasMany(t => t.Models).WithOne(m => m.Type);
      builder.HasMany(p => p.Categories).WithOne(p => p.Type);
      builder.Property(p => p.Name).IsRequired();
    }
  }
}
