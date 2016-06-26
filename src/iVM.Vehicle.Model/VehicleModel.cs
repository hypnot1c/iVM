namespace iVM.Vehicle.Model
{
  public enum VehicleType
  {
    Unknown = 0,
    Car = 1
  }

  public enum VehicleManufacturer
  {
    Unknown = 0,
    Peugeot = 1,
    Volkswagen = 2
  }
  public class VehicleModel : BaseModel
  {
    public string Name { get; set; }
    public VehicleType Type { get; set; }
    public VehicleManufacturer Manufacturer { get; set; }
  }
}
