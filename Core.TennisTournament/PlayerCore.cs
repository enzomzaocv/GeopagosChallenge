using TennisTournament.Model.Dtos;
using TennisTournament.Repository;

namespace TennisTournament.Core
{
	public class PlayerCore : IPlayerCore
	{
		private readonly IPlayerRepository _playerRepository;

		public PlayerCore(IPlayerRepository playerRepository)
		{
			_playerRepository = playerRepository;
		}

		public Task CreateAsync(DtoCreatePlayerRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<DtoGetAllByGenderResponse> GetAllByGenderAsync(DtoGetAllByGenderRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
