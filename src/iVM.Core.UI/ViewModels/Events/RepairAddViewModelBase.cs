using Caliburn.Micro;
using iVM.Core.Entity;
using System;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class RepairAddViewModelBase: BaseViewModel
  {
    protected readonly EventOccuredEntity _evOccured;
    protected readonly RepairEntity _repair;

    public RepairAddViewModelBase(IEventAggregator eventAggregator): base(eventAggregator)
    {
      this._evOccured = new EventOccuredEntity();
      this._repair = new RepairEntity();
    }

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


    protected override void viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      base.viewModel_PropertyChanged(sender, e);
      switch (e.PropertyName)
      {
        case nameof(this.Name):
          this._evOccured.Name = this.Name;
          break;
        case nameof(this.Date):
          this._evOccured.Date = this.Date;
          break;
        case nameof(this.Expense):
          this._evOccured.Expense = Decimal.Parse(this.Expense);
          break;
        case nameof(this.Mileage):
          this._evOccured.Mileage = this.Mileage;
          break;
        case nameof(this.ServiceStationName):
          this._repair.ServiceStationName = this.ServiceStationName;
          break;
      }
    }
    protected virtual void Save()
    {
      throw new NotImplementedException();
    }
  }
}
