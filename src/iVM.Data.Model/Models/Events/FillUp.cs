namespace iVM.Data.Model
{
  public class FillUpModel : BaseModel
  {
    public int EventOccuredId { get; set; }
    public EventOccured EventOccured { get; set; }
    public decimal LitresValue { get; set; }
    public decimal LiterCost { get; set; }
    public string CompanyName { get; set; }
  }
}
