# EatDomicile

A food delivery application built with ASP.NET Core 9.0, consisting of a REST API backend and an ASP.NET MVC web frontend.

## Project Architecture

The solution is organized into the following projects:

### **EatDomicile.Core**
The core business logic layer containing:
- **Models**: Entity classes (Burger, Pizza, Pasta, Drink, Ingredient, User, Order, Address, etc.)
- **Contexts**: Entity Framework DbContext for database access
- **Services**: Business logic services
- **Dtos**: Data Transfer Objects
- **Abstractions**: Interfaces and abstract classes
- **Migrations**: Entity Framework database migrations
- **Exceptions**: Custom exception classes
- **Enums**: Application enumerations
- **Utils**: Utility classes

### **EatDomicile.API**
The REST API project providing endpoints for:
- Addresses (`/api/address`)
- Burgers (`/api/burgers`)
- Drinks (`/api/drinks`)
- Ingredients (`/api/ingredients`)
- Orders (`/api/orders`)
- Pastas (`/api/pasta`)
- Users (`/api/users`)

Uses **Scalar** for interactive API documentation.

### **EatDomicile.Web**
The ASP.NET MVC web application providing a user interface with controllers for:
- Home
- Users
- Ingredients
- Drinks
- Orders

### **EatDomicile.Web.Services**
Service layer for the web application, handling communication with the API.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (LocalDB, Express, or full version)
- Visual Studio 2022, Rider, or VS Code (optional)

## Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd EatDomicile
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

## Configuration

### API Configuration

1. Navigate to `EatDomicile.API`
2. Copy paste `appsettings.Development.json.example` to `appsettings.Development.json`
3. Update the connection string:

```json
{
  "Database": {
    "ConnectionString": "Server=(localdb)\\mssqllocaldb;Database=EatDomicile;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

**Example connection strings:**

- **LocalDB**: `Server=(localdb)\\mssqllocaldb;Database=EatDomicile;Trusted_Connection=true;TrustServerCertificate=true;`
- **SQL Server Express**: `Server=localhost\\SQLEXPRESS;Database=EatDomicile;Trusted_Connection=true;TrustServerCertificate=true;`
- **SQL Server with credentials**: `Server=localhost;Database=EatDomicile;User Id=sa;Password=YourPassword;TrustServerCertificate=true;`

### Web Configuration

The web application is configured to communicate with the API. If you modify the API port, update the API URL in `EatDomicile.Web.Services` accordingly.

## Database Setup

### Create and Configure the Database

The project uses Entity Framework Core migrations to manage the database schema.

1. **Navigate to the solution root directory**
   ```bash
   cd EatDomicile
   ```

2. **Apply all migrations to create the database**
   ```bash
   dotnet ef database update -p EatDomicile.Core -s EatDomicile.API
   ```

3. **Verify database creation**

   Connect to your SQL Server instance using SQL Server Management Studio (SSMS) or Azure Data Studio and verify the `EatDomicile` database exists with all tables.

### Create New Migrations (Optional)

If you modify entity models and need to create a new migration:

```bash
dotnet ef migrations add MigrationName -p EatDomicile.Core -s EatDomicile.API
```

### Reset Database (Optional)

To drop and recreate the database:

```bash
dotnet ef database drop -p EatDomicile.Core -s EatDomicile.API
dotnet ef database update -p EatDomicile.Core -s EatDomicile.API
```

## Running the Application

### Launch the API

1. **From the command line:**
   ```bash
   cd EatDomicile.API
   dotnet run
   ```

2. **From Visual Studio/Rider:**
   - Set `EatDomicile.API` as the startup project
   - Press F5 or click Run

**Default ports:**
- HTTP: `http://localhost:5001`
- HTTPS: `https://localhost:7001`

**API Documentation:**
- Scalar UI: `https://localhost:7001/scalar/` (or `http://localhost:5001/scalar/`)

### Launch the Web Application

1. **From the command line:**
   ```bash
   cd EatDomicile.Web
   dotnet run
   ```

2. **From Visual Studio/Rider:**
   - Set `EatDomicile.Web` as the startup project
   - Press F5 or click Run

**Default ports:**
- HTTP: `http://localhost:5000`
- HTTPS: `https://localhost:7000`

### Running Both Projects Simultaneously

To run both the API and Web application at the same time:

**Visual Studio:**
1. Right-click the solution => Properties
2. Select "Multiple startup projects"
3. Set both `EatDomicile.API` and `EatDomicile.Web` to "Start"
4. Press F5

**Command line (separate terminals):**
```bash
# Terminal 1
cd EatDomicile.API
dotnet run

# Terminal 2
cd EatDomicile.Web
dotnet run
```

## Port Summary

| Project | HTTP Port | HTTPS Port |
|---------|-----------|------------|
| **EatDomicile.API** | 5001 | 7001 |
| **EatDomicile.Web** | 5000 | 7000 |

## Technology Stack

- **.NET 9.0**
- **ASP.NET Core Web API**
- **ASP.NET Core MVC**
- **Entity Framework Core 9.0.8**
- **SQL Server**
- **Scalar** (API documentation)

## Development

### Project Dependencies

- `EatDomicile.API` references => `EatDomicile.Core`
- `EatDomicile.Web` references => `EatDomicile.Web.Services`
- `EatDomicile.Web.Services` references => `EatDomicile.Core` (likely)

### Build the Solution

```bash
dotnet build
```


## Troubleshooting

### Database Connection Issues

- Verify SQL Server is running
- Check the connection string in `appsettings.json`
- Ensure the database user has proper permissions
- For LocalDB, ensure it's installed with Visual Studio or SQL Server Express

### Port Conflicts

If default ports are in use, modify `Properties/launchSettings.json` in the respective projects.

### Migration Issues

If migrations fail, check:
- Connection string is correct
- SQL Server is accessible
- The `EatDomicile.Core` project builds successfully


## Contributors

- [Alain Roger SANGA](https://github.com/arogersanga)
- [Alexandre MENIGAULT](https://github.com/Alexandre-Menigault)
- [Pierre DELAROCQUE](https://github.com/PierreDelarocque)
