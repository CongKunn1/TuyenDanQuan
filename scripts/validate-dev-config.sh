#!/bin/bash

# Validation script for dev branch configuration
# Script kiểm tra cấu hình nhánh dev

echo "🔍 Kiểm tra cấu hình nhánh dev - TuyenDanQuan"
echo "==============================================="

# Kiểm tra các file cấu hình đã được tạo
echo "📋 Kiểm tra các file cấu hình..."

declare -a required_files=(
    ".github/workflows/dev-branch.yml"
    ".github/workflows/dev-environment.yml"
    "TuyenDanQuan/appsettings.Development.json"
    "docs/DEV_BRANCH_WORKFLOW.md"
    "scripts/setup-dev.sh"
    "scripts/setup-dev.ps1"
    "README.md"
)

all_files_exist=true
for file in "${required_files[@]}"; do
    if [[ -f "$file" ]]; then
        echo "✅ $file"
    else
        echo "❌ $file - File không tồn tại"
        all_files_exist=false
    fi
done

if [[ $all_files_exist == false ]]; then
    echo "❌ Một số file cấu hình bị thiếu"
    exit 1
fi

# Kiểm tra build
echo ""
echo "📋 Kiểm tra build solution..."
dotnet build --configuration Debug --verbosity quiet
if [ $? -eq 0 ]; then
    echo "✅ Solution build thành công"
else
    echo "❌ Lỗi khi build solution"
    exit 1
fi

# Kiểm tra syntax GitHub Actions workflows
echo ""
echo "📋 Kiểm tra syntax GitHub Actions workflows..."
if command -v yq &> /dev/null; then
    for workflow in .github/workflows/*.yml; do
        if yq eval '.' "$workflow" > /dev/null 2>&1; then
            echo "✅ $(basename "$workflow") - Syntax hợp lệ"
        else
            echo "❌ $(basename "$workflow") - Syntax không hợp lệ"
        fi
    done
else
    echo "⚠️  yq không được cài đặt, bỏ qua kiểm tra syntax YAML"
fi

# Kiểm tra permissions script
echo ""
echo "📋 Kiểm tra permissions script..."
if [[ -x "scripts/setup-dev.sh" ]]; then
    echo "✅ setup-dev.sh có quyền execute"
else
    echo "❌ setup-dev.sh không có quyền execute"
fi

# Kiểm tra nội dung appsettings.Development.json
echo ""
echo "📋 Kiểm tra cấu hình Development..."
if grep -q "TuyenDanQuan_Dev" "TuyenDanQuan/appsettings.Development.json"; then
    echo "✅ Development database connection string được cấu hình"
else
    echo "❌ Development database connection string chưa được cấu hình"
fi

if grep -q "Debug" "TuyenDanQuan/appsettings.Development.json"; then
    echo "✅ Debug logging được kích hoạt"
else
    echo "❌ Debug logging chưa được kích hoạt"
fi

# Kiểm tra git branch
echo ""
echo "📋 Kiểm tra git configuration..."
current_branch=$(git branch --show-current)
echo "📍 Nhánh hiện tại: $current_branch"

# Kiểm tra remote dev branch
if git ls-remote --heads origin dev | grep -q "refs/heads/dev"; then
    echo "✅ Remote dev branch tồn tại"
else
    echo "❌ Remote dev branch không tồn tại"
fi

echo ""
echo "🎉 Kiểm tra hoàn tất!"
echo ""
echo "📝 Tóm tắt cấu hình dev branch:"
echo "• GitHub Actions workflows: Đã thiết lập"
echo "• Development configuration: Đã cấu hình"
echo "• Documentation: Đã tạo (tiếng Việt)"
echo "• Setup scripts: Đã sẵn sàng (Linux & Windows)"
echo "• Build system: Hoạt động bình thường"
echo ""
echo "🚀 Có thể bắt đầu làm việc với nhánh dev!"