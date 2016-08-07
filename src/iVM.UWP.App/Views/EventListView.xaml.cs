using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace iVM.UWP.App.Views
{
  /// <summary>
  /// An empty page that can be used on its own or navigated to within a Frame.
  /// </summary>
  public sealed partial class EventListView : Page
  {
    public EventListView()
    {
      this.InitializeComponent();
    }

    private void Events_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
    {
      var gridView = sender as GridView;
      ItemsWrapGrid MyItemsPanel = (ItemsWrapGrid)gridView.ItemsPanelRoot;
      double margin = 10.0;
      int ItemsNumber = gridView.Items.Count;
      var width = (e.NewSize.Width - margin) / (double)ItemsNumber;
      MyItemsPanel.ItemWidth = width < 225 ? 225 : width;
    }
  }
}
