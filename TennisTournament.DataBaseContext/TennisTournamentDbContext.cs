using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TennisTournament.Model.Entities;

namespace TennisTournament.DataBaseContext
{
	public class TennisTournamentDbContext : DbContext
	{
		public TennisTournamentDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile("appsettings.json")
			.Build();

			optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		}

		public DbSet<Match> Match { get; set; }
		public DbSet<Player> Player { get; set; }
		public DbSet<Skill> Skill { get; set; }
		public DbSet<SkillType> SkillType { get; set; }
		public DbSet<Tournament> Tournament { get; set; }
	}
}
