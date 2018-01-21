using System;
using Windows.UI.Xaml.Data;

namespace iVM.UWP.App.Resources.Converters
{
  public class DecimalToStringConverter : IValueConverter
  {

    /// <summary> 
    /// Convert bool or Nullable<bool> to Visibility
    /// </summary> 
    /// <param name="value">bool or Nullable<bool>
    /// <param name="targetType">Visibility
    /// <param name="parameter">null
    /// <param name="culture">null 
    /// <returns>Visible or Collapsed</returns>
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      var strValue = String.Empty;
      if (value is decimal)
      {
        if ((decimal)value == Decimal.Zero) return strValue;
        strValue = ((decimal)value).ToString("N2");
      }
      return strValue;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      decimal decimalValue = Decimal.Zero;
      if(value is string && !String.IsNullOrWhiteSpace((string)value))
      {
        decimalValue = Decimal.Parse((string)value);
      }
      return decimalValue;
    }
  }
}
