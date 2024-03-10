﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShelterRazor.Data;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;

namespace ShelterRazor.Repository
{
    public class OwnerRepository : IOwner
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Pet> GetPetById(int petId)
        {
            return await _context.Pets.FirstOrDefaultAsync(x=>x.Id==petId);
        }

        public ValueTask<EntityEntry<Owner>> AddOwner(Owner owner)
        {
            return _context.Owners.AddAsync(owner);
        }
        
        public async Task<ICollection<Owner>> GetOwners()
        {
            return await _context.Owners.Include(x=>x.Pets).ToListAsync();
        }

        public async Task<bool> PetHasOwner(int petId)
        {
            Pet pet = await _context.Pets.Include(x=>x.Owner).FirstOrDefaultAsync(x => x.Id == petId);
            if (pet.Owner != null)
                return true;
            else
                return false;
        }
        public async Task<Owner> GetOwnerById(int ownerId)
        {
            return await _context.Owners.Include(x=>x.Pets).Where(x => x.Id == ownerId).FirstOrDefaultAsync();
        }

        public async Task<Pet> GetPet(int petId)
        {
            return await _context.Pets.Include(x=>x.Owner).Where(x => x.Id == petId).FirstOrDefaultAsync();
        }

/*        public async Task UpdateOwner(Owner updatedOwner)
        {
            _context.Entry(await _context.Pets.FirstOrDefaultAsync(x => x.Id == updatedOwner.Id)).CurrentValues.SetValues(updatedOwner);
        }*/

        public async Task<EntityEntry<Owner>> DeleteOwner(int ownerId)
        {
            return _context.Owners.Remove(await _context.Owners.FirstOrDefaultAsync(x => x.Id == ownerId));
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
