using EFCoreCommon.Model;
using EFCoreCommon.Repository;
using EFCoreCommon.Repository.Interface;
using EFCoreCommon.UnitOfWork;
using TuyenDanQuan.Data;

namespace EFCoreCommonCommon.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Citizen> Citizens { get; }
        public IRepository<Unit> Units { get; }
        public IRepository<DisciplineApproval> DisciplineApproval { get; }
        public IRepository<DisciplineProposal> DisciplineProposal { get; }
        public IRepository<RewardApproval> RewardApproval { get; }
        public IRepository<RewardProposal> RewardProposal { get; }
        public IRepository<Mission> Mission { get; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Citizens = new Repository<Citizen>(_context);
            Units = new Repository<Unit>(_context);
            DisciplineApproval = new Repository<DisciplineApproval>(_context);
            DisciplineProposal = new Repository<DisciplineProposal>(_context);
            RewardApproval = new Repository<RewardApproval>(_context);
            RewardProposal = new Repository<RewardProposal>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
