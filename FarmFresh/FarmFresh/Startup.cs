using FarmFresh.Application.Interfaces.Repositories;
using FarmFresh.Application.Interfaces.Services;
using FarmFresh.Infrastructure.Data;
using FarmFresh.Infrastructure.Repositories;
using FarmFresh.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace FarmFresh
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
			services.AddDbContext<DataContext>((options =>
			options
				.UseSqlServer(Configuration.GetConnectionString("TestConnection"))
			));
			services.AddCors();
			services.AddControllers().AddNewtonsoftJson(options =>
			options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "FarmFresh", Version = "v1" });
			});
			// configure DI for application services
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductDetailService, ProductDetailService>();
			services.AddScoped<IProductTypeService, ProductTypeService>();
			//configure repositories
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
			services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FarmFresh v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			// global cors policy
			app.UseCors(builder =>
			{
				var origins = this.Configuration.GetSection("AllowedOrigins").Get<string[]>();
				if (origins == null)
				{
					throw new ArgumentNullException("AllowedOrigins", "Missing 'AllowedOrigins' in appSettings.json (string array of domains).");
				}

				builder
					.WithOrigins(origins)
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
			});

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
