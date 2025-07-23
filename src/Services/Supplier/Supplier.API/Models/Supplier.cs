namespace Supplier.API.Models
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string ContactPerson { get; set; }=default!;
        public string PhoneNumber { get; set; }=default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string EconomicID { get; set; } = default!;
        public bool IsActive { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
