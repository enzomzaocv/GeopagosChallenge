using TennisTournament.Model.Dtos;
using TennisTournament.Model.Entities;

namespace TennisTournament.Repository
{
	public interface ITournamentRepository : IRepository<Tournament>
	{
		Task<(int count, List<DtoTournament> tournaments)> SearchTournamentAsync(DtoSearchTournamentRequest request);
	}
}