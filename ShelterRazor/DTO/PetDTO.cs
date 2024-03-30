using ShelterRazor.Data;
using ShelterRazor.Models;
using ShelterRazor.Models.Enums;

namespace ShelterRazor.DTO
{
    public class PetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public KindsOfAnimal KindOfAnimal { get; set; }
        public string Breed { get; set; }
        public DateOnly? DateOfTaking { get; set; }
        public int? OwnerId { get; set; }
        public string? OwnerName { get; set; }
        public string? OwnerSurName { get; set; }
        public string? OwnerAddress { get; set; }
        public int PetShelterId { get; set; }
        public string PetShelterAddress { get; set; }
        public string ImgSrc { get; set; }
    }

    public class PetWithOwnerDTO
    {
        public int Id { get; set; }
        public Owner Owner { get; set; }
    }

    public class PetWhithPetShelterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string KindOfAnimal { get; set; }
        public string Breed { get; set; }
        public PetShelterDTO? PetShelter { get; set; }
    }

    public class PetWhithOwnerAndShelterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string KindOfAnimal { get; set; }
        public string Breed { get; set; }
        public DateOnly? DateOfTaking { get; set; }
        public Owner? Owner { get; set; }
        public PetShelterDTO? PetShelter { get; set; }
    }
}
