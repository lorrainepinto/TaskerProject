using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskerProject.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskerProject.Data.Data
{
	public class TasksContext : DbContext
	{
		public DbSet<Tasks> Tasks { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=sexy\sql2024;Initial Catalog=TasksDB;TrustServerCertificate=True;Trusted_Connection=True;");
		}
	}
}
