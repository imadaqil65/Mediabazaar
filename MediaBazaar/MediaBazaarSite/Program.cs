using Domain.EmployeeServices;
using Domain.Interfaces;
using Domain.WorkShiftServices;
using Infrastructure;
using Infrastructure.WorkShift;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<EmployeeServices>();
builder.Services.AddScoped<IEmployeeDB, EmployeeRepository>();
builder.Services.AddScoped<WorkShiftServices>();
builder.Services.AddScoped<IShiftDB, WorkShiftRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<RequestService>();
builder.Services.AddScoped<IRequestDB, RequestRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = new PathString("/Login");
    options.AccessDeniedPath = new PathString("/AccessDenied");
}
);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
