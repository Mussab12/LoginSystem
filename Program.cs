using IdentityServer3.Core.Services;
using LoginSystem.Models.Domain;
using LoginSystem.Repositories.Abstract;
using LoginSystem.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".LoginSystem.Session";
    
    options.Cookie.IsEssential = true;
});
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

    // For Identity  
    builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
        .AddEntityFrameworkStores<DatabaseContext>()
        .AddDefaultTokenProviders();    

    builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");
    //add services to container
    builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
    builder.Services.AddScoped<UserManager<ApplicationUser>>();

builder.Services.AddScoped<IUserService, MyUserService>();



builder.Services.AddApplicationInsightsTelemetry();
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
    app.UseAuthentication();
    app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");

    app.Run();
