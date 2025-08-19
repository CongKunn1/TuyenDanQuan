using AutoMapper;
using EFCoreCommon.Model;
using EFCoreCommon.Repository.Interface;
using EFCoreCommon.UnitOfWork;
using TuyenDanQuan.Models;

namespace TuyenDanQuan.Service
{
    public class CitizenService : ICitizenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Citizen> _citizenRepository;

        public CitizenService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Citizen> citizenRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _citizenRepository = citizenRepository;
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
        public async Task<PagedResult<CitizenDto>> FilterAsync(CitizenFilterDto filter)
        {

            var query = _unitOfWork.Citizens.GetQueryable();

            // filter
            if (!string.IsNullOrEmpty(filter.FullName))
                query = query.Where(c => c.FullName.Contains(filter.FullName));

            if (!string.IsNullOrEmpty(filter.IdentificationNumber))
                query = query.Where(c => c.IdentificationNumber.Contains(filter.IdentificationNumber));
            if (filter.Sex.HasValue)
                query = query.Where(c => c.Sex == filter.Sex.Value);

            if (!string.IsNullOrEmpty(filter.PhoneNumber))
                query = query.Where(c => c.PhoneNumber.Contains(filter.PhoneNumber));

            if (!string.IsNullOrEmpty(filter.EmailAddress))
                query = query.Where(c => c.EmailAddress.Contains(filter.EmailAddress));
            if (filter.DateOfBirth.HasValue)
                query = query.Where(c => c.DateOfBirth == filter.DateOfBirth.Value);
            if (!string.IsNullOrEmpty(filter.Address))
                query = query.Where(c => c.Address.Contains(filter.Address));
            var totalItems = query.Count();

            // paging
            var citizens = query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            // mapping
            var citizenDtos = _mapper.Map<IEnumerable<CitizenDto>>(citizens);

            return new PagedResult<CitizenDto>
            {
                Items = citizenDtos,
                TotalItems = totalItems,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }
        public async Task CreateBulkAsync(List<CreateCitizenDto> dtos)
        {
            var citizens = dtos.Select(dto => new Citizen
            {
                FullName = dto.FullName,
                IdentificationNumber = dto.IdentificationNumber,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                EmailAddress = dto.EmailAddress,
                PhoneNumber = dto.PhoneNumber,
                Sex = dto.Sex
            }).ToList();

            await _citizenRepository.AddRangeAsync(citizens);
            await _unitOfWork.SaveChangesAsync();
        }

       
    }
}
        

    

