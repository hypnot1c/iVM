using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using iVM.Android.App.Activities;

namespace iVM.Android.App
{
  [Activity(Label = "iVM.Android.App", MainLauncher = true, Icon = "@drawable/icon")]
  public class MainActivity : Activity
  {
    //int count = 1;

    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      // Set our view from the "main" layout resource
      SetContentView(Resource.Layout.Main);

      // Get our button from the layout resource,
      // and attach an event to it
      Button button = FindViewById<Button>(Resource.Id.MyButton);

      button.Click += delegate {
        var _int = new Intent(this, typeof(EventTypeSelectActivity));
        this.StartActivity(_int);
        //button.Text = string.Format("{0} clicks!", count++);
      };
    }
  }
}

