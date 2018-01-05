using iVM.Core;
using iVM.UWP.Entity.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace iVM.UWP.Entity.Services
{
  public class EFRepository<TEintity> : IRepository<TEintity> where TEintity : class
  {
    protected readonly DbContext context;

    public EFRepository(DbContext context)
    {
      this.context = context;
    }
    public void Add(TEintity entity)
    {
      this.context.Set<TEintity>().Add(entity);
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<TEintity> Find(Expression<Func<TEintity, bool>> predicate)
    {
      return this.context.Set<TEintity>().Where(predicate).ToList();
    }

    public virtual TEintity Get(int Id)
    {
      return this.context.Set<TEintity>().Find(Id);
    }

    public IEnumerable<TEintity> GetAll()
    {
      return this.context.Set<TEintity>().ToList();
    }

    public void Remove(int Id)
    {
      var entity = this.Get(Id);
      this.context.Set<TEintity>().Remove(entity);
    }
  }
}
