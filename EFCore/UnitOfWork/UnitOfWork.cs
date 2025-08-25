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
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Citizens = new Repository<Citizen>(_context);
            Units = new Repository<Unit>(_context);
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
