using Caliburn.Micro;

namespace iVM.Core.UI
{
  public abstract class BaseViewModel: Screen
  {
    protected readonly IEventAggregator _evAggregator;

    public BaseViewModel(IEventAggregator eventAggregator)
    {
      this._evAggregator = eventAggregator;
      this.PropertyChanged += ViewModel_PropertyChanged;
    }

    protected virtual void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
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
