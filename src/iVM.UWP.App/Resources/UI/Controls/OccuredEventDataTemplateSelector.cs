using iVM.Core.Entity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace iVM.UWP.App.Resources.UI.Controls
{
  public class OccuredEventDataTemplateSelector : DataTemplateSelector
  {
    public DataTemplate FillUpDataTemplate { get; set; }
    public DataTemplate MaintenanceDataTemplate { get; set; }

    protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
    {
      if(item is FillUpEntity)
      {
        return FillUpDataTemplate;
      }
      if(item is MaintenanceEntity)
      {
        return MaintenanceDataTemplate;
      }
      return base.SelectTemplateCore(item, container);
    }
  }
}
