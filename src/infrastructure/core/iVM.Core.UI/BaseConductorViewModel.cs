using Caliburn.Micro;
using System.Threading;
using System.Threading.Tasks;

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
