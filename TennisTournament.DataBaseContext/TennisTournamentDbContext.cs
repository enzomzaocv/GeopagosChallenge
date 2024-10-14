using Microsoft.EntityFrameworkCore;
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
			optionsBuilder.UseSqlServer("");
		}

		public DbSet<Match> Match {  get; set; }
		public DbSet<Player> Player { get; set; }
		public DbSet<Skill> Skill { get; set; }
		public DbSet<Tournament> Tournament { get; set; }
	}
}
