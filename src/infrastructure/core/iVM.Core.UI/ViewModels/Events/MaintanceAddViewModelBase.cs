using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.Entity.Entities;
using iVM.Core.Entity.Services;
using System;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class MaintenanceAddViewModelBase : BaseViewModel
  {
    public MaintenanceAddViewModelBase(
      IEventAggregator eventAggregator,
      EventService eventService,
      SessionService sessionService
      ): base(eventAggregator)
    {
      this._eventService = eventService;
      this._sessionService = sessionService;
      this._maintenanceEntity = new MaintenanceEntity();
      this.WorkItems = new BindableCollection<MaintenanceItemEntity>();
    }
    private readonly EventService _eventService;
    private readonly MaintenanceEntity _maintenanceEntity;

    private DateTime _date;
    public DateTime Date
    {
      get { return this._date; }
      set { this._date = value; NotifyOfPropertyChange(() => this.Date); }
    }

    private string _name;
    public string Name
    {
      get { return this._name; }
      set { this._name = value; NotifyOfPropertyChange(() => this.Name); }
    }

    private string _expense;
    public string Expense
    {
      get { return this._expense; }
      set { this._expense = value; NotifyOfPropertyChange(() => this.Expense); }
    }

    private ulong _mileage;
    public ulong Mileage
    {
      get { return this._mileage; }
      set { this._mileage = value; NotifyOfPropertyChange(() => this.Mileage); }
    }

    private string _serviceStationName;

    public string ServiceStationName
    {
      get { return _serviceStationName; }
      set { _serviceStationName = value; NotifyOfPropertyChange(() => this.Mileage); }
    }

    private IObservableCollection<MaintenanceItemEntity> _workItems;
    private readonly SessionService _sessionService;

    public IObservableCollection<MaintenanceItemEntity> WorkItems
    {
      get { return _workItems; }
      set
      {
        _workItems = value;
        this.NotifyOfPropertyChange(() => this.WorkItems);
      }
    }



    protected override void viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      base.viewModel_PropertyChanged(sender, e);
      //switch (e.PropertyName)
      //{
      //  case nameof(this.Name):
      //    this._evOccured.Name = this.Name;
      //    break;
      //  case nameof(this.Date):
      //    this._evOccured.Date = this.Date;
      //    break;
      //  case nameof(this.Expense):
      //    this._evOccured.Expense = Decimal.Parse(this.Expense);
      //    break;
      //  case nameof(this.Mileage):
      //    this._evOccured.Mileage = this.Mileage;
      //    break;
      //  case nameof(this.ServiceStationName):
      //    this._repair.ServiceStationName = this.ServiceStationName;
      //    break;
      //}
    }
    protected virtual void Save()
    {
      this._maintenanceEntity.Name = this.Name;
      this._maintenanceEntity.OccuredDate = this.Date;
      this._maintenanceEntity.Mileage = this.Mileage;
      this._maintenanceEntity.ServiceStationName = this.ServiceStationName;
      this._maintenanceEntity.Vehicle = this._sessionService.CurrentVehicle;
      this._maintenanceEntity.ListOfWorks = this.WorkItems;
      this._eventService.AddMaintenance(this._maintenanceEntity);
    }
  }
}
