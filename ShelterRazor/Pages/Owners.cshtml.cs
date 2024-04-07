using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;

namespace ShelterRazor.Pages
{
    public class OwnersModel : PageModel
    {
        private readonly IOwner _ownerRepository;

        public OwnersModel(IOwner ownerRepos)
        {
            _ownerRepository = ownerRepos;
        }

        [BindProperty]
        public ICollection<Owner> Owners { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id = 0)
        {
            if (id != 0)
            {
                await _ownerRepository.DeleteOwner(id.Value);
                await _ownerRepository.SaveChanges();
                return RedirectToPage("/Owners");
            }

            Owners = await _ownerRepository.GetOwners();
            return Page();
        }
    }
}
