﻿namespace iVM.Core.Entity
{
  public class CarEntity : VehicleEntity
  {
    public int BrandId { get; set; }
    public BrandEntity Brand { get; set; }

  }
}