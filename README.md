# Umuganda Tracker — Building Rwanda Together

A C# Windows Forms (.NET Framework 4.7.2) desktop application implementing the **MVC (Model-View-Controller)** pattern with **ADO.NET** and **MariaDB / MySQL**.

The application manages Rwanda's monthly **Umuganda** community civic duty, providing administrative oversight for village leaders and a self-service participation portal for citizens.

---

## Architecture

- **Pattern**: MVC (Model-View-Controller)
- **Data Access**: ADO.NET with `MySqlConnector` and parameterized SQL queries
- **Database**: MariaDB / MySQL (`UmugandaDB`) on `127.0.0.1:3306`
- **UI**: Windows Forms styled with Rwanda national colors (Sky Blue `#00A1DE`, Forest Green `#00A651`, Sun Yellow `#FAD201`)

```
UmugandaTracker/
├── Models/        -> User, Zone, UmugandaEvent, AttendanceRecord
├── Repositories/  -> Database, UserRepository, ZoneRepository, EventRepository, AttendanceRepository
├── Controllers/   -> AuthController, UserController, ZoneController, EventController, AttendanceController
└── Views/         -> LoginForm, RegisterForm, MainForm, ZoneForm, UserForm, EventForm, CheckInForm, ReportForm
```

---

## Setup & Running the Project

### 1. Database Setup (XAMPP / MySQL)
1. Start **Apache** and **MySQL** in the XAMPP Control Panel.
2. Open **phpMyAdmin** (`http://localhost/phpmyadmin`) or MySQL CLI.
3. Import the included `database.sql` script located in the project root:
   - This creates `UmugandaDB` and sets up all 4 tables with sample zones, events, and users.

### 2. Run the Application
1. Open `UmugandaTracker.slnx` or `UmugandaTracker/UmugandaTracker.csproj` in **Visual Studio**.
2. Build the solution (**Ctrl + Shift + B**).
3. Press **Start (F5)** to launch the application.

---

## Test Accounts & Roles

The system enforces role-based access control (RBAC):

| Role | Username | Password | Access / Permissions |
| :--- | :--- | :--- | :--- |
| **Administrator** | `admin` | `admin123` | Full Access: Manage Zones, Manage Citizens, Manage Events, Check-In, Reports |
| **Citizen (Member)** | `kamanzi` | `pass123` | Citizen Access: Attendance Check-In, View Personal Reports |
| **Citizen (Member)** | `masoyinyanna` | `aaa` | Citizen Access: Attendance Check-In, View Personal Reports |

### Citizen Self-Registration
- Citizens can also click **"New Citizen? Register Here"** on the Login screen to create their own citizen account without waiting for an administrator.
- Self-registered accounts are automatically assigned the `Member` role.

---

## Real-World Umuganda Flow

1. **Admin Setup**: Village / Sector leaders define the community **Zones** and schedule upcoming **Umuganda Events** with assigned sites and dates.
2. **Citizen Registration**: Residents register their citizen account.
3. **Arrival Check-In**: Upon arriving at the community site in the morning, the citizen opens **Attendance Check-In**, picks the village event, and clicks **Check-In (Arrival)**. The system records the arrival timestamp.
4. **Validation Logic**: The system enforces that citizens **cannot check out before checking in**, and cannot check in twice for the same event.
5. **Departure Check-Out**: When public work concludes and the village dialogue (*Inama*) finishes, the citizen clicks **Check-Out (Departure)**.
6. **Reporting**: Administrators can view community-wide attendance reports with joined event, zone, citizen names, and completion status.
