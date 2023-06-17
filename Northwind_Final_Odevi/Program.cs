using System.ComponentModel;
using Class;
using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Northwind_Final_Odevi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHelper<Categories>, CategoryiesEntity>();
builder.Services.AddSingleton<IHelperCustomers<Customers>, CustomersEntity>();
builder.Services.AddSingleton<IHelper<Employees>, EmployeesEntity>();
builder.Services.AddSingleton<IHelper<Order_Details>, Order_Details_Entity>();
builder.Services.AddSingleton<IHelper<Orders>, OrdersEntity>();
builder.Services.AddSingleton<IHelper<Products>, ProductsEntity>();


builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("User", op => op.RequireClaim("User"));
    op.AddPolicy("Admin", op => op.RequireClaim("Admin"));
}

);

builder.Services.AddMvc(p => p.EnableEndpointRouting = false);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMvcWithDefaultRoute();
app.MapRazorPages();

app.Run();
