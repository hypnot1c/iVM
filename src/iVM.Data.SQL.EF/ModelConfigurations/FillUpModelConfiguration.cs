using iVM.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class FillUpModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<FillUp> builder)
    {
      builder.HasKey(p => p.ID);
      builder.Property(p => p.LitresValue).IsRequired();
      builder.Property(p => p.EventOccuredID).IsRequired();
      //builder.HasOne<EventOccured>(eo => eo.EventOccured).WithMany(fu => fu.FillUps);
    }
  }
}
