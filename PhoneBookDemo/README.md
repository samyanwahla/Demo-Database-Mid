# PhoneBook CRUD Demo — 3-Layer Architecture

A **Windows Forms** demo project for students demonstrating a clean **3-Layer Architecture** with full CRUD operations backed by **MySQL**.

---

## 📁 Project Structure

```
PhoneBookDemo/
├── Database/
│   └── phonebook_schema.sql          ← Run this first!
│
├── PhoneBook.Models/                 ← Shared Contact class (no dependencies)
│   ├── Contact.cs
│   └── PhoneBook.Models.csproj
│
├── PhoneBook.DAL/                    ← Data Access Layer (MySQL via ADO.NET)
│   ├── DBHelper.cs                   ← Connection string lives here
│   ├── ContactDAL.cs                 ← All parameterized SQL queries
│   └── PhoneBook.DAL.csproj
│
├── PhoneBook.BL/                     ← Business Logic Layer (validation + rules)
│   ├── ContactBL.cs
│   └── PhoneBook.BL.csproj
│
├── PhoneBook.UI/                     ← WinForms UI (never writes SQL)
│   ├── Program.cs
│   ├── PhoneBook.UI.csproj
│   └── Forms/
│       ├── frmPhoneBook.cs
│       ├── frmPhoneBook.Designer.cs
│       └── frmPhoneBook.resx
│
└── PhoneBookDemo.sln                 ← Open this in Visual Studio 2022
```

---

## 🚀 Quick Start

### Step 1 — Set up the Database
1. Open **MySQL Workbench** (or any MySQL client)
2. Run the script: `Database/phonebook_schema.sql`
3. This creates the `PhoneBookDB` database, the `Contacts` table, and inserts 5 sample contacts

### Step 2 — Update the Connection String
Open `PhoneBook.DAL/DBHelper.cs` and update the password to match your MySQL installation:

```csharp
private const string ConnectionString =
    "Server=localhost;Database=PhoneBookDB;Uid=root;Pwd=YOUR_PASSWORD_HERE;";
```

### Step 3 — Open the Solution
1. Open `PhoneBookDemo.sln` in **Visual Studio 2022**
2. Right-click the solution → **Restore NuGet Packages** (downloads `MySql.Data`)
3. Right-click `PhoneBook.UI` → **Set as Startup Project**
4. Press **F5** to run

---

## 🏗️ Architecture Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                         UI LAYER                                │
│   PhoneBook.UI / frmPhoneBook.cs                                │
│   WinForms — handles button clicks, shows MessageBox, binds     │
│   DataGridView. NO SQL here. NO database connections here.      │
│                        │                                        │
│                        │  calls only  ↓                         │
│                                                                 │
│                        BL LAYER                                 │
│   PhoneBook.BL / ContactBL.cs                                   │
│   Validates input. Enforces business rules.                     │
│   Returns (bool success, string message) tuples to UI.          │
│   Never opens a DB connection.                                  │
│                        │                                        │
│                        │  calls only  ↓                         │
│                                                                 │
│                        DAL LAYER                                │
│   PhoneBook.DAL / ContactDAL.cs + DBHelper.cs                   │
│   Executes parameterized SQL queries.                           │
│   Manages MySQL connections via DBHelper.                       │
│                        │                                        │
│                        │  connects to  ↓                        │
│                                                                 │
│                        MySQL Database                           │
│   PhoneBookDB.Contacts table                                    │
└─────────────────────────────────────────────────────────────────┘
             ↕ shared across all layers ↕
       PhoneBook.Models → Contact.cs
```

### Project Reference Chain
```
PhoneBook.UI  →  PhoneBook.BL  →  PhoneBook.DAL  →  MySql.Data (NuGet)
     ↘              ↘               ↘
      PhoneBook.Models  (shared by ALL layers)
```

---

## 📌 6 Key Teaching Points

| # | Concept | Where to see it |
|---|---------|-----------------|
| 1 | **UI never writes SQL** — all DB work stays in DAL | `frmPhoneBook.cs` has zero SQL |
| 2 | **BL validates before DAL** — dirty data never reaches the database | `ContactBL.cs` — validation before calling DAL |
| 3 | **Models are shared** — one `Contact` class used across all layers | `Contact.cs` used in UI, BL, and DAL |
| 4 | **Parameterized queries** — SQL Injection prevention | `ContactDAL.cs` — all `@parameter` syntax |
| 5 | **Separation of Concerns** — each layer has ONE job | UI → display, BL → validate, DAL → query |
| 6 | **UI depends only on BL** — UI project does NOT reference DAL | `PhoneBook.UI.csproj` — no DAL reference |

---

## 🖼️ Form Layout

```
┌─────────────────────────────────────────────────────────┐
│  📋 PhoneBook — 3-Layer CRUD Demo                        │
├─────────────────────────────────────────────────────────┤
│  ID │ First Name │ Last Name │ Phone │ Email │ Address   │
│  1  │ Ali        │ Khan      │ 0300… │ …     │ …         │
│  2  │ Sara       │ Ahmed     │ 0321… │ …     │ …         │
│  ←─── click a row to populate the fields below ────→    │
├─────────────────────────────────────────────────────────┤
│  First Name: [_________]   Last Name: [_________]       │
│  Phone:      [_________]   Email:     [_________]       │
│  Address:    [___________________________]              │
├─────────────────────────────────────────────────────────┤
│  [➕ Add Contact] [✏️ Update] [🗑️ Delete] [🔄 Clear]     │
└─────────────────────────────────────────────────────────┘
```

---

## 🔑 How the Buttons Work

| Button | Flow |
|--------|------|
| **➕ Add** | TextBoxes → `ContactBL.AddContact()` validates → `ContactDAL.AddContact()` inserts |
| **✏️ Update** | Select row in grid → edit → `ContactBL.UpdateContact()` validates → `ContactDAL.UpdateContact()` runs UPDATE |
| **🗑️ Delete** | Select row → confirm dialog → `ContactBL.DeleteContact()` → `ContactDAL.DeleteContact()` runs DELETE |
| **🔄 Clear** | Clears all TextBoxes, deselects grid row, resets `_selectedContactId = 0` |

---

## 🛠️ Requirements

- **Visual Studio 2022** (any edition)
- **.NET 6.0 SDK** (Windows)
- **MySQL 5.7+** or **MySQL 8.0+**
- NuGet: `MySql.Data 8.0.33` (auto-restored)
