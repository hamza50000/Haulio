using FarmFresh.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmFresh.Infrastructure.Data
{
	public class DataContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductDetail> ProductDetails { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductDetail>()
				.HasOne(b => b.Product)
				.WithOne(i => i.ProductDetail)
				.HasForeignKey<Product>(b => b.ProductDetailId);
		}
	}
}