using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.DTO;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;
using ShelterRazor.Repository;

namespace ShelterRazor.Pages
{
    public class AddOwnerModel : PageModel
    {
        private readonly IOwner _ownerRepository;
        private readonly IMapper _mapper;
        public AddOwnerModel(IOwner ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        [BindProperty]
        public int PetId { get; set; }
        [BindProperty]
        public Owner Owner { get; set; }


        public void OnGet(int id)
        {
            PetId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(Owner.Name == null || Owner.Name.Length < 2)
            {
                TempData["Error"] = "Name must be 2 or more letters";
                return RedirectToPage("AddOwner");
            }
            if (Owner.SurName == null || Owner.SurName.Length < 2)
            {
                TempData["Error"] = "Surname must be 2 or more letters";
                return RedirectToPage("AddOwner");
            }
            if (Owner.Address == null || Owner.Address.Length < 2)
            {
                TempData["Error"] = "Address must be 2 or more letters";
                return RedirectToPage("AddOwner");
            }

            await _ownerRepository.AddOwner(Owner);
            Pet pet = await _ownerRepository.GetPet(PetId);
            pet.Owner = Owner;
            await _ownerRepository.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
