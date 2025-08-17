# TuyenDanQuan - Hệ thống Tuyển Dân Quân

## Tổng quan
Hệ thống quản lý thông tin tuyển dân quân được phát triển bằng .NET 8.0 và Entity Framework Core.

## Cấu trúc dự án
```
TuyenDanQuan/
├── TuyenDanQuan/          # Web API project
├── EFCore/               # Data layer project
├── docs/                 # Tài liệu dự án
├── scripts/              # Scripts hỗ trợ
└── .github/workflows/    # GitHub Actions workflows
```

## Môi trường phát triển

### Yêu cầu hệ thống
- .NET 8.0 SDK
- SQL Server (LocalDB hoặc SQL Server instance)
- Git
- Visual Studio 2022 hoặc VS Code

### Thiết lập nhanh
```bash
# Clone repository
git clone https://github.com/CongKunn1/TuyenDanQuan.git
cd TuyenDanQuan

# Chạy script thiết lập (Linux/macOS)
./scripts/setup-dev.sh

# Hoặc trên Windows
PowerShell -ExecutionPolicy Bypass -File scripts/setup-dev.ps1
```

### Thiết lập thủ công

1. **Chuyển sang nhánh dev**
   ```bash
   git checkout dev
   git pull origin dev
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Build solution**
   ```bash
   dotnet build
   ```

4. **Chạy ứng dụng**
   ```bash
   dotnet run --project TuyenDanQuan
   ```

## Quy trình phát triển

### Nhánh làm việc
- `master`: Nhánh chính, chứa code ổn định
- `dev`: Nhánh phát triển, integration của các features
- `feature/*`: Nhánh phát triển tính năng mới
- `bugfix/*`: Nhánh sửa lỗi

### Workflow
1. Tạo feature branch từ `dev`
2. Phát triển tính năng trên feature branch
3. Tạo Pull Request từ feature branch vào `dev`
4. Review và merge vào `dev`
5. Định kỳ merge `dev` vào `master`

Chi tiết xem: [docs/DEV_BRANCH_WORKFLOW.md](docs/DEV_BRANCH_WORKFLOW.md)

## API Documentation
Sau khi chạy ứng dụng, truy cập Swagger UI tại:
- Development: https://localhost:5001/swagger
- Production: [URL production]/swagger

## Database
### Connection Strings
- **Development**: `TuyenDanQuan_Dev` database
- **Production**: Cấu hình trong appsettings.Production.json

### Entity Framework Migration
```bash
# Tạo migration mới
dotnet ef migrations add TenMigration --project EFCore --startup-project TuyenDanQuan

# Cập nhật database
dotnet ef database update --project EFCore --startup-project TuyenDanQuan
```

## CI/CD
GitHub Actions tự động:
- Build và test khi push/PR vào nhánh `dev`
- Thiết lập môi trường development
- Kiểm tra code quality

## Troubleshooting

### Không thể push lên nhánh dev
```bash
# Kiểm tra nhánh hiện tại
git branch

# Chuyển sang nhánh dev
git checkout dev

# Pull latest changes
git pull origin dev

# Push changes
git push origin dev
```

### Build errors
```bash
# Clean solution
dotnet clean

# Restore packages
dotnet restore

# Rebuild
dotnet build
```

## Liên hệ
- Repository: https://github.com/CongKunn1/TuyenDanQuan
- Issues: https://github.com/CongKunn1/TuyenDanQuan/issues