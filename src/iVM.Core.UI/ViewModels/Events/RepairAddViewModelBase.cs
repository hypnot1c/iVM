using Caliburn.Micro;
using iVM.Data.Model;
using iVM.Model;
using System;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class RepairAddViewModelBase: BaseViewModel
  {
    protected readonly EventOccured _evOccured;
    protected readonly Repair _repair;

    public RepairAddViewModelBase(IEventAggregator eventAggregator): base(eventAggregator)
    {
      this._evOccured = new EventOccured();
      this._repair = new Repair();
    }

    private DateTime _date;
    public DateTime Date
    {
      get { return this._date; }
      set { this._date = value; NotifyOfPropertyChange(() => this.Date); }
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
