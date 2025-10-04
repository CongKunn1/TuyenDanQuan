using AutoMapper;
using EFCoreCommon.Model;
using EFCoreCommon.Repository.Interface;
using EFCoreCommon.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TuyenDanQuan.Models;

namespace TuyenDanQuan.Service
{
    public class IMissionService : ICitizenService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Citizen> _citizenRepository;

        public IMissionService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Citizen> citizenRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Create
        public async Task<CitizenDto> CreateAsync(CreateCitizenDto dto)
        {
            var citizen = new Citizen
            {
                FullName = dto.FullName,
                IdentificationNumber = dto.IdentificationNumber,
                Sex = dto.Sex,
                PhoneNumber = dto.PhoneNumber,
                EmailAddress = dto.EmailAddress,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address

            };
             await _unitOfWork.Citizens.AddAsync(citizen);
            await _unitOfWork.SaveChangesAsync();
            var citizenDto = new CitizenDto
            {
                FullName = dto.FullName,
                IdentificationNumber = dto.IdentificationNumber,
                Sex = dto.Sex,
                PhoneNumber = dto.PhoneNumber,
                EmailAddress = dto.EmailAddress,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,

            };
            return citizenDto;
            
        }

        // Get all
        public async Task<IEnumerable<CitizenDto>> GetAllAsync()
        {
            var citizens = await _unitOfWork.Citizens.GetAllAsync();
            var citizenDtos = citizens.Select(c => new CitizenDto
            {
                FullName = c.FullName,
                IdentificationNumber = c.IdentificationNumber,
                Sex = c.Sex,
                PhoneNumber = c.PhoneNumber,
                EmailAddress = c.EmailAddress,
                DateOfBirth = c.DateOfBirth,
                Address = c.Address
            });
            return citizenDtos;
        }

        // Get by id
        public async Task<CitizenDto> GetByIdAsync(int id)
        {
            var citizen = await _unitOfWork.Citizens.GetByIdAsync(id);
            if (citizen == null) return null;
            var citizenDto = new CitizenDto
            {
                Id = citizen.Id,
                FullName = citizen.FullName,
                IdentificationNumber = citizen.IdentificationNumber,
                Sex = citizen.Sex,
                PhoneNumber = citizen.PhoneNumber,
                EmailAddress = citizen.EmailAddress,
                DateOfBirth = citizen.DateOfBirth,
                Address = citizen.Address
            };
            return citizenDto;
        }

        // Update
        public async Task<CitizenDto> UpdateAsync(int id, CreateCitizenDto dto)
        {
            var citizen = await _unitOfWork.Citizens.GetByIdAsync(id);
            if (citizen == null) return null;
            citizen.FullName = dto.FullName;
            citizen.IdentificationNumber = dto.IdentificationNumber;
            citizen.Sex = dto.Sex;
            citizen.PhoneNumber = dto.PhoneNumber;
            citizen.EmailAddress = dto.EmailAddress;
            citizen.DateOfBirth = dto.DateOfBirth;
            citizen.Address = dto.Address;
            var citizenDto = new CitizenDto
            {
                Id = citizen.Id,
                FullName = citizen.FullName,
                IdentificationNumber = dto.IdentificationNumber,
                Sex = dto.Sex,
                PhoneNumber = dto.PhoneNumber,
                EmailAddress = dto.EmailAddress,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address
            };

            _unitOfWork.Citizens.Update(citizen);
            await _unitOfWork.SaveChangesAsync();

            return citizenDto;
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
            var totalItems = query.CountAsync();

            // paging
            var citizens = query
                .Skip((filter.PageNumber - 1) * filter.PageSize) 
                .Take(filter.PageSize)
                .ToListAsync();

            // mapping
            var citizenDtos = _mapper.Map<IEnumerable<CitizenDto>>(citizens);

            return new PagedResult<CitizenDto>
            {
                Items = citizenDtos,
                TotalItems = await totalItems,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }
        public async Task CreateBulkAsync(List<CreateCitizenDto> dtos)
        {
            try
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

                await _unitOfWork.Citizens.AddRangeAsync(citizens);
                await _unitOfWork.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Error occurred while creating citizens in bulk.", ex);
            }
        }

       
    }
}
        

    

