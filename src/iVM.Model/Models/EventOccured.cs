using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.Model
{
  public class EventOccured: Event
  {
    public DateTime Date { get; set; }
    public long Mileage { get; set; }
    public uint Expense { get; set; }
    public uint Profit { get; set; }
  }
}
