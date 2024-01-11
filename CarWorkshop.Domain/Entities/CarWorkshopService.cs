namespace CarWorkshop.Domain.Entities
{
    public class CarWorkshopService
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public string Price { get; set; } = default!;

        //Navigation properties
        public Guid CarWorkshopId { get; set; }
        public CarWorkshop CarWorkshop { get; set; } = default!;
    }
}
