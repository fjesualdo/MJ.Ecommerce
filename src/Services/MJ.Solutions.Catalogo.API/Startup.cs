using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MJ.Solutions.Catalogo.API.Data;
using MJ.Solutions.Catalogo.API.Data.Repository;
using MJ.Solutions.Catalogo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MJ.Solutions.Catalogo.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IHostEnvironment hostEnvironment)
		{
			var builder = new ConfigurationBuilder()
					.SetBasePath(hostEnvironment.ContentRootPath)
					.AddJsonFile("appsettings.json", true, true)
					.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
					.AddEnvironmentVariables();

			if (hostEnvironment.IsDevelopment())
			{
				builder.AddUserSecrets<Startup>();
			}

			Configuration = builder.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<CatalogoContext>(optionsAction: options =>
			{
				options.UseSqlServer(Configuration.GetConnectionString(name: "DefaultCOnnection"));
			});

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "MJ.Solutions.Catalogo.API", Version = "v1" });
			});

			services.AddScoped<IProdutoRepository, ProdutoRepository>();
			services.AddScoped<CatalogoContext>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MJ.Solutions.Catalogo.API v1"));
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
