using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncInn
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Constructs startup object and maps Configuration
        /// </summary>
        /// <param name="configuration"> config properties set </param>
        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        /// <summary>
        /// loads required dependencies and database build instructions (context and conn string)
        /// </summary>
        /// <param name="services"> collection of service descriptors </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<AsyncInnDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProductionConnection")));

            // TODO: Register DB interface & service
            services.AddScoped<IAmenity, AmenityService>();
            services.AddScoped<IHotel, HotelService>();
            services.AddScoped<IRoomPlan, RoomPlanService>();

        }

        /// <summary>
        /// configures HTTP request pipeline
        /// </summary>
        /// <param name="app"> mechanisms to configure request pipeline </param>
        /// <param name="env"> defn of hosting environment </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
