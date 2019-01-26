using Caliburn.Micro;
using System.Threading;
using System.Threading.Tasks;

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

    protected override Task OnActivateAsync(CancellationToken cancellationToken)
    {
      _evAggregator.SubscribeOnPublishedThread(this);
      return Task.CompletedTask;
    }

    protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
    {
      _evAggregator.Unsubscribe(this);
      return Task.CompletedTask;
    }
  }
}
