using System;
using System.Collections.Generic;

namespace iVM.Model
{
  public class EventOccured: Event
  {
    public DateTime Date { get; set; }
    public ulong Mileage { get; set; }
    public decimal Expense { get; set; }
    public decimal Profit { get; set; }
    public ICollection<FillUp> FillUps { get; set; }

    public EventOccured()
    {
      this.FillUps = new List<FillUp>();
    }
  }
}
