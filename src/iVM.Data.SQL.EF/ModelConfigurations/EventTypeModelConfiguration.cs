using iVM.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class EventTypeModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<EventType> builder)
    {
      builder.HasKey(p => p.ID);
      builder.HasMany<EventOccured>(x => x.EventsOccured);
      builder.Property(p => p.Name).IsRequired();
    }
  }
}
