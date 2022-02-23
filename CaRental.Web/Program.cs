using AspNetCoreHero.ToastNotification;
using CaRental.Web.Database.Contracts;
using CaRental.Web.Database.Data;
using CaRental.Web.Database.Services;

var builder = WebApplication.CreateBuilder(args);

// Add razor runtime compilation
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register database service
var userRepository = new UserRepository();
var carRepository = new CarRepository();
var rentalRepository = new RentalRepository();
var databaseService = new DatabaseService(userRepository, carRepository, rentalRepository);
builder.Services.AddSingleton<IDatabaseService>(databaseService);

// Configure notificatio nservice
builder.Services.AddNotyf(config => {
    config.DurationInSeconds = 3;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});

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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
