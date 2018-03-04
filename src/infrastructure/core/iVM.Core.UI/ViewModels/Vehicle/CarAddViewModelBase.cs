using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Data.Master.Context;

namespace iVM.Core.UI.ViewModels.Vehicle
{
  public class CarAddViewModelBase : BaseViewModel
  {
    public CarAddViewModelBase(
      IEventAggregator eventAggregator,
      MasterContext masterContext
      ) : base(eventAggregator)
    {
      this.masterContext = masterContext;
    }

    private int _brandId;
    public int BrandId
    {
      get { return this._brandId; }
      set { this._brandId = value; NotifyOfPropertyChange(() => this.BrandId); }
    }

    private int _modelId;
    public int ModelId
    {
      get { return this._modelId; }
      set { this._modelId = value; NotifyOfPropertyChange(() => this.ModelId); }
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

    private readonly MasterContext masterContext;

    public virtual void Save()
    {
      var car = new CarEntity();
      car.Mileage = this.Miliage;
      car.Title = this.Name;
      //car.
    }
  }
}
