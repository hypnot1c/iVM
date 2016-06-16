﻿using iVM.Data.Model;
using Microsoft.Data.Entity.Metadata.Builders;

namespace iVM.Data.SQL.EF.SQLdatabase.ModelConfigurations
{
  public class RepairModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<Repair> builder)
    {
      builder.HasKey(p => p.ID);
      builder.Property(p => p.EventOccuredID).IsRequired();
      builder.HasOne<EventOccured>(eo => eo.EventOccured).WithMany(fu => fu.Repairs);
    }
  }
}