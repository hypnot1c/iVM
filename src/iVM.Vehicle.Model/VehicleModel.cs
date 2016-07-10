namespace iVM.Vehicle.Model
{
  public enum VehicleType
  {
    Unknown = 0,
    Car = 1
  }

  public class VehicleModel : BaseModel
  {
    public int BrandId { get; set; }
    public VehicleType Type { get; set; }
    public string Name { get; set; }
  }
}
