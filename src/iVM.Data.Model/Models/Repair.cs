namespace iVM.Data.Model
{
  public class Repair : RepairBase
  {
    public string ServiceStationName { get; set; }
    public int EventOccuredID { get; set; }
    public EventOccured EventOccured { get; set; }
  }
}