using Business;
using CoreLayer;
using DataAccess;
using ExamCreator;
using ExamCreator.Middlewares;
using ExamCreator.Utilities.PropertyTranslateAndSave;
using ExamCreator.Utilities.ViewGenerator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<DbContext>();
builder.Services.AddControllersWithViews();

//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(options =>
//    {
//        options.ConfigureClientsideValidation(enabled: true);
//        options.ImplicitlyValidateChildProperties = false;
//    })
//    .ConfigureApiBehaviorOptions(options =>
//    {
//        options.SuppressModelStateInvalidFilter = true;
//    });


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>
//{
//    o.ExpireTimeSpan = TimeSpan.FromMinutes(120);
//    o.LoginPath = "/Account/Login";
//    o.LogoutPath = "/Account/LogOut";
//    o.AccessDeniedPath = "/Account/Denied"; //Role uyğun olmadıqda yonelmeni temin edecekdir.
//    o.SlidingExpiration = true;
//}); //Routing Login

builder.Services.Register(); //dependence ucun
builder.Services.CoreServiceRegister(); //core layer dependence
builder.Services.BusinessServiceRegister(); //business
builder.Services.Validators(); // validation ucun

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.


    app.UseGlobalErrorHandling(); // custom middleware for error and log saveing

    app.UseHsts();


    //app.UseAutoGenerateViewMiddleware();

}
app.GenerateViews(app.Environment);
app.UpdateResourceFile(app.Environment);
//app.UseDbTransaction(); // Tranzaksiya 

app.DALAppRegister();
app.UseApp();

//app.AddGlobalErrorHandling(); //test

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
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
