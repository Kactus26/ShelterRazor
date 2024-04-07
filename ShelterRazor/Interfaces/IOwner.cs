using ShelterRazor.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ShelterRazor.Interfaces
{
    public interface IOwner
    {
        Task SaveChanges();
        Task<ICollection<Owner>> GetOwners();
        Task<Owner> GetOwnerByNameAndSurname(string ownerName, string ownerSurName);
        Task<EntityEntry<Owner>> DeleteOwner(int ownerId);
        Task<Pet> GetPet(int petId);
        ValueTask<EntityEntry<Owner>> AddOwner(Owner owner);
    }
}
