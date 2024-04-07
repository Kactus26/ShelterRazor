using Microsoft.EntityFrameworkCore.ChangeTracking;
using ShelterRazor.DTO;
using ShelterRazor.Models;

namespace ShelterRazor.Interfaces
{
    public interface IPetShelter
    {
        Task<ICollection<PetShelter>> PetShelters();
        Task<PetShelter> GetShelterByAddress(string shelterAddress);
    }
}
