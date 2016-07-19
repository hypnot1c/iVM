using System.Collections.Generic;

namespace iVM.Vehicle.Model
{
  public class VehicleBrandModel : BaseModel
  {
    public string Title { get; set; }
    public ICollection<VehicleType> VehicleTypes { get; set; }

  }
}
