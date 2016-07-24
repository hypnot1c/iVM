using System;

namespace iVM.Core.Entity.Services
{
  public class SessionService
  {
    private readonly VehicleService _vehicleService;

    public SessionService(
      IConfigurationService configService,
      VehicleService vehicleService
      )
    {
      this._configService = configService;
      this._vehicleService = vehicleService;
    }

    private readonly IConfigurationService _configService;
    private VehicleEntity _currentVehicle;

    public VehicleEntity CurrentVehicle
    {
      get
      {
        if(_currentVehicle == null)
        {
          var vId = Int32.Parse(this._configService.GetNumber("SelectedVehicleId").ToString());
          this._currentVehicle = this._vehicleService.GetVehicle(vId);
        }
        return _currentVehicle;
      }
    }

  }
}
