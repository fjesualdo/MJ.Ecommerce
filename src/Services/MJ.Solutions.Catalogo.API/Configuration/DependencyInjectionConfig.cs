using Microsoft.Extensions.DependencyInjection;
using MJ.Solutions.Catalogo.API.Data;
using MJ.Solutions.Catalogo.API.Data.Repository;
using MJ.Solutions.Catalogo.API.Models;

namespace MJ.Solutions.Catalogo.API.Configuration
{
	public static class DependencyInjectionConfig
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IProdutoRepository, ProdutoRepository>();
			services.AddScoped<CatalogoContext>();
		}
	}
}
