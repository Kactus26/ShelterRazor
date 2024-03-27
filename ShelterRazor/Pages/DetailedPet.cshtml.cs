using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShelterRazor.DTO;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;
using ShelterRazor.Models.Enums;
using ShelterRazor.Repository;

namespace ShelterRazor.Pages
{
    public class DetailedPetModel : PageModel
    {
        private readonly IPet _petRepository;
        private readonly IOwner _ownertRepository;
        private readonly IMapper _mapper;
        private readonly IPetShelter _shelterRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DetailedPetModel(IPet petRepository, IMapper mapper, IPetShelter shelterRepository,
            IOwner ownerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _petRepository = petRepository;
            _ownertRepository = ownerRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _shelterRepository = shelterRepository;
        }

        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public PetDTO Pet {  get; set; }
        public SelectList Kinds { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Kinds = new SelectList(Enum.GetValues(typeof(KindsOfAnimal)).Cast<KindsOfAnimal>().ToList());

            if (id != 0) 
            { 
                Pet = _mapper.Map<PetDTO>(await _petRepository.GetPetById(id));
                if (Pet == null)
                {
                    return RedirectToPage("/Error");
                }
            }
            else
            {
                Pet = new PetDTO()
                {
                    Gender = 'M'
                };
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (Pet.Name == null) { 
                TempData["Error"] = "Pet name cannot be null";
                return RedirectToPage("/DetailedPet");
            } else if (Pet.Gender != 'M' && Pet.Gender != 'F')
            {
                TempData["Error"] = "Pet gender must be M or F";
                return RedirectToPage("/DetailedPet");
            } else if (Pet.PetShelterAddress == null)
            {
                TempData["Error"] = "Pet shelter address cannot be null";
                return RedirectToPage("/DetailedPet");
            } else if (Pet.Breed == null)
            {
                TempData["Error"] = "Pet breed cannot be null";
                return RedirectToPage("/DetailedPet");
            }
            if (Photo != null)
                Pet.ImgSrc = UploadImage();


            if (Pet.Id == 0)
            {
                Pet pet = _mapper.Map<Pet>(Pet);

                pet.PetShelter = await _shelterRepository.GetShelterByAddress(Pet.PetShelterAddress);
                if (pet.PetShelter == null)
                {
                    TempData["Error"] = "Pet shelter with this address dont't exist";
                    return RedirectToPage("/DetailedPet");
                }

                await _petRepository.AddPet(pet);
                await _petRepository.SaveChanges();
                TempData["Success"] = "Pet was successfully added";

                return RedirectToPage("/Index");
            }
            else
            {
                Pet pet = await _petRepository.GetPetById(Pet.Id);
                pet.PetShelter = await _shelterRepository.GetShelterByAddress(Pet.PetShelterAddress);

                if (pet.PetShelter == null)
                {
                    TempData["Error"] = "Pet shelter with this address dont't exist";
                    return RedirectToPage("/DetailedPet");
                }

                pet.Name = Pet.Name;
                pet.Age = Pet.Age;
                pet.Gender = Pet.Gender;
                pet.Breed = Pet.Breed;
                pet.KindOfAnimal = Pet.KindOfAnimal;
                pet.ImgSrc = Pet.ImgSrc;

                await _petRepository.UpdatePet(pet);
            }

            await _petRepository.SaveChanges();
            TempData["Success"] = "Pet was successfully updated";

            return RedirectToPage("/Index");

            
        }

        private string UploadImage()
        {
            string imgFolderSrc = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
            string filePath = Path.Combine(imgFolderSrc, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(fileStream);
            }
            return "/images/" + uniqueFileName;
        }
    }
}
