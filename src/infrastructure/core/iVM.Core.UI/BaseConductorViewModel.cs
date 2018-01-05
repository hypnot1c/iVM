using Caliburn.Micro;

namespace iVM.Core.UI
{
  public class BaseConductorViewModel : Conductor<IScreen>.Collection.OneActive
  {
    protected readonly IEventAggregator _evAggregator;

    public BaseConductorViewModel(IEventAggregator eventAggregator)
    {
      this._evAggregator = eventAggregator;
      this.PropertyChanged += viewModel_PropertyChanged;
    }

    protected virtual void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      //throw new System.NotImplementedException();
    }

    protected override void OnActivate()
    {
      _evAggregator.Subscribe(this);
    }

    protected override void OnDeactivate(bool close)
    {
      _evAggregator.Unsubscribe(this);
    }
  }
}
