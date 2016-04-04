namespace iVM.Data.Model
{
  public class FillUp : BaseModel
  {
    public int EventOccuredID { get; set; }
    public EventOccured EventOccured { get; set; }
    public decimal LitresValue { get; set; }
    public decimal LiterCost { get; set; }
  }
}
