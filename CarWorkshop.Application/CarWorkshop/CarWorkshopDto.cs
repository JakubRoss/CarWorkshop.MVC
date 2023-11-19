using System.ComponentModel.DataAnnotations;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        [Required]
        [StringLength(20,MinimumLength =4)]
        public string Name { get; set; } = default!;
        [Required]
        public string? Description { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public string? EncodedName { get; private set; }
    }
}
