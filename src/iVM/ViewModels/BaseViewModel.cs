using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.ViewModels
{
  public class BaseViewModel: Screen
  {
    protected readonly INavigationService PageNavigationService;

    protected BaseViewModel(INavigationService pageNavigationService)
    {
      PageNavigationService = pageNavigationService;
    }

    public bool CanGoBack
    {
      get { return PageNavigationService.CanGoBack; }
    }

    protected void NavigateTo<T>()
    {
      PageNavigationService.Navigate<T>();
    }

    public void GoBack()
    {
      PageNavigationService.GoBack();
    }
  }
}
