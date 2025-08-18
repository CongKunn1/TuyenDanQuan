using AutoMapper;
using EFCoreCommon.Model;
using TuyenDanQuan.Models;

namespace TuyenDanQuan.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUnitDto, Unit>();
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateCitizenDto, Citizen>().ReverseMap(); ;
            CreateMap<Citizen, CitizenDto>().ReverseMap();
        }
    }
}
