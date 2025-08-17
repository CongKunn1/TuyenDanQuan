#!/bin/bash
# Development environment setup script for TuyenDanQuan

echo "Setting up TuyenDanQuan development environment..."

# Check if .NET 8 is installed
if ! command -v dotnet &> /dev/null; then
    echo "Error: .NET 8 SDK is not installed. Please install it first."
    exit 1
fi

# Check .NET version
DOTNET_VERSION=$(dotnet --version)
echo "Found .NET version: $DOTNET_VERSION"

# Restore packages
echo "Restoring NuGet packages..."
dotnet restore

# Build the solution
echo "Building the solution..."
dotnet build

if [ $? -eq 0 ]; then
    echo "✅ Build successful!"
else
    echo "❌ Build failed. Please check the errors above."
    exit 1
fi

# Set up git configuration for development
echo "Setting up git configuration..."
git config --local push.default current
git config --local core.autocrlf true

# Check if dev branch exists locally
if git show-ref --verify --quiet refs/heads/dev; then
    echo "✅ Dev branch already exists locally"
else
    echo "Creating local dev branch..."
    if git show-ref --verify --quiet refs/remotes/origin/dev; then
        git checkout -b dev origin/dev
        echo "✅ Created local dev branch tracking origin/dev"
    else
        echo "⚠️  Remote dev branch not found. You may need to create it first."
    fi
fi

echo ""
echo "🎉 Development environment setup complete!"
echo ""
echo "To start development:"
echo "1. Switch to dev branch: git checkout dev"
echo "2. Create a feature branch: git checkout -b feature/your-feature-name"
echo "3. Start coding!"
echo "4. Run the application: cd TuyenDanQuan && dotnet run"
echo ""
echo "The application will be available at:"
echo "- HTTPS: https://localhost:7138"
echo "- HTTP: http://localhost:5195"