
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopping_cart.Models;
using Shopping_cart.Models.Databases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICustomer, Customer>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Dbcontextr>();
builder.Services.AddDbContext<Dbcontextr>(optionBuilder => { optionBuilder.UseSqlServer("Data Source=LAPTOP-HD9LIS85;Initial Catalog=Test;TrustServerCertificate=true;Integrated Security=True;Pooling=False"); });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//builder.Services.AddDbContext<Dbcontextr>(optionBuilder => { optionBuilder.UseSqlServer("Data Source=LAPTOP-HD9LIS85;Initial Catalog=Test;TrustServerCertificate=true;Integrated Security=True;Pooling=False"); });

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=LogIn}");

app.Run();
