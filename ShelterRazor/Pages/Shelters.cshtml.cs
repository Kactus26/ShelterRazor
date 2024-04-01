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

        [BindProperty]
        public ICollection<PetShelter> PetShelters { get; set; }

        public async Task OnGetAsync()
        {
            PetShelters = await _shelterRepository.PetShelters();
        }
    }
}
