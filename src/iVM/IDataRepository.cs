﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iVM.Model;

namespace iVM.Data
{
  public interface IDataRepository
  {
    IQueryable<User> Users { get; }
    IQueryable<EventType> EventTypes { get; }

    void Migrate();
  }
}