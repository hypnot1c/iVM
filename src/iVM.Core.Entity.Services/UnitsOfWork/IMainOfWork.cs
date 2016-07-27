namespace iVM.Core.Entity.Services
{
  public interface IMainUnitOfWork : IUnitOfWork
  {
    IEventOccuredRepository EventsOccured { get; }
    IFillUpRepository FillUps { get; }
    IVehicleRepository Vehicles { get; }
  }
}
