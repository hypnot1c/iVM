using Microsoft.Data.Entity.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iVM.Model;

namespace iVM.Data.SQLdatabase.ModelConfigurations
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
