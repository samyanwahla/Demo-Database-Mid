namespace PhoneBook.Models
{
    // MODELS LAYER: Shared entity used by ALL layers
    // Teaching Point 3: One Contact class used across UI, BL, and DAL — no duplication
    public class Contact
    {
        public int    ContactId   { get; set; }
        public string FirstName   { get; set; } = string.Empty;
        public string LastName    { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email       { get; set; } = string.Empty;
        public string Address     { get; set; } = string.Empty;

        // Computed property — no column in DB, derived from FirstName + LastName
        public string FullName => $"{FirstName} {LastName}";
    }
}
