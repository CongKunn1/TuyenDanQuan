# TuyenDanQuan - Recruitment Management System

A .NET 8 Web API application for managing recruitment and citizen information.

## 🚀 Features

- **Citizen Management**: Track citizen information including personal details, identification, and contact information
- **Unit Management**: Manage organizational units with codes, types, and contact details
- **RESTful API**: Built with ASP.NET Core Web API
- **Database Integration**: Entity Framework Core with SQL Server support
- **API Documentation**: Swagger/OpenAPI documentation included

## 🛠️ Technology Stack

- **.NET 8**: Latest .NET framework
- **ASP.NET Core Web API**: For building RESTful APIs
- **Entity Framework Core**: ORM for database operations
- **SQL Server**: Database backend
- **Swagger**: API documentation and testing

## 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/CongKunn1/TuyenDanQuan.git
cd TuyenDanQuan
```

### 2. Configure Database Connection

Update the connection string in `TuyenDanQuan/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TuyenDanQuanDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### 3. Build the Solution

```bash
dotnet build
```

### 4. Run Database Migrations

```bash
cd TuyenDanQuan
dotnet ef database update
```

### 5. Run the Application

```bash
dotnet run
```

The API will be available at:
- HTTPS: `https://localhost:7xxx`
- HTTP: `http://localhost:5xxx`
- Swagger UI: `https://localhost:7xxx/swagger`

## 📁 Project Structure

```
TuyenDanQuan/
├── EFCore/                    # Entity Framework Core project
│   ├── Dbcontext/            # Database context
│   ├── Migrations/           # EF Core migrations
│   └── Model/                # Entity models
├── TuyenDanQuan/             # Main Web API project
│   ├── Controllers/          # API controllers
│   └── Program.cs            # Application entry point
└── TuyenDanQuan.sln          # Solution file
```

## 🏗️ Database Schema

### Entities

- **Citizen**: Personal information management
  - Id, FullName, IdentificationNumber, Sex, PhoneNumber, EmailAddress, DateOfBirth, Address
  - Inherits from BaseEntity (CreatedTime, UpdatedTime)

- **Unit**: Organizational unit management
  - Id, Code, UnitName, UnitType, EmailAddress, PhoneNumber, Address
  - Inherits from BaseEntity (CreatedTime, UpdatedTime)

## 🔧 Development

### Adding New Migrations

```bash
cd TuyenDanQuan
dotnet ef migrations add YourMigrationName
dotnet ef database update
```

### Running in Development Mode

```bash
dotnet run --environment Development
```

## 📝 API Documentation

When running in development mode, visit `/swagger` to access the interactive API documentation.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **CongKunn1** - *Initial work* - [CongKunn1](https://github.com/CongKunn1)

## 🆘 Support

If you encounter any issues or have questions, please [open an issue](https://github.com/CongKunn1/TuyenDanQuan/issues) on GitHub.