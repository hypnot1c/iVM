using Caliburn.Micro;
using iVM.Core;
using iVM.Core.UI.ViewModels;
using iVM.Model;

namespace iVM.UWP.App.ViewModels
{
  public class EventTypeSelectViewModel : EventTypeSelectViewModelBase
  {
    private readonly INavigationService _navService;
    private readonly IEventManager _evManager;

    private EventType _selectedEventTypes;
    public EventType SelectedEventTypes
    {
      get { return this._selectedEventTypes; }
      set
      {
        this._selectedEventTypes = value;
        this.NotifyOfPropertyChange(() => this.SelectedEventTypes);
      }
    }

    public EventTypeSelectViewModel(
      IEventAggregator eventAggregator,
      INavigationService navigationService,
      IEventManager eventManager) : base(eventAggregator)
    {
      this._navService = navigationService;
      this._evManager = eventManager;
      this.EventTypes = new BindableCollection<EventType>(this._evManager.EventTypes);
    }

    protected override void viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      switch (e.PropertyName)
      {
        case "SelectedEventTypes":
          switch (this.SelectedEventTypes.Name.ToLower())
          {
            case "fillup":
              this._navService.For<FillUpAddViewModel>().Navigate();
              break;
          }
          break;
      }
    }
  }
}
