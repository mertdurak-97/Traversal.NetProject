using BusinessLayer.Extensions;
using DataAccessLayer.Context;
using EntityLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Traversal.NetProject.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession();

builder.Services.AddDbContext<AddDbContext>(); // �dentity yap�land�rmas�n� aktif etmek ve proje seviyesinde authentication sa�lamak ad�na yaz�lm�� servis
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AddDbContext>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<AddDbContext>(); // �dentity yap�land�rmas�n� aktif etmek

builder.Services.ExtensionsDependencies(); //AddScope

builder.Services.AddAutoMapper(typeof(Program)); //AutoMapper Configurations
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//AutoMapper Configurations (Hayati �nem!)

builder.Services.CustomerValidator();//FluentValidator

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = new PathString("/Login/AccessDeniedd"); //AccessDenied
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder() //Proje seviyesinde Authentication sa�lamak
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/Login/Index";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "{controller=Login}/{action=SignUp}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Destination}/{action=Index}/{id?}"
    );
});

app.Run();
