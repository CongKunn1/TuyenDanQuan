# TuyenDanQuan - Development Guide

## Branch Configuration

This repository uses the following branch strategy:

- **master**: Production branch - stable, tested code
- **dev/develop**: Development branch - active development work
- **feature branches**: Individual feature development

## Development Environment Setup

### Prerequisites
- .NET 8.0 SDK
- SQL Server or SQL Server Express
- Visual Studio or VS Code

### Configuration

The project uses environment-specific configuration files:

- `appsettings.json` - Production configuration
- `appsettings.Development.json` - Development configuration

### Database Setup

Development environment uses a separate database: `TuyenDanQuan_Dev`

To set up the development database:

1. Make sure SQL Server is running
2. Run Entity Framework migrations:
   ```bash
   dotnet ef database update --project EFCore --startup-project TuyenDanQuan
   ```

### Running the Application

```bash
cd TuyenDanQuan
dotnet run
```

The application will run on:
- HTTPS: https://localhost:7138
- HTTP: http://localhost:5195

### Development Workflow

1. Clone the repository
2. Create a feature branch from `dev`
3. Make your changes
4. Test locally
5. Commit and push to your feature branch
6. Create a Pull Request to `dev` branch

## Common Issues

### Cannot Push to Dev Branch

If you encounter issues pushing to the dev branch:

1. Ensure you have the latest changes: `git pull origin dev`
2. Check your local configuration is correct
3. Verify the application builds successfully: `dotnet build`
4. Make sure all tests pass (if available)

### Database Connection Issues

If you encounter database connection issues:

1. Verify SQL Server is running
2. Check the connection string in `appsettings.Development.json`
3. Ensure the development database exists
4. Run migrations if needed

## Project Structure

- `TuyenDanQuan/` - Main web application
- `EFCore/` - Entity Framework Core models and database context
- `EFCore/Migrations/` - Database migration files