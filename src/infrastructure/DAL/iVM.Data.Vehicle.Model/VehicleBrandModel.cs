using System.Collections.Generic;

namespace iVM.Data.Vehicle.Model
{
  public class VehicleBrandModel : BaseModel
  {
    public VehicleBrandModel()
    {
      this.VehicleTypes = new List<VehicleBrandAndTypeModel>();
    }

    public string Title { get; set; }
    public ICollection<VehicleBrandAndTypeModel> VehicleTypes { get; set; }

  }
}
