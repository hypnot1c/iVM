using System;
using Windows.UI.Xaml.Controls;

namespace iVM.UWP.App.ViewModels
{
  public class NavMenuItem
  {
    public Symbol Icon { get; set; }
    public char IconAsChar => (char)Icon;

    public Type TargetViewModel { get; set; }
    public string Title { get; set; }
  }
}
