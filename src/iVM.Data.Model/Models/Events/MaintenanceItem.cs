namespace iVM.Data.Model
{
  public class MaintenanceItemModel : BaseModel
  {
    public string Title { get; set; }
    public decimal PartsCost { get; set; }
    public decimal WorkCost { get; set; }

  }
}