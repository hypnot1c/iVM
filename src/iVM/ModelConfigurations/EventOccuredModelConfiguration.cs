using Microsoft.Data.Entity.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iVM.Model;

namespace iVM.Data.SQLdatabase.ModelConfigurations
{
  public class EventOccuredModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<EventOccured> builder)
    {
      builder.HasKey(p => p.ID);
      builder.Property(p => p.Date).IsRequired();
      builder.Property(p => p.EventTypeID).IsRequired();
      builder.HasOne<EventType>(eo => eo.Type);
      builder.Property(p => p.Name).IsRequired();
    }
  }
}
