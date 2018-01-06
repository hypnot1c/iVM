//using Caliburn.Micro;
//using iVM.Core.Entity.Entities;
//using iVM.Core.Entity.Services;
//using iVM.Core.UI.ViewModels;
//using System;

//namespace iVM.UWP.App.ViewModels
//{
//  public class MaintenanceAddViewModel : MaintenanceAddViewModelBase
//  {
//    protected INavigationService _navigationService;

//    private DateTimeOffset _dateOffset;
//    public DateTimeOffset DateOffset
//    {
//      get { return this._dateOffset; }
//      set
//      {
//        this._dateOffset = value;
//        this.Date = DateOffset.DateTime;
//      }
//    }

//    public MaintenanceAddViewModel(
//      IEventAggregator eventAggregator, 
//      INavigationService navigationService,
//      EventService eventService,
//      SessionService sessionService
//      ): base(eventAggregator, eventService, sessionService)
//    {
//      this._navigationService = navigationService;
//      this.DateOffset = DateTimeOffset.Now;
//    }

//    public void AddWorkItem(string workDesc, string partCost, string workCost)
//    {
//      this.WorkItems.Add(new MaintenanceItemEntity
//      {
//        Title = workDesc,
//        PartCost = Decimal.Parse(partCost),
//        WorkCost = Decimal.Parse(workCost)
//      });
//    }

//    protected override void Save()
//    {
//      base.Save();
//      this._navigationService.For<EventListViewModel>().Navigate();
//    }
//  }
//}
