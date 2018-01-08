using System;
using System.Collections.Generic;

namespace iVM.Data.Master.Model
{
  public class EventOccuredModel: EventModel
  {
    public int Vehicle_VehicleId { get; set; }
    public DateTime Date { get; set; }
    public ulong Mileage { get; set; }
    public decimal Expense { get; set; }
    public decimal Profit { get; set; }
    public string Title { get; set; }

    public int EntityId { get; set; }
    public EventType Type { get; set; }

    public EventOccuredModel()
    {
      this.Date = DateTime.UtcNow;
    }
  }

  public enum EventType
  {
    Other = 0,
    FillUp = 1
  }
}
