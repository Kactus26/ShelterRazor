using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.DTO;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;

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
        [BindProperty(SupportsGet = true)]
        public string Search {  get; set; }


        public ICollection<PetDTO> Pets { get; set; }

        public async Task OnGetAsync(string? filter = null)
        {
            switch (filter)
            {
                case "all":
                    Pets = await _petRepository.GetAllPets();
                    break;
                case "withoutowners":
                    Pets = _mapper.Map<ICollection<PetDTO>>(await _petRepository.GetPetsWithoutOwner());
                    break;
                default:
                    if (Search != null)
                    {
                        Pets = _mapper.Map<ICollection<PetDTO>>(await _petRepository.GetPetsWithBreed(Search));
                        break;
                    }
                    if (filter != null)
                    {
                        PetShelter petShelter = await _petRepository.GetShelter(filter);
                        Pets = _mapper.Map<ICollection<PetDTO>>(petShelter.Pets);
                        break;
                    }
                    Pets = await _petRepository.GetAllPets();
                    break;
            }
        }
    }
}
