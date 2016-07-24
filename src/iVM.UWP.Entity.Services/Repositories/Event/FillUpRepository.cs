using iVM.Core.Entity;
using iVM.Core.Entity.Services;
using iVM.Data.EF;
using iVM.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace iVM.UWP.Entity.Services
{
  public class FillUpRepository : IFillUpRepository
  {
    private readonly MainContext mainContext;

    public FillUpRepository(MainContext mainContext)
    {
      this.mainContext = mainContext;
    }
    public void Add(FillUpEntity entity)
    {
      var evOccur = new EventOccured
      {
        Date = entity.OccuredDate,
        Expense = entity.Expense,
        Mileage = entity.Mileage
      };
      var fillUp = new FillUpModel
      {
        LiterCost = entity.LiterCost,
        LitresValue = entity.Litres
      };
      evOccur.FillUps.Add(fillUp);
      this.mainContext.EventsOccured.Add(evOccur);
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<FillUpEntity> Find(Expression<Func<FillUpEntity, bool>> predicate)
    {
      throw new NotImplementedException();
    }

    public FillUpEntity Get(int id)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<FillUpEntity> GetAll()
    {
      throw new NotImplementedException();
    }

    public void Remove(int Id)
    {
      throw new NotImplementedException();
    }
  }
}
