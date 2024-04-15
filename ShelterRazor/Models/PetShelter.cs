namespace ShelterRazor.Models
{
    public class PetShelter
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string ImgSrc { get; set; }
        public ICollection<Pet>? Pets { get; set; }
    }
}
