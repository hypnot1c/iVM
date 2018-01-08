using Caliburn.Micro;
using iVM.Data.Master.Context;
using iVM.Data.Master.Model;
using System;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class FillUpAddViewModelBase : BaseViewModel
  {

    public FillUpAddViewModelBase(
      IEventAggregator eventAggregator,
      MasterContext masterContext
      ) : base(eventAggregator)
    {
      this.Date = DateTime.Now;
      this.masterContext = masterContext;
    }

    private readonly MasterContext masterContext;

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


    protected override void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
      //var fillUp = new FillUpModel();
      //fillUp.LitresValue = this.Litres;
      //fillUp.LiterCost = this.LiterCost;

      //var @event = new EventOccuredModel();
      //@event.Expense = this.Expense;
      //@event.Title = this.Title;
      //@event.Date = this.Date;
      //@event.Mileage = this.Mileage;

      //fillUp.EventOccured = @event;

      //@event.Vehicle_VehicleId = 1; //TODO: Get from session

      //this.masterContext.FillUps.Add(fillUp);
    }
  }
}