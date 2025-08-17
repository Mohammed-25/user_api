var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddControllers();
Bulder.services.AddDBContext<AppDbCotext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserManagementDb")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

