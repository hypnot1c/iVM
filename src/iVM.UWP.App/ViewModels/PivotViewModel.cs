using Caliburn.Micro;
using iVM.Core.UI;

namespace iVM.UWP.App.ViewModels
{
  public class PivotViewModel : BaseConductorViewModel
  {
    public PivotViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      EventListViewModel eventListVm
      ) : base(eventAggregator)
    {
      this._navService = navigationService;
      this.Items.Add(eventListVm);
      this.ActivateItem(eventListVm);
    }

    private readonly INavigationService _navService;
    public void EventAdd()
    {
      _navService.For<EventTypeSelectViewModel>().Navigate();
    }
  }
}
