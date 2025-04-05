using ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Project.COMMON.Tools;
using System;
using Microsoft.Extensions.DependencyInjection;
using Project.ecommerce.EmailService;
using ecommerce.EmailService;




var builder = WebApplication.CreateBuilder(args);


// Connection String'i appsettings.json'dan al ve PostgreSQL'e baðlan

builder.Services.AddDbContext<EcommerceDbContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServices();//kullanýcýnýn kimlik doðrulama iþlemlerini ve güvenli bir oturum yönetimi yapmasýný saðlar.

builder.Services.AddTransient<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseAuthorization();



app.Run();




