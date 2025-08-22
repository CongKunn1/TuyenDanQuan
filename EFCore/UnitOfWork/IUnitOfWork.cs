using EFCoreCommon.Model;
using EFCoreCommon.Repository.Interface;

namespace EFCoreCommon.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Citizen> Citizens { get; }
        IRepository<Unit> Units { get; }
        IRepository<DisciplineApproval> DisciplineApproval { get; }
        IRepository<DisciplineProposal> DisciplineProposal { get; }
        IRepository<RewardApproval> RewardApproval { get; }
        IRepository<RewardProposal> RewardProposal { get; }
        IRepository<Mission> Mission { get; }
        Task<int> SaveChangesAsync();
    }
}
