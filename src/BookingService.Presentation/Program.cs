using BookingService.Application.Interfaces;
using BookingService.Application.Interfaces.JWT;
using BookingService.Application.Interfaces.PasswordHasher;
using BookingService.Application.Mappings;
using BookingService.Application.Service.Resource;
using BookingService.Application.Service.User;
using BookingService.Domain.Interfaces;
using BookingService.Infrastructure;
using BookingService.Infrastructure.JWT;
using BookingService.Infrastructure.Persistance;
using BookingService.Infrastructure.Persistance.Repositories;
using BookingService.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using IResourceService = System.ComponentModel.Design.IResourceService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddOpenApi();
builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<BookingService.Application.Interfaces.IResourceService, ResourceService>();
builder.Services.AddScoped<IBookingService, BookingService.Application.Service.Booking.BookingService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPassworHasher, PasswordHasher>();
builder.Services.AddScoped<ITokenGenerator, JwtGenerator>();
builder.Services.Configure<AuthSettings>(
    builder.Configuration.GetSection("AuthSettings"));  
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<BookingProfile>();
    cfg.AddProfile<ResourceProfile>();
    cfg.AddProfile<UserProfile>();
});
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();