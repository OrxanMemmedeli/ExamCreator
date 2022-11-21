using Business.Validations;
using DataAccess.Concrete.Context;
using ExamCreator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<DbContext>();
builder.Services.AddControllersWithViews().AddFluentValidation(config => {
    config.ConfigureClientsideValidation(enabled: false);
    config.ImplicitlyValidateChildProperties = true;
    config.DisableDataAnnotationsValidation = true;
    config.ImplicitlyValidateRootCollectionElements = true;
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Register(); //dependence ucun
builder.Services.Validators(); // validation ucun
//builder.Services.AddFluentValidationClientsideAdapters(); // Clinet teref ucun auto mehdudiyyet

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "area",
        pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
