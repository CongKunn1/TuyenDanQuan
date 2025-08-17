# Development Environment Setup Script for Windows
# Thiết lập môi trường phát triển cho nhánh dev

Write-Host "🚀 Thiết lập môi trường phát triển cho TuyenDanQuan" -ForegroundColor Green
Write-Host "==================================================" -ForegroundColor Green

# Kiểm tra .NET SDK
Write-Host "📋 Kiểm tra .NET SDK..." -ForegroundColor Yellow
try {
    $dotnetVersion = dotnet --version
    Write-Host "✅ .NET SDK đã được cài đặt: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "❌ .NET SDK chưa được cài đặt. Vui lòng cài đặt .NET 8.0 SDK" -ForegroundColor Red
    exit 1
}

# Kiểm tra Git
Write-Host "📋 Kiểm tra Git..." -ForegroundColor Yellow
try {
    $gitVersion = git --version
    Write-Host "✅ Git đã được cài đặt: $gitVersion" -ForegroundColor Green
} catch {
    Write-Host "❌ Git chưa được cài đặt" -ForegroundColor Red
    exit 1
}

# Chuyển sang nhánh dev
Write-Host "📋 Chuyển sang nhánh dev..." -ForegroundColor Yellow
$devBranchExists = git show-ref --verify --quiet refs/heads/dev
if ($LASTEXITCODE -eq 0) {
    git checkout dev
    Write-Host "✅ Đã chuyển sang nhánh dev" -ForegroundColor Green
} else {
    Write-Host "📥 Tạo và chuyển sang nhánh dev từ remote..." -ForegroundColor Yellow
    git fetch origin
    git checkout -b dev origin/dev
    Write-Host "✅ Đã tạo và chuyển sang nhánh dev" -ForegroundColor Green
}

# Pull latest changes
Write-Host "📋 Cập nhật nhánh dev..." -ForegroundColor Yellow
git pull origin dev
Write-Host "✅ Đã cập nhật nhánh dev" -ForegroundColor Green

# Restore NuGet packages
Write-Host "📋 Khôi phục NuGet packages..." -ForegroundColor Yellow
dotnet restore
if ($LASTEXITCODE -eq 0) {
    Write-Host "✅ Đã khôi phục packages thành công" -ForegroundColor Green
} else {
    Write-Host "❌ Lỗi khi khôi phục packages" -ForegroundColor Red
    exit 1
}

# Build solution
Write-Host "📋 Build solution..." -ForegroundColor Yellow
dotnet build --configuration Debug
if ($LASTEXITCODE -eq 0) {
    Write-Host "✅ Build thành công" -ForegroundColor Green
} else {
    Write-Host "❌ Lỗi khi build solution" -ForegroundColor Red
    exit 1
}

# Kiểm tra EF Core tools
Write-Host "📋 Kiểm tra Entity Framework Core tools..." -ForegroundColor Yellow
try {
    dotnet ef --version | Out-Null
    Write-Host "✅ EF Core tools đã được cài đặt" -ForegroundColor Green
} catch {
    Write-Host "📥 Cài đặt EF Core tools..." -ForegroundColor Yellow
    dotnet tool install --global dotnet-ef
    Write-Host "✅ Đã cài đặt EF Core tools" -ForegroundColor Green
}

Write-Host ""
Write-Host "🎉 Thiết lập môi trường phát triển hoàn tất!" -ForegroundColor Green
Write-Host ""
Write-Host "📝 Các bước tiếp theo:" -ForegroundColor Cyan
Write-Host "1. Chạy 'dotnet run --project TuyenDanQuan' để khởi động API" -ForegroundColor White
Write-Host "2. Mở https://localhost:5001/swagger để xem API documentation" -ForegroundColor White
Write-Host "3. Đọc docs/DEV_BRANCH_WORKFLOW.md để hiểu quy trình làm việc" -ForegroundColor White
Write-Host ""
Write-Host "💡 Lưu ý: Đảm bảo SQL Server đang chạy trước khi khởi động ứng dụng" -ForegroundColor Yellow