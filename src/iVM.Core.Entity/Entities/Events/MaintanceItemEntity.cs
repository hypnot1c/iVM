namespace iVM.Core.Entity.Entities
{
  public class MaintenanceItemEntity : BaseEntity
  {
    public string Title { get; set; }
    public decimal PartCost { get; set; }
    public decimal WorkCost { get; set; }
  }
}
