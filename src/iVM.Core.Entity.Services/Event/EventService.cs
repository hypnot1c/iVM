using iVM.Data.Model;

namespace iVM.Core.Entity.Services
{
  public class EventService
  {
    private readonly IEventOccuredRepository _eventOccuredRepository;
    private readonly IFillUpRepository _fillUpRepository;

    public EventService(
      IEventOccuredRepository eventOccuredRepository,
      IFillUpRepository fillUpRepository
      )
    {
      this._eventOccuredRepository = eventOccuredRepository;
      this._fillUpRepository = fillUpRepository;
    }

    public void AddFillUp(FillUpEntity fillUp)
    {
      var eo = new EventOccured
      {
        Date = fillUp.OccuredDate,
        Expense = fillUp.Expense,
        Profit = fillUp.Profit,
        Mileage = fillUp.Mileage
      };
      this._eventOccuredRepository.Add(eo);
      var fu = new FillUpModel
      {
        Id = fillUp.Id,
        EventOccuredID = eo.Id,
        LiterCost = fillUp.LiterCost,
        LitresValue = fillUp.Litres
      };
      this._fillUpRepository.Add(fu);
    }
  }
}
