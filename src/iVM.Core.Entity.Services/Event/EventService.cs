namespace iVM.Core.Entity.Services
{
  public class EventService
  {
    private readonly IFillUpRepository _fillUpRepository;

    public EventService(
      IFillUpRepository fillUpRepository
      )
    {
      this._fillUpRepository = fillUpRepository;
    }

    public void AddFillUp(FillUpEntity fillUp)
    {
      this._fillUpRepository.Add(fillUp);
    }
  }
}
