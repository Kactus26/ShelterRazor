﻿using ShelterRazor.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShelterRazor.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public KindsOfAnimal KindOfAnimal { get; set; }
        public Breeds Breed { get; set; }
        public string ImgSrc { get ; set; }
        public DateOnly? DateOfTaking { get; set; }
        public Owner? Owner { get; set; }
        public PetShelter? PetShelter { get; set; }
    }

}
