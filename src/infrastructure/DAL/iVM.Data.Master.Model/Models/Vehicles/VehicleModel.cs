namespace iVM.Data.Master.Model
{
  public class VehicleModel: BaseModel
  {
    public int Type_vehicleTypeId { get; set; }
    public int Model_vehicleModelId { get; set; }
    public ulong Mileage { get; set; }
  }
}
