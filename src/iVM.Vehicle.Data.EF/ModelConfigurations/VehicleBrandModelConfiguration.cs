﻿using iVM.Vehicle.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace iVM.Vehicle.Data.EF.ModelConfigurations
{
  public class VehicleModelModelConfiguration
  {
    public static void Configure(EntityTypeBuilder<VehicleModel> builder)
    {
      builder.HasKey(p => p.Id);
    }
  }
}
