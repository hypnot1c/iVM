using Caliburn.Micro;
using iVM.Core.Entity;
using iVM.Core.UI.ViewModels;
using iVM.Data.Master.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace iVM.UWP.App.ViewModels
{
  public class EventListViewModel : EventListViewModelBase
  {
    public EventListViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      MasterContext masterContext
      ) : base(eventAggregator, masterContext)
    {
      this._navService = navigationService;

      this.GroupedEvents = this.Events.GroupBy(e => e.OccuredDate.Month);
    }

    private readonly INavigationService _navService;
    public IEnumerable<IGrouping<int, EventOccuredEntity>> GroupedEvents { get; set; }

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
