using Microsoft.AspNetCore.Mvc;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;
using ShelterRazor.Models.Enums;

namespace ShelterRazor.ViewComponents
{
    public class KindsCountViewComponent : ViewComponent
    {
        private readonly IPet _petRepository;

        public KindsCountViewComponent(IPet petRepository)
        {
            _petRepository = petRepository;
        }

        public IViewComponentResult Invoke(KindsOfAnimal? kind = null)
        {
            ICollection<KindsCount> result = new List<KindsCount>();

            if (kind == null)
                result = _petRepository.GetPetKindsCount();
            else
                result.Add(_petRepository.GetPetKindsCount(kind.Value));

            return View(result);
        }
    }
}
