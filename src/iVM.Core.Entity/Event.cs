namespace iVM.Core.Entity
{
  public abstract class Event: BaseEntity
  {
    public EventType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
