using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShelterRazor.DTO;
using ShelterRazor.Models;

namespace ShelterRazor.Interfaces
{
    public interface IPetShelter
    {
        Task<ICollection<PetShelter>> PetShelters();
        Task<PetShelter> GetShelterById(int shelterId);
        Task<ICollection<PetDTO>> PetsInShelter(int shelterId);
        Task<ICollection<Product>> ProductsInShelter(int shelterId);
        Task<EntityEntry<PetShelter>> DeleteShelter(int shelterId);
        ValueTask<EntityEntry<Pet>> AddPet(Pet pet);
        ValueTask<EntityEntry<PetShelter>> AddPetShelter(PetShelter pet);
        Task<Pet> GetPetById(int petId);
        Task<bool> ShelterExists(int shelterId);
        Task SaveChanges();
    }
}
