using ShelterRazor.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShelterRazor.Models
{
    public class Pet
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be null")]
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public KindsOfAnimal KindOfAnimal { get; set; }
        public string Breed { get; set; }
        public string ImgSrc { get ; set; }
        public DateOnly? DateOfTaking { get; set; }
        public Owner? Owner { get; set; }
        public PetShelter? PetShelter { get; set; }
    }

}
