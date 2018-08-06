using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuynSell.DataAccess.Model
{
	public class BuyNSellContext : DbContext
	{

		public BuyNSellContext()
            : base("name=BuyNSellContext")
        {
		}
		public DbSet<User> Users { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Item> Items { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Admin>().ToTable("Admins");
			modelBuilder.Entity<Client>().ToTable("Clients");
		}
	}
}
