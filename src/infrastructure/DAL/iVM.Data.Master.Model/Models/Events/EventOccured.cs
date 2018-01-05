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
    public ICollection<FillUpModel> FillUps { get; set; }
    public ICollection<Repair> Repairs { get; set; }
    public string Title { get; set; }

    public EventOccuredModel()
    {
      this.FillUps = new HashSet<FillUpModel>();
      this.Repairs = new List<Repair>();
    }
  }
}
