using Caliburn.Micro;
using System;

namespace iVM.Core.UI.ViewModels
{
  public class FillUpAddViewModelBase : BaseViewModel
  {
    private decimal litres;
    public decimal Litres
    {
      get { return litres; }
      set
      {
        litres = value;
        NotifyOfPropertyChange(() => Litres);
      }
    }
    public decimal Expense { get; set; }
    public decimal LiterCost { get; set; }
    public decimal Mileage { get; set; }

    public FillUpAddViewModelBase(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }

    protected virtual void Save()
    {
      throw new NotImplementedException();
    }
  }
}