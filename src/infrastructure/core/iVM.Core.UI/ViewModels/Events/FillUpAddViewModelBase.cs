using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using iVM.Data.Master.Context;
using System;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class FillUpAddViewModelBase : BaseViewModel
  {

    public FillUpAddViewModelBase(
      IEventAggregator eventAggregator,
      UserSessionService userSessionService,
      MasterContext masterContext
      ) : base(eventAggregator)
    {
      this.Date = DateTime.Now;
      this.masterContext = masterContext;
      this.userSessionService = userSessionService;
      this.Mileage = this.userSessionService.CurrentVehicle.Mileage;
    }

    private readonly MasterContext masterContext;
    private readonly UserSessionService userSessionService;
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
      base.ViewModel_PropertyChanged(sender, e);
      switch (e.PropertyName)
      {
        case nameof(this.Expense):
        case nameof(this.Litres):
          if (this.Litres > 0)
          {
            this.LiterCost = this.Expense / this.Litres;
          }
          break;
      }
    }


    protected async virtual void Save()
    {
      //using (var tran = await this.masterContext.Database.BeginTransactionAsync())
      //{
      var fillUp = new FillUpEntity();
      fillUp.Expense = this.Expense;
      fillUp.Litres = this.Litres;
      fillUp.LiterCost = this.LiterCost;
      fillUp.Name = this.Title;
      fillUp.OccuredDate = this.Date;
      fillUp.Mileage = this.Mileage;

      fillUp.Vehicle = this.userSessionService.CurrentVehicle;

      await this.masterContext.FillUp_CreateAsync(fillUp);
      //  tran.Commit();
      //}
    }
  }
}
