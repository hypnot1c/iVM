using iVM.Vehicle.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class CategoryToTypeModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<CategoryToType> builder)
    {
      builder.HasKey(k => new { k.CategoryID, k.TypeID });
      builder.HasOne(p => p.Category).WithMany(p => p.Types);
      builder.HasOne(p => p.Type).WithMany(p => p.Categories);
    }
  }
}
