using System;

namespace iVM.Core.Entity
{
  public class EventOccuredEntity: EventEntity
  {
    public VehicleEntity Vehicle { get; set; }
    public DateTime OccuredDate { get; set; }
    public virtual decimal Expense { get; set; }
    public decimal Profit { get; set; }
    public ulong Mileage { get; set; }

  }
}
