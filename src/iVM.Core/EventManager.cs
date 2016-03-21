using iVM.Model;
using System;
using System.Collections.Generic;

namespace iVM.Core.UWP
{
  public class EventManager : IEventManager
  {
    private readonly IDataRepository dataRepository;

    public EventManager(IDataRepository dataRepository)
    {
      this.dataRepository = dataRepository;
    }

    public IEnumerable<EventType> EventTypes
    {
      get
      {
        return this.dataRepository.EventTypes;
      }

      private set
      {
        throw new NotImplementedException();
      }
    }

    public void EventOccuredAdd(EventOccured ivmEvent)
    {
      this.dataRepository.AddObject<EventOccured>(ivmEvent);
    }
  }
}
