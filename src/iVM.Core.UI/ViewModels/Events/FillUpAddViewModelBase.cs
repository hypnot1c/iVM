using Caliburn.Micro;
using System;
using System.ComponentModel;

namespace iVM.Core.UI.ViewModels
{
  public class FillUpAddViewModelBase : BaseViewModel
  {
    //protected readonly EventOccured _evOccured;
    //protected readonly FillUp _fillUp;

    private DateTime _date;
    public DateTime Date
    {
      get { return this._date; }
      set { this._date = value; NotifyOfPropertyChange(() => this.Date); }
    }

    private string _litres;
    public string Litres
    {
      get { return this._litres; }
      set { this._litres = value; NotifyOfPropertyChange(() => this.Litres); }
    }

    private string _expense;
    public string Expense
    {
      get { return this._expense; }
      set { this._expense = value; NotifyOfPropertyChange(() => this.Expense); }
    }

    private string _literCost;
    public string LiterCost
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

    public FillUpAddViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
    {
      //this._evOccured = new EventOccured();
      //this._fillUp = new FillUp();
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
      throw new NotImplementedException();
    }
  }
}