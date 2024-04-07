using ShelterRazor.Models;
using ShelterRazor.Models.Enums;

namespace ShelterRazor.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            dataContext = context;
        }
        public void SeedDataContext()
        {
            if (dataContext.PetShelters.Any())
            {
                dataContext.RemoveRange(dataContext.Owners);
                dataContext.RemoveRange(dataContext.Pets);
                dataContext.RemoveRange(dataContext.PetShelters);
                dataContext.SaveChanges();
            }

            if (!dataContext.PetShelters.Any())
            {
                Owner twoPetsOwner = new Owner { Name = "Yurik", SurName = "Bury", Address = "9 Willow Avenue" };

                var PetShelters = new List<PetShelter>()
                {
                    new PetShelter()
                    {
                        Address = "ul. Berserka 35",
                        Pets = new List<Pet>
                        {
                            new Pet { Name = "Aki", Age = 2, Gender = 'M', ImgSrc="https://ethnomir.ru/upload/medialibrary/a8a/otkuda_vzyalis_khaski_1.jpg",
                                KindOfAnimal = KindsOfAnimal.Dog, Breed = "Haski"},
                            new Pet { Name = "Miku", Age = 1, Gender = 'F', DateOfTaking = new DateOnly(2024,01,01), ImgSrc = "https://moizver.com/upload/medialibrary/f5a/f5a1cbcd9bfdf5634edfa557c8662a1a.jpg",
                                KindOfAnimal = KindsOfAnimal.Cat, Breed = "British",
                                Owner = new Owner{ Name = "Alex", SurName = "Baginsky", Address = "13 Maple Street"}},
                            new Pet { Name = "Pirozok", Age = 0, Gender = 'M', DateOfTaking = new DateOnly(2023,03,28), ImgSrc = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTB7V1_ixcevL4KHwKkBVhs0e-nmDtK7tx6SQ&usqp=CAU",
                                KindOfAnimal = KindsOfAnimal.Hamster, Breed = "Jungaryk",
                                Owner = new Owner{ Name = "Yaroslav", SurName = "Yanovich", Address = "21 Pine Road"}}
                        },
                        ImgSrc = "https://icma.org/sites/default/files/3218_Animal%20shelter.JPG"
                    },
                    new PetShelter()
                    {
                        Address = "ul. Mrkanova 2",
                        Pets = new List<Pet>
                        {
                            new Pet { Name = "Power", Age = 3, Gender = 'F', ImgSrc = "https://www.wagr.ai/cdn/shop/articles/dog-breed-labrador-retriever-548968.webp?v=1671205002",
                                KindOfAnimal = KindsOfAnimal.Dog, Breed = "Labrador"},
                            new Pet { Name = "Whiskers", Age = 2, Gender = 'M', ImgSrc = "https://www.purina.co.uk/sites/default/files/styles/square_medium_440x440/public/2022-06/Siamese-Cat_0.jpg?itok=Qy1J6ZDS",
                                KindOfAnimal = KindsOfAnimal.Cat, Breed = "Siamese",
                                DateOfTaking = new DateOnly(2023,10,15), Owner = twoPetsOwner},
                            new Pet { Name = "Nibbles", Age = 1, Gender = 'M', ImgSrc = "https://cdn.shortpixel.ai/spai/q_glossy+w_1082+to_webp+ret_img/woodgreen.org.uk/wp-content/uploads/2021/11/hamster_advice_article.jpeg",
                                KindOfAnimal = KindsOfAnimal.Hamster, Breed = "Syrian",
                                DateOfTaking = new DateOnly(2023,10,15), Owner = twoPetsOwner}
                        },
                        ImgSrc = "https://dl5zpyw5k3jeb.cloudfront.net/organization-photos/25370/1/?bust=1511212639"
                    }
                };
                dataContext.PetShelters.AddRange(PetShelters);
                dataContext.SaveChanges();
            }
        }
    }
}
