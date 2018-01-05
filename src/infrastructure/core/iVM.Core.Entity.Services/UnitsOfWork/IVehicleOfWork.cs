namespace iVM.Core.Entity.Services
{
  public interface IVehicleUnitOfWork : IUnitOfWork
  {
    IVehicleModelRepository VehicleModels { get; }
    IVehicleTypeRepository VehicleTypes { get; }
    IVehicleBrandRepository VehcileBrands { get; }
  }
}
