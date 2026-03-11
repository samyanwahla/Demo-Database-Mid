using PhoneBook.DAL;
using PhoneBook.Models;

namespace PhoneBook.BL
{
    // BL LAYER: Validates input BEFORE sending to DAL
    // Teaching Point 2: BL validates before DAL — dirty data never reaches the database
    // Teaching Point 5: Separation of Concerns — BL has ONE job: business rules & validation
    // Teaching Point 6: UI depends only on BL — UI never calls DAL directly
    public class ContactBL
    {
        // BL creates DAL — UI never touches DAL
        private readonly ContactDAL _dal = new ContactDAL();

        // -------------------------------------------------------
        // READ: Return all contacts (no validation needed for a read-all)
        // -------------------------------------------------------
        public List<Contact> GetAllContacts() => _dal.GetAllContacts();

        // -------------------------------------------------------
        // CREATE: Validate, then add
        // -------------------------------------------------------
        public (bool success, string message) AddContact(Contact contact)
        {
            // Validation happens HERE in BL — never in UI, never in DAL
            if (string.IsNullOrWhiteSpace(contact.FirstName))
                return (false, "First name is required.");

            if (string.IsNullOrWhiteSpace(contact.PhoneNumber))
                return (false, "Phone number is required.");

            if (contact.PhoneNumber.Length < 7)
                return (false, "Phone number must be at least 7 digits.");

            bool result = _dal.AddContact(contact);
            return result
                ? (true,  "Contact added successfully.")
                : (false, "Failed to add contact.");
        }

        // -------------------------------------------------------
        // UPDATE: Validate, then update
        // -------------------------------------------------------
        public (bool success, string message) UpdateContact(Contact contact)
        {
            if (contact.ContactId <= 0)
                return (false, "Invalid contact selected.");

            if (string.IsNullOrWhiteSpace(contact.FirstName))
                return (false, "First name is required.");

            if (string.IsNullOrWhiteSpace(contact.PhoneNumber))
                return (false, "Phone number is required.");

            if (contact.PhoneNumber.Length < 7)
                return (false, "Phone number must be at least 7 digits.");

            bool result = _dal.UpdateContact(contact);
            return result
                ? (true,  "Contact updated successfully.")
                : (false, "Failed to update contact.");
        }

        // -------------------------------------------------------
        // DELETE: Validate ID, then delete
        // -------------------------------------------------------
        public (bool success, string message) DeleteContact(int contactId)
        {
            if (contactId <= 0)
                return (false, "Please select a contact to delete.");

            bool result = _dal.DeleteContact(contactId);
            return result
                ? (true,  "Contact deleted successfully.")
                : (false, "Failed to delete contact.");
        }
    }
}
