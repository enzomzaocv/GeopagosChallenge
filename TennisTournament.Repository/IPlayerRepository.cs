using TennisTournament.Model.Entities;

namespace TennisTournament.Repository
{
	public interface IPlayerRepository
	{
		Task<List<Player>> GetByIdentificationNumberAsync(List<long> players, int gender);
	}
}
