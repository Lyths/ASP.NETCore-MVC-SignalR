using JournalSite.Data;
using JournalSite.Data.Interfaces.Abstract;
using JournalSite.Data.Interfaces.EF;
using JournalSite.Hubs;
using JournalSite.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);


//Настраивается жизненный цикл зависимостей
builder.Services.AddTransient<IPostItems, EFPostItem>();
builder.Services.AddTransient<IGroup, EFGroup>();
builder.Services.AddTransient<IMessage, EFMessage>();
builder.Services.AddTransient<IArticle, EFArticle>();
builder.Services.AddTransient<IFile, EFFIle>();
builder.Services.AddTransient<IArchive_year, EFArchive_year>();
builder.Services.AddTransient<IArchive_number, EFArchive_number>();
builder.Services.AddTransient<IArchive_articles, EFArchive_articles>();
builder.Services.AddTransient<DataManager>();

//Получаем строку подключения к БД
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

//добавляем контекст AppDBContext в качестве сервиса приложения
builder.Services.AddDbContext<AppDBContext>(x => x.UseSqlServer(connection));
//подключаем службу библиотеки SignalR
builder.Services.AddSignalR();

//Настройка Identity системы
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail= true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();

//Настройка Cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "JournalSiteAuth";
    options.Cookie.HttpOnly= true;
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath= "/Account/AccessDenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
});

//Настройка политики авторизации для области admin
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
});

builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
});

//Настройка политики авторизации для области moderator
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("ModeratorArea", policy => { policy.RequireRole("moderator"); });
});

builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new ModeratorAreaAuthorization("Moderator", "ModeratorArea"));
});

//Настройка политики авторизации для области user
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("UserArea", policy => { policy.RequireRole("user"); });
});

builder.Services.AddControllersWithViews(x =>
{
    x.Conventions.Add(new UserAreaAuthorization("User", "UserArea"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "user",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "moderator",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chat");

app.Run();
