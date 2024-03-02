using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.DTO;
using ShelterRazor.Interfaces;
using ShelterRazor.Repository;

namespace ShelterRazor.Pages
{
    public class DetailedPetModel : PageModel
    {
        private readonly IPet _petRepository;
        private readonly IMapper _mapper;

        public DetailedPetModel(IPet petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public PetDTO Pet {  get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pet = _mapper.Map<PetDTO>(await _petRepository.GetPetById(id));
            if (Pet == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}
