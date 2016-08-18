using Windows.ApplicationModel;

namespace iVM.UWP.App.Messages
{
  public class SuspendStateMessage
  {
    public SuspendStateMessage(SuspendingOperation operation)
    {
      Operation = operation;
    }

    public SuspendingOperation Operation { get; }
  }
}
