using iVM.Core.Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace iVM.Core.Entity
{
  public class MaintenanceEntity : EventOccuredEntity
  {
    public MaintenanceEntity()
    {
      this.ListOfWorks = new List<MaintenanceItemEntity>();
    }
    public string ServiceStationName { get; set; }
    public IEnumerable<MaintenanceItemEntity> ListOfWorks { get; set; }
    public override decimal Expense
    {
      get
      {
        if (this.ListOfWorks.Any())
        {
          return this.ListOfWorks.Sum(i => (i.PartCost + i.WorkCost));
        }
        else
        {
          return base.Expense;
        }
      }

      set
      {
        base.Expense = value;
      }
    }
  }
}
