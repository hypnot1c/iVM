using System.Collections.Generic;

namespace iVM.Vehicle.Model
{
  public class VehicleBrandModel : BaseModel
  {
    public VehicleBrandModel()
    {
      this.VehicleTypes = new HashSet<VehicleTypeModel>();
    }
    public string Title { get; set; }
    public ICollection<VehicleTypeModel> VehicleTypes { get; set; }

  }
}
