using iVM.Core.Entity;
using System;
using System.Collections.Generic;

namespace iVM.Core
{
  public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
  {
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void Add(TEntity entity);
    void Remove(int Id);
  }
}
