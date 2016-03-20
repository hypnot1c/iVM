using System;

namespace iVM.Model
{
  public class EventOccured: Event
  {
    public DateTime Date { get; set; }
    public decimal Mileage { get; set; }
    public uint Expense { get; set; }
    public uint Profit { get; set; }
  }
}
