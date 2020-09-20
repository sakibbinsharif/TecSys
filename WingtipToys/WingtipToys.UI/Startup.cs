using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WingtipToys.BLL;
using WingtipToys.BLL.Interfaces.IRepositories;
using WingtipToys.BLL.Interfaces.IServices;
using WingtipToys.BLL.Services;
using WingtipToys.DAL;
using WingtipToys.DAL.Repositories;

namespace WingtipToys.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configSection = Configuration.GetSection("ConfigSettings");
            var configValue = configSection.Get<ConfigSettings>();

            services.Configure<ConfigSettings>(configSection);
            // Adding it as singleton to collect the config on dependency register
            services.AddSingleton<ConfigSettings>(configValue);
            RegisterDependencies(services);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/Home/Error");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private IServiceCollection RegisterDependencies(IServiceCollection services)
        {
            var config = services.SingleOrDefault(x => x.ServiceType == typeof(ConfigSettings))
                                .ImplementationInstance as ConfigSettings;

            services.AddDbContext<WingtipToysContext>(x => x.UseSqlServer(config.WingTipToysDbConnection));

            #region Repositories
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            #endregion

            #region Business Services
            services.AddTransient<IProductService, ProductService>();
            #endregion

            return services;
        }
    }
}
