namespace iVM.Data.Master.Model
{
  public class MaintenanceItemModel : BaseModel
  {
    public int MaintenanceId { get; set; }
    public string Title { get; set; }
    public decimal PartsCost { get; set; }
    public decimal WorkCost { get; set; }

  }
}