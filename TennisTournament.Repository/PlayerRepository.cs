using Microsoft.EntityFrameworkCore;
using TennisTournament.DataBaseContext;
using TennisTournament.Model.Entities;

namespace TennisTournament.Repository
{
	public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
	{
		private readonly TennisTournamentDbContext _context;

		public PlayerRepository(TennisTournamentDbContext context) : base(context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieves a list of players by its identification number.
		/// </summary>
		/// <param name="players">
		///		<para>An players identification numbers list.</para>
		///	</param>
		/// <returns>A <see cref="Player"/> list.</returns>
		public async Task<List<Player>> GetByNameAsync(List<string> players, int gender)
		{
			return await _context.Player
				.Where(p => players.Contains(p.Name) && p.Gender == gender)
				.Include(p => p.Skills).ThenInclude(q => q.SkillType)
				.ToListAsync();
		}
	}
}
