using TuyenDanQuan.Models;
namespace TuyenDanQuan.Service;

public interface ICitizenService
{
    Task<CitizenDto> CreateAsync(CreateCitizenDto dto);
    Task<IEnumerable<CitizenDto>> GetAllAsync();
    Task<CitizenDto> GetByIdAsync(int id);
    Task<CitizenDto> UpdateAsync(int id, CreateCitizenDto dto);
    Task<bool> DeleteAsync(int id);
}
