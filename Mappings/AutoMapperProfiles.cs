using APITraining.Models;
using APITraining.Models.Dto;
using AutoMapper;

namespace APITraining.Mappings
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles() 
        {
            CreateMap<PlaceDto, Place>().ReverseMap();
            CreateMap<PlaceCreateDto, Place>().ReverseMap();
            //CreateMap<UserDTO, UserDomainModel>().ForMember(x => x.FullName, option => option.MapFrom(x=> x.DisplayName))
            //    .ReverseMap();
        }

    }
}
