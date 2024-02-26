using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;

namespace ShelterRazor.Pages
{
    public class SheltersModel : PageModel
    {
        private readonly IPetShelter _shelterRepository;

        public SheltersModel(IPetShelter shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        public ICollection<PetShelter> petShelters { get; set; }

        public async Task OnGetAsync()
        {
            petShelters = await _shelterRepository.PetShelters();
        }
    }
}
