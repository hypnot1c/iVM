using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using System;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class FillUpAddViewModelBase : BaseViewModel
  {
    private readonly EventService _eventService;
    private readonly SessionService _sessionService;
    protected readonly FillUpEntity _fillUp;

    private DateTime _date;
    public DateTime Date
    {
      get { return this._date; }
      set { this._date = value; NotifyOfPropertyChange(() => this.Date); }
    }

    private string _title;

    public string Title
    {
      get { return _title; }
      set { _title = value; NotifyOfPropertyChange(() => this.Title); }
    }


    private decimal _litres;
    public decimal Litres
    {
      get { return this._litres; }
      set { this._litres = value; NotifyOfPropertyChange(() => this.Litres); }
    }

    private decimal _expense;
    public decimal Expense
    {
      get { return this._expense; }
      set { this._expense = value; NotifyOfPropertyChange(() => this.Expense); }
    }

    private decimal _literCost;
    public decimal LiterCost
    {
      get { return this._literCost; }
      set { this._literCost = value; NotifyOfPropertyChange(() => this.LiterCost); }
    }

    private ulong _mileage;

    public ulong Mileage
    {
      get { return this._mileage; }
      set { this._mileage = value; NotifyOfPropertyChange(() => this.Mileage); }
    }

    public FillUpAddViewModelBase(
      IEventAggregator eventAggregator,
      EventService eventService,
      SessionService sessionService
      ) : base(eventAggregator)
    {
      this._eventService = eventService;
      this._sessionService = sessionService;
      this._fillUp = new FillUpEntity();
      this.Date = DateTime.Now;
    }

    protected override void viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      //base.viewModel_PropertyChanged(sender, e);
      //switch (e.PropertyName)
      //{
      //  case nameof(this.Date):
      //    this._evOccured.Date = this.Date;
      //    break;
      //  case nameof(this.Litres):
      //    this._fillUp.LitresValue = Decimal.Parse(this.Litres);
      //    break;
      //  case nameof(this.Expense):
      //    this._evOccured.Expense = Decimal.Parse(this.Expense);
      //    break;
      //  case nameof(this.LiterCost):
      //    this._fillUp.LiterCost = Decimal.Parse(this.LiterCost);
      //    break;
      //  case nameof(this.Mileage):
      //    this._evOccured.Mileage = this.Mileage;
      //    break;
      //}
    }

    protected virtual void Save()
    {
      this._fillUp.Litres = this.Litres;
      this._fillUp.LiterCost = this.LiterCost;
      this._fillUp.Expense = this.Expense;
      this._fillUp.Name = this.Title;
      this._fillUp.OccuredDate = this.Date;
      this._fillUp.Vehicle = this._sessionService.CurrentVehicle;
      this._fillUp.Mileage = this.Mileage;
      this._eventService.AddFillUp(this._fillUp);
    }
  }
}