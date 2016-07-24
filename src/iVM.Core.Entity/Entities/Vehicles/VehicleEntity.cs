namespace iVM.Core.Entity
{
  public abstract class VehicleEntity: BaseEntity
  {
    public string Title { get; set; }
    public VehicleBrandEntity Brand { get; set; }
    public VehicleModelEntity Model { get; set; }
    public VehicleTypeEntity Type { get; set; }

    public static VehicleEntity CreateVehicle(VehicleTypeEntity _selectedVehicleType)
    {
      switch(_selectedVehicleType.Id)
      {
        case 1:
        default:
          return new CarEntity();
      }
    }
  }
}
