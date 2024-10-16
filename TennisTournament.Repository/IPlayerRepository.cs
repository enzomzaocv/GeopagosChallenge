using TennisTournament.Model.Entities;

namespace TennisTournament.Repository
{
	public interface IPlayerRepository : IRepository<Player>
	{
		Task<List<Player>> GetByNameAsync(List<string> players, int gender);
	}
}
