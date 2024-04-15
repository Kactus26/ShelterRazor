using Microsoft.EntityFrameworkCore;
using ShelterRazor.Models;

namespace ShelterRazor.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetShelter> PetShelters { get; set; }

    }
}
