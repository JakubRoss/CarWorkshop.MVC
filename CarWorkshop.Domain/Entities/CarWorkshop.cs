using Microsoft.AspNetCore.Identity;

namespace CarWorkshop.Domain.Entities
{
    public class CarWorkshop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime Createdat { get; set; } = DateTime.UtcNow;
        public CarWorkshopContactDetails ContactDetails { get; set; } = default!;
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }
        public string EncodedName { get; private set; } = default!;

        //navigation Properties
        public virtual IEnumerable<CarWorkshopService> Services { get; set; } = new List<CarWorkshopService>();

        public void EncodeName()
        {
            EncodedName = Name.ToLower().Replace(" ", "-");
        }
    }
}
