using Microsoft.EntityFrameworkCore;
using ProductApplication.Models;
using ProductAppAsync.src.config.DB;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;
builder.Services.AddScoped<UsersServices>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UsersServices>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserManagementDb"));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

