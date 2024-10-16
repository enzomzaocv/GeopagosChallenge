using Microsoft.EntityFrameworkCore;
using TennisTournament.DataBaseContext;
using TennisTournament.Model.Dtos;
using TennisTournament.Model.Entities;

namespace TennisTournament.Repository
{
	public class TournamentRepository : BaseRepository<Tournament>, ITournamentRepository
	{
		private readonly TennisTournamentDbContext _context;

		public TournamentRepository(TennisTournamentDbContext context) : base(context)
		{
			_context = context;
		}

		/// <summary>
		/// Retrieves a tournament list from the database.
		/// </summary>
		/// <param name="request">
		///		<para>Values to search for.</para>
		///	</param>
		/// <returns>A <see cref="DtoTournament"/> list.</returns>
		public async Task<(int count, List<DtoTournament> tournaments)> SearchTournamentAsync(DtoSearchTournamentRequest request)
		{
			var query = _context.Tournament
				.Where(p =>
					(string.IsNullOrWhiteSpace(request.Winner) || p.Winner.Name == request.Winner)
					&& (!request.GenderValue.HasValue || p.Gender == request.GenderValue.Value)
					&& (!request.DateValue.HasValue || p.Date.Date == request.DateValue.Value.Date));

			var count = await query.CountAsync();

			var tournaments = await query
				.Select(p => new DtoTournament
				{
					Winner = p.Winner.Name,
					Date = p.Date
				})
				.ToListAsync();

			return (count, tournaments);
		}
	}
}
