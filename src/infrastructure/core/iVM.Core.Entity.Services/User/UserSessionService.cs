using iVM.Core.Entity;
using iVM.Data.Master.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.Core.Entity.Services
{
  public class UserSessionService
  {
    public UserSessionService(MasterContext masterContext)
    {
      this.masterContext = masterContext;

      var vehicleModel = this.masterContext.Vehicles.SingleOrDefault(v => v.Id == 1);

      if (vehicleModel != null)
      {
        var car = new CarEntity();
        car.Id = vehicleModel.Id;
        car.Mileage = vehicleModel.Mileage;

        this.CurrentVehicle = car;
      }
    }
    private readonly MasterContext masterContext;

    public bool IsFirstLaunch
    {
      get
      {
        return !this.masterContext.Vehicles.Any();
      }
    }
    public VehicleEntity CurrentVehicle { get; set; }
  }
}
