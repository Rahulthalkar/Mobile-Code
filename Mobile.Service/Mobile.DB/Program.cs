using Microsoft.EntityFrameworkCore;
using Mobile.DB;

var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("MB");
builder.Services.AddDbContext<MobileDBContext>(options =>
{
    options.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.Run();
