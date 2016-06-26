namespace iVM.Core.Entity
{
  public class RepairEntity : RepairBaseEntity
  {
    public string ServiceStationName { get; set; }
    public int EventOccuredID { get; set; }
    public EventOccuredEntity EventOccured { get; set; }
  }
}
