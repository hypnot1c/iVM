using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class ModelModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<iVM.Vehicle.Model.Model> builder)
    {
      builder.HasKey(p => p.ID);
      builder.Property(p => p.BrandID).IsRequired();
      builder.Property(p => p.TypeID).IsRequired();
      builder.HasOne(b => b.Brand).WithMany(m => m.Models);
      builder.HasOne(b => b.Type).WithMany(m => m.Models);
      builder.Property(p => p.Name).IsRequired();
    }
  }
}
