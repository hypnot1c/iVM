using Windows.System.Profile;
using Windows.UI.ViewManagement;

namespace iVM.UWP.App.Helpers
{
  public class UserDeviceHelper
  {
    public static DeviceFormFactorType DeviceFormFactorType
    {
      get
      {
        switch (AnalyticsInfo.VersionInfo.DeviceFamily)
        {
          case "Windows.Mobile":
            return DeviceFormFactorType.Phone;
          case "Windows.Desktop":
            return UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse
                ? DeviceFormFactorType.Desktop
                : DeviceFormFactorType.Tablet;
          case "Windows.Universal":
            return DeviceFormFactorType.IoT;
          case "Windows.Team":
            return DeviceFormFactorType.SurfaceHub;
          default:
            return DeviceFormFactorType.Other;
        }
      }
    }
  }

  public enum DeviceFormFactorType
  {
    Phone,
    Desktop,
    Tablet,
    IoT,
    SurfaceHub,
    Other
  }
}
