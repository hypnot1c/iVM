using iVM.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class EventOccuredModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<EventOccured> builder)
    {
      builder.HasKey(p => p.ID);
      builder.Property(p => p.Date).IsRequired();
      builder.Property(p => p.EventTypeID).IsRequired();
      builder.Property(p => p.Name).IsRequired();

      builder.HasOne<EventType>(eo => eo.Type);
      builder.HasMany<FillUp>(eo => eo.FillUps).WithOne(fu => fu.EventOccured);
    }
  }
}
