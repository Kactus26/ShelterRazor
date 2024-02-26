using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;
using ShelterRazor.Repository;

namespace ShelterRazor.Pages
{
    public class PetsModel : PageModel
    {
        private readonly IPet _petRepository;

        public PetsModel(IPet petRepository)
        {
            _petRepository = petRepository;
        }

        public ICollection<Pet> Pets { get; set; }

        public async Task OnGetAsync()
        {
            Pets = await _petRepository.GetPetsWithoutOwner();
        }
    }
}
