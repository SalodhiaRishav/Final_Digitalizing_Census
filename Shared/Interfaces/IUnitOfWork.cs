using System.Data.Entity;

namespace Shared.Interfaces
{
    public interface IUnitOfWork
    {
        DbContext DbContext { get; }
        bool Commit();
    }
}
