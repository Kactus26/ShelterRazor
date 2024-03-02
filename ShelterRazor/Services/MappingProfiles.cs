using AutoMapper;
using ShelterRazor.DTO;
using ShelterRazor.Models;

namespace ShelterRazor.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
/*            CreateMap<PetShelter, PetShelterDTO>();
*/            CreateMap<Pet, PetDTO>();
            /*CreateMap<Product, ProductsDTO>();
            CreateMap<Pet, PetWhithPetShelterDTO>(); 
            CreateMap<Pet, PetWhithOwnerAndShelterDTO>();*/
        }
    }
}
