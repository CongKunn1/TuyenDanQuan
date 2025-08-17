#!/bin/bash

# Development Environment Setup Script
# Thiết lập môi trường phát triển cho nhánh dev

echo "🚀 Thiết lập môi trường phát triển cho TuyenDanQuan"
echo "=================================================="

# Kiểm tra .NET SDK
echo "📋 Kiểm tra .NET SDK..."
if command -v dotnet &> /dev/null; then
    echo "✅ .NET SDK đã được cài đặt: $(dotnet --version)"
else
    echo "❌ .NET SDK chưa được cài đặt. Vui lòng cài đặt .NET 8.0 SDK"
    exit 1
fi

# Kiểm tra Git
echo "📋 Kiểm tra Git..."
if command -v git &> /dev/null; then
    echo "✅ Git đã được cài đặt: $(git --version)"
else
    echo "❌ Git chưa được cài đặt"
    exit 1
fi

# Chuyển sang nhánh dev
echo "📋 Chuyển sang nhánh dev..."
if git show-ref --verify --quiet refs/heads/dev; then
    git checkout dev
    echo "✅ Đã chuyển sang nhánh dev"
else
    echo "📥 Tạo và chuyển sang nhánh dev từ remote..."
    git fetch origin
    git checkout -b dev origin/dev
    echo "✅ Đã tạo và chuyển sang nhánh dev"
fi

# Pull latest changes
echo "📋 Cập nhật nhánh dev..."
git pull origin dev
echo "✅ Đã cập nhật nhánh dev"

# Restore NuGet packages
echo "📋 Khôi phục NuGet packages..."
dotnet restore
if [ $? -eq 0 ]; then
    echo "✅ Đã khôi phục packages thành công"
else
    echo "❌ Lỗi khi khôi phục packages"
    exit 1
fi

# Build solution
echo "📋 Build solution..."
dotnet build --configuration Debug
if [ $? -eq 0 ]; then
    echo "✅ Build thành công"
else
    echo "❌ Lỗi khi build solution"
    exit 1
fi

# Kiểm tra EF Core tools
echo "📋 Kiểm tra Entity Framework Core tools..."
if dotnet ef --version &> /dev/null; then
    echo "✅ EF Core tools đã được cài đặt"
else
    echo "📥 Cài đặt EF Core tools..."
    dotnet tool install --global dotnet-ef
    echo "✅ Đã cài đặt EF Core tools"
fi

echo ""
echo "🎉 Thiết lập môi trường phát triển hoàn tất!"
echo ""
echo "📝 Các bước tiếp theo:"
echo "1. Chạy 'dotnet run --project TuyenDanQuan' để khởi động API"
echo "2. Mở https://localhost:5001/swagger để xem API documentation"
echo "3. Đọc docs/DEV_BRANCH_WORKFLOW.md để hiểu quy trình làm việc"
echo ""
echo "💡 Lưu ý: Đảm bảo SQL Server đang chạy trước khi khởi động ứng dụng"