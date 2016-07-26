using System;

namespace iVM.Core
{
  public interface IUnitOfWork : IDisposable
  {
    void Commit();
    void Rollback();
  }
}
