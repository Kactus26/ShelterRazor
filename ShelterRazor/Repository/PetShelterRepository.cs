using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShelterRazor.Data;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;

namespace ShelterRazor.Repository
{
    public class PetShelterRepository : IPetShelter
    {
        private readonly DataContext _context;
        public PetShelterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<PetShelter>> PetShelters()
        {
            return await _context.PetShelters.ToListAsync();
        }

        public async Task<PetShelter> GetShelterByAddress(string shelterAddress)
        {
            return await _context.PetShelters.FirstOrDefaultAsync(x=>x.Address==shelterAddress);
        }
    }
}
