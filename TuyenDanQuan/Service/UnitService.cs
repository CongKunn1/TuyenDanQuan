using AutoMapper;
using EFCoreCommon.Model;
using EFCoreCommon.UnitOfWork;
using TuyenDanQuan.Models;

namespace TuyenDanQuan.Service
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UnitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Create
        public async Task<UnitDto> CreateAsync(CreateUnitDto dto)
        {
            var unit = _mapper.Map<Unit>(dto);

            await _unitOfWork.Units.AddAsync(unit);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UnitDto>(unit);
        }

        // Get all
        public async Task<IEnumerable<UnitDto>> GetAllAsync()
        {
            var units = await _unitOfWork.Units.GetAllAsync();
            return _mapper.Map<IEnumerable<UnitDto>>(units);
        }

        // Get by id
        public async Task<UnitDto> GetByIdAsync(int id)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(id);
            return unit == null ? null : _mapper.Map<UnitDto>(unit);
        }

        // Update
        public async Task<UnitDto> UpdateAsync(int id, CreateUnitDto dto)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(id);
            if (unit == null) return null;

            _mapper.Map(dto, unit);

            _unitOfWork.Units.Update(unit);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UnitDto>(unit);
        }

        // Delete
        public async Task<bool> DeleteAsync(int id)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(id);
            if (unit == null) return false;

            _unitOfWork.Units.Remove(unit);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CitizenDto>> AddExistingCitizensAsync(int unitId, List<int> citizenIds)
        {
            var unit = await _unitOfWork.Units.GetByIdAsync(unitId);
            if (unit == null) return null;

            var allCitizens = await _unitOfWork.Citizens.GetAllAsync();
            var citizens = allCitizens
                .Where(c => citizenIds.Contains(c.Id))
                .ToList();

            if (!citizens.Any()) return new List<CitizenDto>();

            foreach (var citizen in citizens)
            {
                citizen.UnitId = unitId;
            }

            await _unitOfWork.SaveChangesAsync();

            return citizens.Select(c => new CitizenDto
            {
                Id = c.Id,
                FullName = c.FullName,
                IdentificationNumber = c.IdentificationNumber,
                Sex = c.Sex,
                PhoneNumber = c.PhoneNumber,
                EmailAddress = c.EmailAddress,
                DateOfBirth = c.DateOfBirth,
                Address = c.Address,
                UnitId = c.UnitId
            }).ToList();
        }

    }
}
