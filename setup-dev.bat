@echo off
REM Development environment setup script for TuyenDanQuan

echo Setting up TuyenDanQuan development environment...

REM Check if .NET is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET 8 SDK is not installed. Please install it first.
    exit /b 1
)

REM Show .NET version
echo Found .NET version:
dotnet --version

REM Restore packages
echo Restoring NuGet packages...
dotnet restore

REM Build the solution
echo Building the solution...
dotnet build

if %errorlevel% neq 0 (
    echo Build failed. Please check the errors above.
    exit /b 1
)

echo ✅ Build successful!

REM Set up git configuration for development
echo Setting up git configuration...
git config --local push.default current
git config --local core.autocrlf true

REM Check if dev branch exists locally
git show-ref --verify --quiet refs/heads/dev >nul 2>&1
if %errorlevel% neq 0 (
    echo Creating local dev branch...
    git show-ref --verify --quiet refs/remotes/origin/dev >nul 2>&1
    if %errorlevel% equ 0 (
        git checkout -b dev origin/dev
        echo ✅ Created local dev branch tracking origin/dev
    ) else (
        echo ⚠️  Remote dev branch not found. You may need to create it first.
    )
) else (
    echo ✅ Dev branch already exists locally
)

echo.
echo 🎉 Development environment setup complete!
echo.
echo To start development:
echo 1. Switch to dev branch: git checkout dev
echo 2. Create a feature branch: git checkout -b feature/your-feature-name
echo 3. Start coding!
echo 4. Run the application: cd TuyenDanQuan ^&^& dotnet run
echo.
echo The application will be available at:
echo - HTTPS: https://localhost:7138
echo - HTTP: http://localhost:5195

pause