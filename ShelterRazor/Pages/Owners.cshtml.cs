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

        public async Task OnGetAsync()
        {
            Owners = await _ownerRepository.GetOwners();
        }
    }
}
