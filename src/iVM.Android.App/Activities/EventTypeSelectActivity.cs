using Android.App;
using Android.OS;
using Android.Widget;
using iVM.Core.UI.ViewModels;
using System.Linq;

namespace iVM.Android.App.Activities
{
  [Activity(Label = "Event type select", Icon = "@drawable/icon")]
  public class EventTypeSelectActivity: BaseActivity<EventTypeSelectViewModelBase>
  {
    protected override void OnCreate(Bundle bundle)
    {
      base.OnCreate(bundle);

      SetContentView(Resource.Layout.EventTypeSelectView);

      var lst = FindViewById<ListView>(Resource.Id.eventTypes);

      var rep = new SQLdataRepository.SQLdataRepository(this);
      var et = rep.EventTypes.ToList();
      //var eventTypes = 
      //var userName = FindViewById<EditText>(Resource.Id.userName);
      //var password = FindViewById<EditText>(Resource.Id.password);

      //var button = FindViewById<Button>(Resource.Id.signIn);

      //var feedback = FindViewById<TextView>(Resource.Id.feedback);

      //button.Click += (s, e) => ViewModel.Login();

      //EventHandler<TextChangedEventArgs> toggleSignIn = (s, e) =>
      //{
      //  ViewModel.Username = userName.Text;
      //  ViewModel.Password = password.Text;

      //  button.Enabled = ViewModel.CanLogin;
      //};

      //userName.TextChanged += toggleSignIn;
      //password.TextChanged += toggleSignIn;

      //ViewModel.OnChanged(v => v.Feedback, () => feedback.Text = ViewModel.Feedback);
    }
  }
}