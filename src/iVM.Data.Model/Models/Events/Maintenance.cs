using System.Collections.Generic;

namespace iVM.Data.Model
{
  public class MaintenanceModel : BaseModel
  {
    public int EventOccuredId { get; set; }
    public ICollection<MaintenanceItemModel> ListOfWorks { get; set; }
    public string ServiceStationName { get; set; }
  }
}