namespace BEERCRUD.DTOs
{
    public class BeerUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandId { get; set; }
        public decimal Alcohol { get; set; }
    }
}
