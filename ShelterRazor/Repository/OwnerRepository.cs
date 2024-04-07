using Microsoft.EntityFrameworkCore;
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

        public ValueTask<EntityEntry<Owner>> AddOwner(Owner owner)
        {
            return _context.Owners.AddAsync(owner);
        }
        
        public async Task<ICollection<Owner>> GetOwners()
        {
            return await _context.Owners.Include(x=>x.Pets).ToListAsync();
        }

        public async Task<Pet> GetPet(int petId)
        {
            return await _context.Pets.Include(x=>x.Owner).Where(x => x.Id == petId).FirstOrDefaultAsync();
        }

        public async Task<EntityEntry<Owner>> DeleteOwner(int ownerId)
        {
            Owner entitiyToDelete = await _context.Owners.FirstOrDefaultAsync(x => x.Id == ownerId);
            List<Pet> connectedEntities = await _context.Pets.Where(x => x.Owner.Id == ownerId).ToListAsync();
            foreach (var entity in connectedEntities)
            {
                entity.Owner = null;
            }

            return _context.Owners.Remove(entitiyToDelete);
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<Owner> GetOwnerByNameAndSurname(string ownerName, string ownerSurName)
        {
            return await _context.Owners.FirstOrDefaultAsync(x => x.Name == ownerName && x.SurName == ownerSurName);
        }
    }
}
