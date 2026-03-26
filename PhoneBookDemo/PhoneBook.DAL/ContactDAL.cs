using MySql.Data.MySqlClient;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    // DAL LAYER: All SQL queries live here — UI never sees SQL
    // Teaching Point 1: UI never writes SQL — all DB work stays in DAL
    // Teaching Point 4: Parameterized queries prevent SQL Injection
    public class ContactDAL
    {
        // -------------------------------------------------------
        // READ: Get all contacts from the database
        // -------------------------------------------------------
        public List<Contact> GetAllContacts()
        {
            var contacts = new List<Contact>();

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ContactId, FirstName, LastName, PhoneNumber, Email, Address FROM Contacts ORDER BY FirstName";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contacts.Add(new Contact
                        {
                            ContactId   = reader.GetInt32("ContactId"),
                            FirstName   = reader.GetString("FirstName"),
                            LastName    = reader.GetString("LastName"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            Email       = reader.IsDBNull(reader.GetOrdinal("Email"))   ? string.Empty : reader.GetString("Email"),
                            Address     = reader.IsDBNull(reader.GetOrdinal("Address")) ? string.Empty : reader.GetString("Address")
                        });
                    }
                }
            }

            return contacts;
        }

        // -------------------------------------------------------
        // READ: Get a single contact by ID
        // -------------------------------------------------------
        public Contact? GetContactById(int id)
        {
            Contact? contact = null;

            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT ContactId, FirstName, LastName, PhoneNumber, Email, Address FROM Contacts WHERE ContactId = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Teaching Point 4: Always use MySqlParameter — never string concatenation!
                    cmd.Parameters.AddWithValue("@id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            contact = new Contact
                            {
                                ContactId   = reader.GetInt32("ContactId"),
                                FirstName   = reader.GetString("FirstName"),
                                LastName    = reader.GetString("LastName"),
                                PhoneNumber = reader.GetString("PhoneNumber"),
                                Email       = reader.IsDBNull(reader.GetOrdinal("Email"))   ? string.Empty : reader.GetString("Email"),
                                Address     = reader.IsDBNull(reader.GetOrdinal("Address")) ? string.Empty : reader.GetString("Address")
                            };
                        }
                    }
                }
            }

            return contact;
        }

        // -------------------------------------------------------
        // CREATE: Insert a new contact
        // -------------------------------------------------------
        public bool AddContact(Contact contact)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Contacts (FirstName, LastName, PhoneNumber, Email, Address)
                                 VALUES (@firstName, @lastName, @phone, @email, @address)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    // Teaching Point 4: Parameterized queries — safe from SQL injection
                    cmd.Parameters.AddWithValue("@firstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@lastName",  contact.LastName);
                    cmd.Parameters.AddWithValue("@phone",     contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email",     contact.Email   ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@address",   contact.Address ?? (object)DBNull.Value);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // -------------------------------------------------------
        // UPDATE: Modify an existing contact
        // -------------------------------------------------------
        public bool UpdateContact(Contact contact)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Contacts
                                    SET FirstName   = @firstName,
                                        LastName    = @lastName,
                                        PhoneNumber = @phone,
                                        Email       = @email,
                                        Address     = @address
                                  WHERE ContactId = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@firstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@lastName",  contact.LastName);
                    cmd.Parameters.AddWithValue("@phone",     contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@email",     contact.Email   ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@address",   contact.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id",        contact.ContactId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // -------------------------------------------------------
        // DELETE: Remove a contact by ID
        // -------------------------------------------------------
        public bool DeleteContact(int contactId)
        {
            using (var conn = DBHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Contacts WHERE ContactId = @id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", contactId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
