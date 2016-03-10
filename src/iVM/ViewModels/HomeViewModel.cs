﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iVM.ViewModels
{
  public class HomeViewModel : BaseViewModel
  {
    private INavigationService _pageNavigationService;

    public HomeViewModel(INavigationService pageNavigationService) : base(pageNavigationService)
    {
      _pageNavigationService = pageNavigationService;
    }

    private string _myMessage;
    public string MyMessage
    {
      get { return _myMessage; }
      set
      {
        _myMessage = value;
        NotifyOfPropertyChange(() => MyMessage);
      }
    }

    private string _title;
    public string Title
    {
      get { return _title; }
      set
      {
        _title = value;
        NotifyOfPropertyChange(() => Title);
      }
    }

    public void SayHello()
    {
      MyMessage = "Hello World!111";
    }
  }
}