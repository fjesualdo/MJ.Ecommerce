﻿using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MJ.Solutions.Catalogo.API.Models;
using MJ.Solutions.Core.Data;
using MJ.Solutions.Core.Messages;
using System.Linq;
using System.Threading.Tasks;

namespace MJ.Solutions.Catalogo.API.Data
{
	public class CatalogoContext : DbContext, IUnitOfWork
	{
		public CatalogoContext(DbContextOptions<CatalogoContext> options)
				: base(options) { }

		public DbSet<Produto> Produtos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Ignore<ValidationResult>();
			modelBuilder.Ignore<Event>();

			foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
					e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.SetColumnType("varchar(100)");

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
		}

		public async Task<bool> Commit()
		{
			return await base.SaveChangesAsync() > 0;
		}
	}
}
