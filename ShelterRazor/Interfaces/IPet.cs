using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShelterRazor.DTO;
using ShelterRazor.Models;
using ShelterRazor.Models.Enums;

namespace ShelterRazor.Interfaces
{
    public interface IPet
    {
        Task<ICollection<Pet>> GetPetsWithoutOwner();
        Task<ICollection<Pet>> GetShelterPetsWithoutOwner(int shelterId);
        Task<ICollection<Pet>> GetPetsWithBreed(string breed);
        Task<Pet> GetPetById(int id);
        ICollection<KindsCount> GetPetKindsCount();
        KindsCount GetPetKindsCount(KindsOfAnimal kind);
        Task<EntityEntry<Pet>> DeletePet(int petId);
        Task UpdatePet(Pet updatedPet);
        ValueTask<EntityEntry<Pet>> AddPet(Pet pet);
        Task<ICollection<PetDTO>> GetAllPets();
        Task SaveChanges();
    }
}
