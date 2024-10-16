using TennisTournament.Exceptions;
using TennisTournament.Model.Dtos;
using TennisTournament.Model.Entities;
using TennisTournament.Repository;

namespace TennisTournament.Core
{
	public class PlayerCore : IPlayerCore
	{
		private readonly IPlayerRepository _playerRepository;
		private readonly ISkillTypeRepository _skillTypeRepository;

		public PlayerCore(
			IPlayerRepository playerRepository,
			ISkillTypeRepository skillTypeRepository)
		{
			_playerRepository = playerRepository;
			_skillTypeRepository = skillTypeRepository;
		}

		public async Task CreateAsync(DtoCreatePlayerRequest request)
		{
			if (await _skillTypeRepository.CheckIdsAsync(request.Skills.Select(p => p.IdSkill).ToList()))
				throw new InvalidSkillException();

			var player = new Player
			{
				Gender = request.GenderValue,
				Name = request.Name,
				SkillPoints = request.SkillPoints,
				Skills = request.Skills.Select(p => new Skill
				{
					IdType = p.IdSkill,
					Value = p.Value
				}).ToList()
			};

			await _playerRepository.CreateAsync(player);
			await _playerRepository.SaveChangesAsync();
		}

		public async Task<DtoGetAllByGenderResponse> GetAllByGenderAsync(DtoGetAllByGenderRequest request)
		{
			var players = await _playerRepository.GetAllAsync(p => p.Gender == request.GenderValue);

			return new DtoGetAllByGenderResponse
			{
				Players = players.Select(p => new DtoGetPlayerResponse
				{
					Name = p.Name
				}).ToList()
			};
		}
	}
}
