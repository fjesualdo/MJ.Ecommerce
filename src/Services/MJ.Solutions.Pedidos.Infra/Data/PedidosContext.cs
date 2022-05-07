using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MJ.Solutions.Core.Data;
using MJ.Solutions.Core.Domain;
using MJ.Solutions.Core.Mediator;
using MJ.Solutions.Core.Messaging;
using MJ.Solutions.Pedidos.Domain;
using MJ.Solutions.Pedidos.Domain.Pedidos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MJ.Solutions.Pedidos.Infra.Data
{
	public class PedidosContext : DbContext, IUnitOfWork
	{
		private readonly IMediatorHandler _mediatorHandler;

		public PedidosContext(DbContextOptions<PedidosContext> options, IMediatorHandler mediatorHandler) : base(options)
		{
			_mediatorHandler = mediatorHandler;
		}

		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<PedidoItem> PedidoItens { get; set; }
		public DbSet<Voucher> Vouchers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
				e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.SetColumnType("varchar(100)");

			modelBuilder.Ignore<Event>();
			modelBuilder.Ignore<ValidationResult>();

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidosContext).Assembly);

			foreach (var relationship in modelBuilder.Model.GetEntityTypes()
				.SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

			modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);

			base.OnModelCreating(modelBuilder);
		}

		public async Task<bool> Commit()
		{
			foreach (var entry in ChangeTracker.Entries()
							 .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property("DataCadastro").CurrentValue = DateTime.Now;
				}

				if (entry.State == EntityState.Modified)
				{
					entry.Property("DataCadastro").IsModified = false;
				}
			}

			var sucesso = await base.SaveChangesAsync() > 0;

			if (sucesso) await _mediatorHandler.PublicarEventos(this);

			return sucesso;
		}
	}

	public static class MediatorExtension
	{
		public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
		{
			var domainEntities = ctx.ChangeTracker
					.Entries<Entity>()
					.Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

			var domainEvents = domainEntities
					.SelectMany(x => x.Entity.Notificacoes)
					.ToList();

			domainEntities.ToList()
					.ForEach(entity => entity.Entity.ClearDomainEvents());

			var tasks = domainEvents
					.Select(async (domainEvent) =>
					{
						await mediator.PublishEvent(domainEvent);
					});

			await Task.WhenAll(tasks);
		}
	}
}
