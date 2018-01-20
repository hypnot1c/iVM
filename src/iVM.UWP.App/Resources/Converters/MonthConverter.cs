using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace iVM.UWP.App.Resources.Converters
{
  public class MonthConverter : IValueConverter
  {

    public MonthConverter()
    {
      this.monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
    }
    private readonly string[] monthNames;

    public object Convert(object value, Type targetType, object parameter, string language)
    {
      var monthNumber = value as int?;

      return this.monthNames[monthNumber.Value - 1];
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      var monthString = value as string;

      return Array.IndexOf(this.monthNames, monthString) + 1;
    }
  }
}
