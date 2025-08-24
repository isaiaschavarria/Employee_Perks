namespace EmployeePerks_Isaias_UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Habilitar el HTTPContext
            builder.Services.AddHttpContextAccessor();

            //Agregar un manejo de sesion

            builder.Services.AddSession(options => { 
                options.IdleTimeout = TimeSpan.FromSeconds(60);
                options.Cookie.Name = "EmployeePerks_Cookie";
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = false;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseSession();

            app.Run();
        }
    }
}
