using System;

namespace iVM.Core
{
  public interface IUnitOfWork : IDisposable
  {
    void Save();
    void Commit();
    void Rollback();
  }
}
