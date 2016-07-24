using System;
using System.Collections.Generic;

namespace iVM.Data.Model
{
  public class EventOccured: EventModel
  {
    public DateTime Date { get; set; }
    public ulong Mileage { get; set; }
    public decimal Expense { get; set; }
    public decimal Profit { get; set; }
    public ICollection<FillUpModel> FillUps { get; set; }
    public ICollection<Repair> Repairs { get; set; }
    public EventOccured()
    {
      this.FillUps = new HashSet<FillUpModel>();
      this.Repairs = new List<Repair>();
    }
  }
}
