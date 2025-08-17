using Microsoft.EntityFrameworkCore;
using System;

// Remove the incorrect using directive causing CS0426
// using EFCore.Data;
// Remove the incorrect using directive causing CS0426
// using EFCore.Data;
using TuyenDanQuan.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(option =>
{
    var x = builder.Configuration.GetConnectionString("DefaultConnection");
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Remove or correct the problematic using directive.
    // The error CS0426 occurs because 'EFCore.Data' does not exist in the type 'EFCore'.
    // If you intended to use a namespace, ensure it exists and is spelled correctly.
    // If your AppDbContext is in a different namespace, use that instead.

}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
