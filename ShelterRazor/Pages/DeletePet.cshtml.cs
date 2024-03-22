using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.DTO;
using ShelterRazor.Interfaces;

namespace ShelterRazor.Pages
{
    public class DeletePetModel : PageModel
    {
        private readonly IPet _petRepository;
        private readonly IMapper _mapper;
        public DeletePetModel(IMapper mapper, IPet petRepository)
        {
            _mapper = mapper;
            _petRepository = petRepository;
        }

        [BindProperty]
        public PetDTO Pet { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {

            Pet = _mapper.Map<PetDTO>(await _petRepository.GetPetById(id));
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _petRepository.DeletePet(Pet.Id);
            await _petRepository.SaveChanges();

            TempData["Success"] = "Pet was deleted successfully";
            return RedirectToPage("/Index");
        }
    }
}
