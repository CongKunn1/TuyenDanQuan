using AutoMapper;
using EFCoreCommon.Model;
using EFCoreCommon.UnitOfWork;
using TuyenDanQuan.Models;

namespace TuyenDanQuan.Service
{
    public class CitizenService : ICitizenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CitizenService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Create
        public async Task<CitizenDto> CreateAsync(CreateCitizenDto dto)
        {
            var citizen = _mapper.Map<Citizen>(dto);

            await _unitOfWork.Citizens.AddAsync(citizen);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CitizenDto>(citizen);
        }

        // Get all
        public async Task<IEnumerable<CitizenDto>> GetAllAsync()
        {
            var citizens = await _unitOfWork.Citizens.GetAllAsync();
            return _mapper.Map<IEnumerable<CitizenDto>>(citizens);
        }

        // Get by id
        public async Task<CitizenDto> GetByIdAsync(int id)
        {
            var citizen = await _unitOfWork.Citizens.GetByIdAsync(id);
            return citizen == null ? null : _mapper.Map<CitizenDto>(citizen);
        }

        // Update
        public async Task<CitizenDto> UpdateAsync(int id, CreateCitizenDto dto)
        {
            var citizen = await _unitOfWork.Citizens.GetByIdAsync(id);
            if (citizen == null) return null;

            _mapper.Map(dto, citizen);
            _unitOfWork.Citizens.Update(citizen);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CitizenDto>(citizen);
        }

        // Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var citizen = await _unitOfWork.Citizens.GetByIdAsync(id);
            if (citizen == null) return false;

            _unitOfWork.Citizens.Remove(citizen);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
