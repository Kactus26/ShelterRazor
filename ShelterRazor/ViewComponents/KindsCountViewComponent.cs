using Microsoft.AspNetCore.Mvc;
using ShelterRazor.Interfaces;
using ShelterRazor.Models;

namespace ShelterRazor.ViewComponents
{
    public class KindsCountViewComponent : ViewComponent
    {
        private readonly IPet _petRepository;

        public KindsCountViewComponent(IPet petRepository)
        {
            _petRepository = petRepository;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<KindsCount> result = _petRepository.GetPetKindsCount();

            /*            KindsCount result = new KindsCount { Count = 1, KindsOfAnimal = Models.Enums.KindsOfAnimal.Cat };*/
            return View(result);
        }
    }
}
