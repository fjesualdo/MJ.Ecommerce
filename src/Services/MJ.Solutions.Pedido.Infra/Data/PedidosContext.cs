using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MJ.Solutions.Core.Data;
using MJ.Solutions.Core.Mediator;
using MJ.Solutions.Core.Messages;
using System.Linq;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedido.Infra.Data
{
	public class PedidosContext : DbContext, IUnitOfWork
	{
		private readonly IMediatorHandler _mediatorHandler;

		public PedidosContext(DbContextOptions<PedidosContext> options, IMediatorHandler mediatorHandler)
				: base(options)
		{
			_mediatorHandler = mediatorHandler;
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
				e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.SetColumnType("varchar(100)");

			modelBuilder.Ignore<Event>();
			modelBuilder.Ignore<ValidationResult>();

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosContext).Assembly);

			base.OnModelCreating(modelBuilder);
		}

		public async Task<bool> Commit()
		{
			var sucesso = await base.SaveChangesAsync() > 0;
			//if (sucesso) await _mediatorHandler.PublicarEventos(this);

			return sucesso;
		}
	}
}
