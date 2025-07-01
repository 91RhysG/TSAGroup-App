using Microsoft.EntityFrameworkCore;
using TSAGroup_Tec.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("AppInMemoryDb"));

var app = builder.Build();

// Seed the in-memory database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbInit.SeedData(dbContext);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();