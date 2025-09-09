using TuyenDanQuan.Models;

namespace TuyenDanQuan.Service
{
    public interface IUnitService
    {
        Task<UnitDto> CreateAsync(CreateUnitDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<UnitDto>> GetAllAsync();
        Task<UnitDto> GetByIdAsync(int id);
        Task<UnitDto> UpdateAsync(int id, CreateUnitDto dto);
        Task<IEnumerable<CitizenDto>> AddExistingCitizensAsync(int unitId, List<int> citizenIds);

    }
}