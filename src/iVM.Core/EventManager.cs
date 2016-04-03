﻿using iVM.Data.Model;
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

    public IEnumerable<EventOccured> EventsOccured
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

    public void FillUpAdd(EventOccured _evOccured, FillUp _fillUp)
    {
      this.dataRepository.FillUpAdd(_evOccured, _fillUp);
      this.dataRepository.SaveChanges();
    }

    public void RepairAdd(EventOccured _evOccured, Repair _repair)
    {
      throw new NotImplementedException();
    }
  }
}
