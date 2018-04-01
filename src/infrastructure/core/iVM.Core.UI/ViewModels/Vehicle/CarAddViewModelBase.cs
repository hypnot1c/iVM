using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Data.Master.Context;
using iVM.Data.Vehicle.Context;
using iVM.Data.Vehicle.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iVM.Core.UI.ViewModels.Vehicle
{
  public class CarAddViewModelBase : BaseViewModel
  {
    public CarAddViewModelBase(
      IEventAggregator eventAggregator,
      MasterContext masterContext,
      VehicleContext vehicleContext
      ) : base(eventAggregator)
    {
      this.masterContext = masterContext;
      this.vehicleContext = vehicleContext;
    }

    protected readonly MasterContext masterContext;
    protected readonly VehicleContext vehicleContext;

    private string _brandName;
    public string BrandName
    {
      get { return this._brandName; }
      set { this._brandName = value; NotifyOfPropertyChange(() => this.BrandName); }
    }

    private string _modelName;

    public string ModelName
    {
      get { return this._modelName; }
      set { this._modelName = value; NotifyOfPropertyChange(() => this.ModelName); }
    }

    private string _name;
    public string Name
    {
      get { return this._name; }
      set { this._name = value; NotifyOfPropertyChange(() => this.Name); }
    }

    private ulong _miliage;
    public ulong Miliage
    {
      get { return this._miliage; }
      set { this._miliage = value; NotifyOfPropertyChange(() => this.Miliage); }
    }

    protected virtual async void Save()
    {
      var car = new CarEntity();

      var brandId = await this.vehicleContext.VehicleBrands
        .Where(vb => vb.Title == this.BrandName)
        .Select(vb => vb.Id)
        .FirstOrDefaultAsync();

      var type = await this.vehicleContext.VehicleTypes.FirstOrDefaultAsync(vt => vt.Name == "Car");
      if(brandId == 0)
      {
        var brand = new VehicleBrandModel
        {
          Title = this.BrandName
        };
        brand.VehicleTypes.Add(new VehicleBrandAndTypeModel { Type = type });
        await this.vehicleContext.VehicleBrands.AddAsync(brand);
        await this.vehicleContext.SaveChangesAsync();
        brandId = brand.Id;
      }

      var modelId = await this.vehicleContext.VehicleModels
        .Where(vm => vm.Brand_BrandId == brandId)
        .Where(vm => vm.Name == this.ModelName)
        .Select(vm => vm.Id)
        .FirstOrDefaultAsync();

      if(modelId == 0)
      {
        var model = new VehicleModel
        {
          Name = this.ModelName,
          Type_TypeId = type.Id
        };
        await this.vehicleContext.VehicleModels.AddAsync(model);
        await this.vehicleContext.SaveChangesAsync();
        modelId = model.Id;
      }
      var userVehicle = new Data.Master.Model.VehicleModel
      {
        Type_vehicleTypeId = type.Id,
        Model_vehicleModelId = modelId,
        CorrectionDate = DateTime.UtcNow
      };
      await this.masterContext.Vehicles.AddAsync(userVehicle);
      await this.masterContext.SaveChangesAsync();
    }
  }
}
