using iVM.Core.Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace iVM.Core.Entity
{
  public class MaintenanceEntity : EventOccuredEntity
  {
    public string ServiceStationName { get; set; }
    public IEnumerable<MaintenanceItemEntity> ListOfWorks { get; set; }
    public override decimal Expense
    {
      get
      {
        return this.ListOfWorks.Sum(i => (i.PartCost + i.WorkCost));
      }

      set
      {
        base.Expense = value;
      }
    }
  }
}
