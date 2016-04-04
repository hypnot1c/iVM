namespace iVM.Data.Model
{
  public abstract class Event: BaseModel
  {
    public int EventTypeID { get; set; }
    public EventType Type { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
