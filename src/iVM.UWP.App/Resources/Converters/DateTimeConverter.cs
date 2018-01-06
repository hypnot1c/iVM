using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace iVM.UWP.App.Resources.Converters
{
  public class DateTimeConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      var date = value as DateTimeOffset?;
      var formatString = parameter as string;
      if(String.IsNullOrWhiteSpace(formatString))
      {
        formatString = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
      }

      return date.Value.ToString(formatString);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      var dateString = value as string;
      var formatString = parameter as string;
      if (String.IsNullOrWhiteSpace(formatString))
      {
        formatString = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
      }
      if (!String.IsNullOrWhiteSpace(dateString))
      {
        var date = DateTimeOffset.ParseExact(dateString, formatString, CultureInfo.CurrentCulture);
        return date;
      }
      throw new ArgumentException("Input string not recognized as DateTime", "value");
    }
  }
}
