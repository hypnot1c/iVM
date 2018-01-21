using System;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace iVM.UWP.App.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class FillUpAddView : Page
  {
    public FillUpAddView()
    {
      this.InitializeComponent();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      var showLitreCost = !String.IsNullOrWhiteSpace(this.Expense.Text) && !String.IsNullOrWhiteSpace(this.Litres.Text);
      this.LiterCostText.Visibility = showLitreCost ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
    }
  }
}
