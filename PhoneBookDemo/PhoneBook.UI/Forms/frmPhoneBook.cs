using System;
using System.Windows.Forms;
using PhoneBook.BL;
using PhoneBook.Models;

namespace PhoneBook.UI
{
    // UI LAYER: Windows Forms — handles user interaction ONLY
    // Teaching Point 1: UI never writes SQL — all DB work stays in DAL
    // Teaching Point 6: UI only calls BL — it does NOT reference PhoneBook.DAL at all
    public partial class frmPhoneBook : Form
    {
        // BL instance — this is the ONLY layer the UI talks to
        private readonly ContactBL _bl = new ContactBL();

        // Tracks which contact row is selected in the DataGridView
        private int _selectedContactId = 0;

        // -------------------------------------------------------
        // Constructor
        // -------------------------------------------------------
        public frmPhoneBook()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------
        // Form Load: populate the grid on startup
        // -------------------------------------------------------
        private void frmPhoneBook_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        // -------------------------------------------------------
        // Helper: Load all contacts into DataGridView
        // Teaching Point 3: Models are shared — we use Contact objects returned by BL
        // -------------------------------------------------------
        private void LoadContacts()
        {
            dgvContacts.DataSource = null;
            dgvContacts.DataSource = _bl.GetAllContacts();

            // Rename grid column headers for a cleaner display
            if (dgvContacts.Columns.Contains("ContactId"))
                dgvContacts.Columns["ContactId"].HeaderText = "ID";
            if (dgvContacts.Columns.Contains("FirstName"))
                dgvContacts.Columns["FirstName"].HeaderText = "First Name";
            if (dgvContacts.Columns.Contains("LastName"))
                dgvContacts.Columns["LastName"].HeaderText = "Last Name";
            if (dgvContacts.Columns.Contains("PhoneNumber"))
                dgvContacts.Columns["PhoneNumber"].HeaderText = "Phone";
            if (dgvContacts.Columns.Contains("Email"))
                dgvContacts.Columns["Email"].HeaderText = "Email";
            if (dgvContacts.Columns.Contains("Address"))
                dgvContacts.Columns["Address"].HeaderText = "Address";

            // Hide the computed FullName column — it's for BL/logic use
            if (dgvContacts.Columns.Contains("FullName"))
                dgvContacts.Columns["FullName"].Visible = false;
        }

        // -------------------------------------------------------
        // Grid row click: populate text fields from selected row
        // -------------------------------------------------------
        private void dgvContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvContacts.Rows[e.RowIndex];
            _selectedContactId     = Convert.ToInt32(row.Cells["ContactId"].Value);
            txtFirstName.Text      = row.Cells["FirstName"].Value?.ToString()   ?? string.Empty;
            txtLastName.Text       = row.Cells["LastName"].Value?.ToString()    ?? string.Empty;
            txtPhone.Text          = row.Cells["PhoneNumber"].Value?.ToString() ?? string.Empty;
            txtEmail.Text          = row.Cells["Email"].Value?.ToString()       ?? string.Empty;
            txtAddress.Text        = row.Cells["Address"].Value?.ToString()     ?? string.Empty;
        }

        // -------------------------------------------------------
        // ADD button: UI → BL → DAL → MySQL
        // Teaching Point 2: BL validates before DAL — BL returns (success, message)
        // -------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var contact = BuildContactFromFields();
            contact.ContactId = 0; // New record — no ID yet

            var (success, message) = _bl.AddContact(contact);

            MessageBox.Show(message,
                success ? "Success" : "Validation Error",
                MessageBoxButtons.OK,
                success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (success)
            {
                ClearFields();
                LoadContacts();
            }
        }

        // -------------------------------------------------------
        // UPDATE button
        // -------------------------------------------------------
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var contact = BuildContactFromFields();
            contact.ContactId = _selectedContactId;

            var (success, message) = _bl.UpdateContact(contact);

            MessageBox.Show(message,
                success ? "Success" : "Validation Error",
                MessageBoxButtons.OK,
                success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (success)
            {
                ClearFields();
                LoadContacts();
            }
        }

        // -------------------------------------------------------
        // DELETE button — shows confirmation dialog first
        // -------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedContactId <= 0)
            {
                MessageBox.Show("Please select a contact to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to delete this contact?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var (success, message) = _bl.DeleteContact(_selectedContactId);

            MessageBox.Show(message,
                success ? "Deleted" : "Error",
                MessageBoxButtons.OK,
                success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (success)
            {
                ClearFields();
                LoadContacts();
            }
        }

        // -------------------------------------------------------
        // CLEAR button — reset form to blank state
        // -------------------------------------------------------
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // -------------------------------------------------------
        // Helper: Build a Contact object from the text fields
        // -------------------------------------------------------
        private Contact BuildContactFromFields()
        {
            return new Contact
            {
                FirstName   = txtFirstName.Text.Trim(),
                LastName    = txtLastName.Text.Trim(),
                PhoneNumber = txtPhone.Text.Trim(),
                Email       = txtEmail.Text.Trim(),
                Address     = txtAddress.Text.Trim()
            };
        }

        // -------------------------------------------------------
        // Helper: Clear all input fields and reset selection
        // -------------------------------------------------------
        private void ClearFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text  = string.Empty;
            txtPhone.Text     = string.Empty;
            txtEmail.Text     = string.Empty;
            txtAddress.Text   = string.Empty;
            _selectedContactId = 0;
            dgvContacts.ClearSelection();
        }
    }
}
