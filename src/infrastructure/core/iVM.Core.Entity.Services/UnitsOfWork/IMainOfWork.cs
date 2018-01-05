namespace iVM.Core.Entity.Services
{
  public interface IMainUnitOfWork : IUnitOfWork
  {
    IEventOccuredRepository EventsOccured { get; }
    IFillUpRepository FillUps { get; }
    IMaintenanceRepository Maintenances { get; }
    IMaintenanceItemRepository MaintenanceItems { get; }
    IVehicleRepository Vehicles { get; }
  }
}
