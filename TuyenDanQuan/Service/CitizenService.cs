using EFCoreCommon.Model;
using EFCoreCommon.UnitOfWork;

namespace TuyenDanQuan.Service
{
    public class CitizenService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CitizenService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }

}
