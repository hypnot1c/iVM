// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace iVM.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class ShellView
  {
    public ShellView()
    {
      this.InitializeComponent();
    }

    private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      mainMenu.IsPaneOpen = !mainMenu.IsPaneOpen;
    }
  }
}
