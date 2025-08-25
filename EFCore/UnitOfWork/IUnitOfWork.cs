using EFCoreCommon.Model;
using EFCoreCommon.Repository.Interface;

namespace EFCoreCommon.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Citizen> Citizens { get; }
        IRepository<Unit> Units { get; }
        Task<int> SaveChangesAsync();
    }
}
