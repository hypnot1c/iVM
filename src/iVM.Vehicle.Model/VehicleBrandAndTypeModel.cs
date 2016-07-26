namespace iVM.Vehicle.Model
{
  public class VehicleBrandAndTypeModel
  {
    public int BrandId { get; set; }
    public VehicleBrandModel Brand { get; set; }
    public int TypeId { get; set; }
    public VehicleTypeModel Type { get; set; }

  }
}
