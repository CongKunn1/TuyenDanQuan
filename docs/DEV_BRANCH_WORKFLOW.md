# Development Branch Workflow

## Cấu hình nhánh dev - Development Branch Configuration

### Mục đích
Nhánh `dev` được thiết lập để phát triển và thử nghiệm các tính năng mới trước khi merge vào nhánh chính.

### Quy trình làm việc

#### 1. Làm việc với nhánh dev
```bash
# Chuyển sang nhánh dev
git checkout dev

# Cập nhật nhánh dev từ remote
git pull origin dev

# Tạo nhánh feature mới từ dev
git checkout -b feature/ten-tinh-nang

# Sau khi hoàn thành feature
git add .
git commit -m "Add: Mô tả tính năng"
git push origin feature/ten-tinh-nang

# Tạo Pull Request từ feature branch vào dev
```

#### 2. Đẩy code lên nhánh dev
```bash
# Đảm bảo bạn đang ở nhánh dev
git checkout dev

# Thêm files mới hoặc đã thay đổi
git add .

# Commit với message rõ ràng
git commit -m "feat: Mô tả thay đổi"

# Đẩy lên remote repository
git push origin dev
```

### Cấu hình CI/CD

#### GitHub Actions được thiết lập:
- **dev-branch.yml**: Tự động build và test khi có push/PR vào nhánh dev
- **dev-environment.yml**: Thiết lập môi trường development

#### Môi trường Development:
- Database: `TuyenDanQuan_Dev`
- Logging level: Debug
- Swagger UI: Enabled
- Detailed errors: Enabled

### Quy tắc làm việc

1. **Luôn pull trước khi push**
   ```bash
   git pull origin dev
   ```

2. **Kiểm tra build trước khi push**
   ```bash
   dotnet build
   ```

3. **Viết commit message rõ ràng**
   - `feat:` cho tính năng mới
   - `fix:` cho bug fix
   - `refactor:` cho code refactoring
   - `docs:` cho documentation

4. **Không push trực tiếp vào master**
   - Luôn làm việc trên nhánh dev hoặc feature branch
   - Tạo Pull Request để merge vào master

### Khắc phục sự cố

#### Nếu không thể push lên dev branch:

1. **Kiểm tra quyền repository**
2. **Đảm bảo đang ở đúng nhánh**
   ```bash
   git branch
   ```
3. **Pull latest changes**
   ```bash
   git pull origin dev
   ```
4. **Resolve conflicts nếu có**
5. **Thử push lại**
   ```bash
   git push origin dev
   ```

#### Nếu gặp lỗi merge conflict:
```bash
# Pull latest changes
git pull origin dev

# Resolve conflicts in files
# Edit files to fix conflicts

# Add resolved files
git add .

# Commit merge
git commit -m "resolve: Merge conflicts"

# Push changes
git push origin dev
```

### Liên hệ
Nếu vẫn gặp vấn đề với việc push code lên nhánh dev, hãy kiểm tra:
- Quyền access repository
- Network connectivity
- Git credentials
- Branch protection rules (nếu có)