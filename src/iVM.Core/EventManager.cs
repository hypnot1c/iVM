using iVM.Core.Entity;
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

    public IEnumerable<EventOccuredEntity> EventsOccured
    {
      get
      {
        return this.dataRepository.EventsOccured;
      }

      set
      {
        throw new NotImplementedException();
      }
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

    public void FillUpAdd(FillUpEntity _fillUp)
    {
      //this.dataRepository.FillUpAdd(_evOccured, _fillUp);
      //this.dataRepository.SaveChanges();
    }

    public void RepairAdd(RepairEntity _repair)
    {
      //this.dataRepository.RepairAdd(_evOccured, _repair);
      //this.dataRepository.SaveChanges();
    }
  }
}
