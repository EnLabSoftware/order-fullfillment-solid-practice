using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrderFullfillment.Application.Services;
using OrderFullfillment.Application.Services.Interfaces;
using OrderFullfillment.Infrastructure;
using OrderFullfillment.Infrastructure.SeedWorks;

namespace OrderFullfillment.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "OderFullfillment", Version = "v1"});
            });
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(_configuration["ConnectionString"]));

            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IBasketService, BasketService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OderFullfillment v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}