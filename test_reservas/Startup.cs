using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_reservas.Data;
using test_reservas.Repository.IRepository;
using test_reservas.Repository;
using test_reservas.Models;
using test_reservas.Models.DTO;

namespace test_reservas
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<Swagger.OptionalRouteParameters.Filters.ReApplyOptionalRouteParameterOperationFilter>();               
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "test_reservas", Version = "v1" });
            });

            services.AddDbContext<test_reservasContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("test_reservasContext")));
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Reserva, ReservaDTO>();
                configuration.CreateMap<ReservaDTO, Reserva>();
            }, typeof(Startup));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "test_reservas v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
