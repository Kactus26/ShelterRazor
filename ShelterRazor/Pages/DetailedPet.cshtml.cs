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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DetailedPetModel(IPet petRepository, IMapper mapper, IOwner ownerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _petRepository = petRepository;
            _ownertRepository = ownerRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public PetDTO Pet {  get; set; }
        public SelectList Kinds { get; set; }
        public SelectList Breeds { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Kinds = new SelectList(Enum.GetValues(typeof(KindsOfAnimal)).Cast<KindsOfAnimal>().ToList());
            Breeds = new SelectList(Enum.GetValues(typeof(Breeds)).Cast<Breeds>().ToList());

            Pet = _mapper.Map<PetDTO>(await _petRepository.GetPetById(id));
            if (Pet == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(Photo != null)
                Pet.ImgSrc = UploadImage();

            Pet updatePet = _mapper.Map<Pet>(Pet);
            await _petRepository.UpdatePet(updatePet);

            if(Pet.OwnerId != null)
            {
                Owner owner = await _ownertRepository.GetOwnerById(Pet.OwnerId.Value);
                owner.Name = Pet.OwnerName;
                owner.Address = Pet.OwnerAddress;
            }

            await _petRepository.SaveChanges();
            return RedirectToPage("/Pets");
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
