using eTickets_Live.Data;
using eTickets_Live.Data.Interfaces;
using eTickets_Live.Data.Services;
using eTickets_Live.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews(); // Controllerlar�n View lar� olmas� gerekti�ini bildiriyor.

        // AppDBContext tan�mlar�m�n enjecte edilmesi (Depenceny Injection - DI) (GetConnectionStrings - appsettings.json dan okuyor)

        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

        // Services Configuration
        builder.Services.AddScoped<IActorsService, ActorsService>(); // Actors servisinin registire edilmesi
        builder.Services.AddScoped<IProducersService, ProducersService>(); // Producers servisinin register edilmesi
        builder.Services.AddScoped<ICinemasService, CinemasService>(); // Cinemas servisinin register edilmesi
        builder.Services.AddScoped<IMoviesService, MoviesService>(); // Movies servisinin register edilmesi

        // Authentication ve Authorization serviceleri
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddMemoryCache();
        builder.Services.AddSession();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
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

        app.UseAuthentication(); // sayfalar�n kullan�c� duruma g�re kimlik do�rulamas�
        app.UseAuthorization(); // sayfalar�n kullan�c� duruma g�re yetkilendirilmesi

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Movies}/{action=Index}/{id?}");

        // Program �al��madan �nce haz�rlanm�� olan test datas�n�n VT ye g�nderilmesi
        AppDBInitializer.Seed(app);
        // User bilgilerinin db ye g�nderilmesi
        
        AppDBInitializer.SeedUsersAndRolesAsync(app).Wait();

        app.Run();
    }
}