using SIDOK.Repository.Context;
using SIDOK.Repository.Interface;
using SIDOK.Repository.Repository;
using SIDOK.Service;
using SIDOK.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<ISpesialisasiRepository, SpesialisasiRepository>();
builder.Services.AddScoped<IDokterRepository, DokterRepository>();
builder.Services.AddScoped<IJadwalJagaRepository, JadwalJagaRepository>();
builder.Services.AddScoped<IPoliRepository, PoliRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
