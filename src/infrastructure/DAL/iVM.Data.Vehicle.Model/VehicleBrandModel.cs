using System.Collections.Generic;

namespace iVM.Data.Vehicle.Model
{
  public class VehicleBrandModel : BaseModel
  {
    public string Title { get; set; }
    public ICollection<VehicleBrandAndTypeModel> VehicleTypes { get; set; }

  }
}
