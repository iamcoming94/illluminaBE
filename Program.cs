using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using pb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatherForecast API", Version = "v1" });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});



builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddDbContext<dbContext>(ServiceLifetime.Transient);

builder.Services.AddScoped<IPhoneBookInterface, PhoneBookService>();

ServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
dbContext dbContext = serviceProvider.GetService<dbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
