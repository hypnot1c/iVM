using Caliburn.Micro;
using iVM.Data.Master.Context;
using iVM.Data.Master.Model;
using System;

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

    protected async virtual void Save()
    {
      //using (var tran = await this.masterContext.Database.BeginTransactionAsync())
      //{
        var fillUp = new FillUpModel();
        fillUp.LitresValue = this.Litres;
        fillUp.LiterCost = this.LiterCost;

        await this.masterContext.FillUps.AddAsync(fillUp);
        await this.masterContext.SaveChangesAsync();

        var @event = new EventOccuredModel();
        @event.Expense = this.Expense;
        @event.Title = this.Title;
        @event.Date = this.Date;
        @event.Mileage = this.Mileage;
        @event.EntityId = fillUp.Id;
        @event.Type = EventType.FillUp;

        @event.Vehicle_VehicleId = 1; //TODO: Get from session

        await this.masterContext.EventsOccured.AddAsync(@event);
        await this.masterContext.SaveChangesAsync();
      //  tran.Commit();
      //}
    }
  }
}