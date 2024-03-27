using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.DTO;
using ShelterRazor.Interfaces;

namespace ShelterRazor.Pages
{
    public class PetsModel : PageModel
    {
        private readonly IPet _petRepository;
        private readonly IMapper _mapper;

        public PetsModel(IPet petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }


        [BindProperty]
        public string Filter { get; set; }

        public ICollection<PetDTO> Pets { get; set; }

        public async Task OnGetAsync(string? filter = null)
        {
            if (Filter == null)
                Pets = await _petRepository.GetAllPets();

            switch (filter)
            {
                case "all":
                    Pets = await _petRepository.GetAllPets();
                    break;
                case "withoutowners":
                    Pets = _mapper.Map<ICollection<PetDTO>>(await _petRepository.GetPetsWithoutOwner());
                    break;
            }

            Filter = filter;
        }
    }
}
