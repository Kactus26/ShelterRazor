using AutoMapper;
using ShelterRazor.DTO;
using ShelterRazor.Models;

namespace ShelterRazor.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PetDTO, Pet>().ReverseMap();
            CreateMap<PetWithOwnerDTO, Pet>().ReverseMap();
        }
    }
}
