# Contributing to TuyenDanQuan

Thank you for your interest in contributing to TuyenDanQuan! This document provides guidelines for contributing to this project.

## 🤝 How to Contribute

### Reporting Issues

Before creating an issue, please:
1. Check existing issues to avoid duplicates
2. Use a clear and descriptive title
3. Provide detailed information about:
   - Steps to reproduce the issue
   - Expected behavior
   - Actual behavior
   - Environment details (.NET version, OS, etc.)

### Suggesting Enhancements

Enhancement suggestions are welcome! Please:
1. Use a clear and descriptive title
2. Explain the enhancement in detail
3. Describe the current behavior and why it should be changed
4. Consider the impact on existing functionality

### Pull Requests

1. **Fork the repository** and create your branch from `master`
2. **Follow coding standards** (see below)
3. **Test your changes** thoroughly
4. **Update documentation** if needed
5. **Ensure CI passes** (build and tests)
6. **Write clear commit messages**

#### Branch Naming Convention
- `feature/description` - for new features
- `bugfix/description` - for bug fixes
- `docs/description` - for documentation updates
- `refactor/description` - for code refactoring

#### Commit Message Guidelines
- Use present tense ("Add feature" not "Added feature")
- Use imperative mood ("Move cursor to..." not "Moves cursor to...")
- Limit first line to 50 characters
- Reference issues and pull requests when applicable

## 🛠️ Development Setup

1. Clone your fork:
   ```bash
   git clone https://github.com/your-username/TuyenDanQuan.git
   cd TuyenDanQuan
   ```

2. Install dependencies:
   ```bash
   dotnet restore
   ```

3. Build the solution:
   ```bash
   dotnet build
   ```

4. Run the application:
   ```bash
   cd TuyenDanQuan
   dotnet run
   ```

## 📝 Coding Standards

### C# Guidelines
- Follow [Microsoft C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods small and focused
- Use async/await for I/O operations

### Code Formatting
- Use 4 spaces for indentation
- Place opening braces on new lines
- Use camelCase for local variables and parameters
- Use PascalCase for public members and types

### Entity Framework
- Use meaningful migration names
- Always test migrations in both directions (up and down)
- Follow naming conventions for entities and properties

## 🧪 Testing

- Write unit tests for new functionality
- Ensure all tests pass before submitting PR
- Test edge cases and error scenarios
- Update tests when modifying existing functionality

## 📋 Code Review Process

1. All submissions require review
2. Reviewers will check for:
   - Code quality and standards compliance
   - Test coverage
   - Documentation updates
   - Breaking changes
3. Address review feedback promptly
4. Maintainers may suggest changes or improvements

## 🚀 Release Process

- Releases follow semantic versioning (SemVer)
- Major releases may include breaking changes
- Minor releases add new features
- Patch releases fix bugs

## 📞 Getting Help

- Open an issue for questions about contributing
- Review existing issues and pull requests
- Check the project documentation

## 📜 Code of Conduct

- Be respectful and inclusive
- Welcome newcomers and help them learn
- Focus on constructive feedback
- Respect different opinions and approaches

Thank you for contributing to TuyenDanQuan! 🎉