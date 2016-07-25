using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;

namespace iVM.UWP.Entity.Services
{
  public class EventOccuredRepository : EFRepository<EventOccured>, IEventOccuredRepository
  {
    public MainContext MainContext { get { return this.context as MainContext; } }

    public EventOccuredRepository(MainContext mainContext) : base(mainContext)
    {
    }
  }
}
