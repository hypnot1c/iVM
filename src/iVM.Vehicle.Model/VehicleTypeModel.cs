using System.Collections.Generic;

namespace iVM.Vehicle.Model
{
  public class VehicleTypeModel : BaseModel
  {
    public string Name { get; set; }
    public ICollection<VehicleBrandAndTypeModel> VehicleBrands { get; set; }

  }
}
