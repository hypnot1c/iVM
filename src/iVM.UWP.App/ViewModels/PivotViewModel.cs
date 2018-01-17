﻿using Caliburn.Micro;
using iVM.Core.UI;

namespace iVM.UWP.App.ViewModels
{
  public class PivotViewModel : BaseConductorViewModel
  {
    public PivotViewModel(
      IEventAggregator eventAggregator,
      EventListViewModel eventListVm
      ) : base(eventAggregator)
    {
      this.Items.Add(eventListVm);
      this.ActivateItem(eventListVm);
    }
  }
}