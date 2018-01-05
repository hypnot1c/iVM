using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;
using System.Linq;

namespace iVM.UWP.Entity.Services
{
  public class EventOccuredRepository : EFRepository<EventOccuredModel>, IEventOccuredRepository
  {
    public MainContext MainContext { get { return this.context as MainContext; } }

    public EventOccuredRepository(MainContext mainContext) : base(mainContext)
    {
    }

    public override EventOccuredModel Get(int Id)
    {
      return this.MainContext.EventsOccured.SingleOrDefault(e => e.Id == Id);
    }
  }
}
