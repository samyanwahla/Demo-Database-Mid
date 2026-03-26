namespace PhoneBook.UI
{
    partial class frmPhoneBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvContacts   = new System.Windows.Forms.DataGridView();
            this.pnlBottom     = new System.Windows.Forms.Panel();
            this.pnlFields     = new System.Windows.Forms.Panel();
            this.lblFirstName  = new System.Windows.Forms.Label();
            this.txtFirstName  = new System.Windows.Forms.TextBox();
            this.lblLastName   = new System.Windows.Forms.Label();
            this.txtLastName   = new System.Windows.Forms.TextBox();
            this.lblPhone      = new System.Windows.Forms.Label();
            this.txtPhone      = new System.Windows.Forms.TextBox();
            this.lblEmail      = new System.Windows.Forms.Label();
            this.txtEmail      = new System.Windows.Forms.TextBox();
            this.lblAddress    = new System.Windows.Forms.Label();
            this.txtAddress    = new System.Windows.Forms.TextBox();
            this.pnlButtons    = new System.Windows.Forms.Panel();
            this.btnAdd        = new System.Windows.Forms.Button();
            this.btnUpdate     = new System.Windows.Forms.Button();
            this.btnDelete     = new System.Windows.Forms.Button();
            this.btnClear      = new System.Windows.Forms.Button();
            this.lblTitle      = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlFields.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // -------------------------------------------------------
            // lblTitle
            // -------------------------------------------------------
            this.lblTitle.Dock      = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font      = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.lblTitle.Height    = 40;
            this.lblTitle.Text      = "📋  PhoneBook — 3-Layer CRUD Demo";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding   = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // -------------------------------------------------------
            // dgvContacts — DataGridView (top 55% of form)
            // -------------------------------------------------------
            this.dgvContacts.AllowUserToAddRows          = false;
            this.dgvContacts.AllowUserToDeleteRows       = false;
            this.dgvContacts.AutoSizeColumnsMode         = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContacts.BackgroundColor             = System.Drawing.SystemColors.Window;
            this.dgvContacts.BorderStyle                 = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Dock                        = System.Windows.Forms.DockStyle.Top;
            this.dgvContacts.Height                      = 300;
            this.dgvContacts.MultiSelect                 = false;
            this.dgvContacts.Name                        = "dgvContacts";
            this.dgvContacts.ReadOnly                    = true;
            this.dgvContacts.RowHeadersVisible           = false;
            this.dgvContacts.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContacts.TabIndex                    = 0;
            this.dgvContacts.CellClick                  += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContacts_CellClick);

            // -------------------------------------------------------
            // pnlBottom — container for fields + buttons
            // -------------------------------------------------------
            this.pnlBottom.Dock    = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBottom.Controls.Add(this.pnlButtons);
            this.pnlBottom.Controls.Add(this.pnlFields);

            // -------------------------------------------------------
            // pnlFields — two-column label/textbox grid
            // -------------------------------------------------------
            this.pnlFields.Dock   = System.Windows.Forms.DockStyle.Fill;
            this.pnlFields.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFirstName, this.txtFirstName,
                this.lblLastName,  this.txtLastName,
                this.lblPhone,     this.txtPhone,
                this.lblEmail,     this.txtEmail,
                this.lblAddress,   this.txtAddress
            });

            // Labels — column 0
            int labelWidth  = 90;
            int fieldHeight = 26;
            int rowSpacing  = 36;
            int startY      = 10;
            int col0X       = 10;
            int col1X       = 110;
            int col2X       = 330;
            int col3X       = 430;

            // Row 0: First Name | Last Name
            this.lblFirstName.Text      = "First Name:";
            this.lblFirstName.Location  = new System.Drawing.Point(col0X, startY + 5);
            this.lblFirstName.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtFirstName.Location  = new System.Drawing.Point(col1X, startY);
            this.txtFirstName.Size      = new System.Drawing.Size(200, fieldHeight);
            this.txtFirstName.Name      = "txtFirstName";

            this.lblLastName.Text      = "Last Name:";
            this.lblLastName.Location  = new System.Drawing.Point(col2X, startY + 5);
            this.lblLastName.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtLastName.Location  = new System.Drawing.Point(col3X, startY);
            this.txtLastName.Size      = new System.Drawing.Size(200, fieldHeight);
            this.txtLastName.Name      = "txtLastName";

            // Row 1: Phone | Email
            this.lblPhone.Text      = "Phone:";
            this.lblPhone.Location  = new System.Drawing.Point(col0X, startY + rowSpacing + 5);
            this.lblPhone.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtPhone.Location  = new System.Drawing.Point(col1X, startY + rowSpacing);
            this.txtPhone.Size      = new System.Drawing.Size(200, fieldHeight);
            this.txtPhone.Name      = "txtPhone";

            this.lblEmail.Text      = "Email:";
            this.lblEmail.Location  = new System.Drawing.Point(col2X, startY + rowSpacing + 5);
            this.lblEmail.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtEmail.Location  = new System.Drawing.Point(col3X, startY + rowSpacing);
            this.txtEmail.Size      = new System.Drawing.Size(200, fieldHeight);
            this.txtEmail.Name      = "txtEmail";

            // Row 2: Address (full width)
            this.lblAddress.Text      = "Address:";
            this.lblAddress.Location  = new System.Drawing.Point(col0X, startY + rowSpacing * 2 + 5);
            this.lblAddress.Size      = new System.Drawing.Size(labelWidth, fieldHeight);
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.txtAddress.Location  = new System.Drawing.Point(col1X, startY + rowSpacing * 2);
            this.txtAddress.Size      = new System.Drawing.Size(520, fieldHeight);
            this.txtAddress.Name      = "txtAddress";

            // -------------------------------------------------------
            // pnlButtons — button row at bottom
            // -------------------------------------------------------
            this.pnlButtons.Dock    = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Height  = 50;
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(5);
            this.pnlButtons.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnClear
            });

            // btnAdd
            this.btnAdd.Location  = new System.Drawing.Point(10, 8);
            this.btnAdd.Name      = "btnAdd";
            this.btnAdd.Size      = new System.Drawing.Size(120, 34);
            this.btnAdd.Text      = "➕  Add Contact";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(0, 153, 76);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.TabIndex  = 1;
            this.btnAdd.Click    += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Location  = new System.Drawing.Point(140, 8);
            this.btnUpdate.Name      = "btnUpdate";
            this.btnUpdate.Size      = new System.Drawing.Size(120, 34);
            this.btnUpdate.Text      = "✏️  Update";
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 102, 204);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.TabIndex  = 2;
            this.btnUpdate.Click    += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Location  = new System.Drawing.Point(270, 8);
            this.btnDelete.Name      = "btnDelete";
            this.btnDelete.Size      = new System.Drawing.Size(120, 34);
            this.btnDelete.Text      = "🗑️  Delete";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(204, 0, 0);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.TabIndex  = 3;
            this.btnDelete.Click    += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Location  = new System.Drawing.Point(400, 8);
            this.btnClear.Name      = "btnClear";
            this.btnClear.Size      = new System.Drawing.Size(120, 34);
            this.btnClear.Text      = "🔄  Clear";
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(128, 128, 128);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.TabIndex  = 4;
            this.btnClear.Click    += new System.EventHandler(this.btnClear_Click);

            // -------------------------------------------------------
            // frmPhoneBook — the main form
            // -------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvContacts);
            this.Controls.Add(this.lblTitle);
            this.MinimumSize         = new System.Drawing.Size(900, 600);
            this.Name                = "frmPhoneBook";
            this.StartPosition       = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text                = "PhoneBook - Demo CRUD App";
            this.Load               += new System.EventHandler(this.frmPhoneBook_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlFields.ResumeLayout(false);
            this.pnlFields.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // -------------------------------------------------------
        // Control declarations
        // -------------------------------------------------------
        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Panel        pnlBottom;
        private System.Windows.Forms.Panel        pnlFields;
        private System.Windows.Forms.Label        lblTitle;
        private System.Windows.Forms.Label        lblFirstName;
        private System.Windows.Forms.TextBox      txtFirstName;
        private System.Windows.Forms.Label        lblLastName;
        private System.Windows.Forms.TextBox      txtLastName;
        private System.Windows.Forms.Label        lblPhone;
        private System.Windows.Forms.TextBox      txtPhone;
        private System.Windows.Forms.Label        lblEmail;
        private System.Windows.Forms.TextBox      txtEmail;
        private System.Windows.Forms.Label        lblAddress;
        private System.Windows.Forms.TextBox      txtAddress;
        private System.Windows.Forms.Panel        pnlButtons;
        private System.Windows.Forms.Button       btnAdd;
        private System.Windows.Forms.Button       btnUpdate;
        private System.Windows.Forms.Button       btnDelete;
        private System.Windows.Forms.Button       btnClear;
    }
}
