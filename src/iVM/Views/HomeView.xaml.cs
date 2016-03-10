using Windows.UI.Xaml.Controls;

namespace iVM.Views
{
  /// <summary>
  ///     An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class HomeView : Page
  {
    public HomeView()
    {
      this.InitializeComponent();
    }

    private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      mainMenu.IsPaneOpen = !mainMenu.IsPaneOpen;
    }
  }
}