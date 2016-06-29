using iVM.Core;
using iVM.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace iVM.UWP.Entity.Services
{
  public class EFRepository<TEntity, TDataEntity> : IRepository<TEntity>
      where TEntity : BaseEntity, new()
  {
    private readonly DbContext _context;
    private DbSet<TEntity> _entities;

    public EFRepository(DbContext context)
    {
      _context = context;
    }

    private DbSet<TEntity> Entities
    {
      get { return _entities ?? (_entities = _context.Set<TEntity>()); }
    }

    public TEntity Get(int id)
    {
      return Entities.FirstOrDefaultAsync(e => e.ID == id).Result;
    }

    public void Add(TEntity entity)
    {
      Entities.Add(entity);
    }

    public void Remove(int id)
    {
      var _entity = this.Entities.FirstOrDefaultAsync(e => e.ID == id).Result;
      if(_entity != null)
      {
        this.Remove(_entity);
      }
    }

    public void Remove(TEntity entity)
    {
      Entities.Remove(entity);
    }

    public IEnumerable<TEntity> GetAll()
    {
      return Entities.ToListAsync().Result;
    }

    public void Dispose()
    {
      this._context.Dispose();
    }
  }
}
