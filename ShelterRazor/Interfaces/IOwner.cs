﻿using ShelterRazor.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ShelterRazor.Interfaces
{
    public interface IOwner
    {
        Task SaveChanges();
        Task<Pet> GetPetById(int petId);
        Task<ICollection<Owner>> GetOwners();
        Task<bool> PetHasOwner(int petId);
        Task<Owner> GetOwnerById(int ownerId);
        Task<EntityEntry<Owner>> DeleteOwner(int ownerId);
        Task<Pet> GetPet(int petId);
        ValueTask<EntityEntry<Owner>> AddOwner(Owner owner);
    }
}
