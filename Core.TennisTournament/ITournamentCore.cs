using TennisTournament.Model.Dtos;

namespace TennisTournament.Core
{
	public interface ITournamentCore
	{
		Task<DtoPlayTournamentResponse> PlayTournamentAsync(DtoPlayTournamentRequest request);
		Task<DtoSearchTournamentResponse> SearchTournamentAsync(DtoSearchTournamentRequest request);
	}
}