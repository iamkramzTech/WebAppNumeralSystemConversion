using Microsoft.AspNetCore.Builder;

namespace NumeralSystemConverterWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
          //  services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment environment)
        {
            
            if(environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();
            app.UseStaticFiles();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name:"default",
            //        template:"{controller=Home}/{action=Index}/{id?}");
            //});
            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllerRoute(
                    name:"default",
                    pattern:"{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
