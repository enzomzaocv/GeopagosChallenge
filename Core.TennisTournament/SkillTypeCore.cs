using TennisTournament.Model.Dtos;
using TennisTournament.Repository;

namespace TennisTournament.Core
{
	public class SkillTypeCore : ISkillTypeCore
	{
		private readonly ISkillTypeRepository _skillTypeRepository;

		public SkillTypeCore(ISkillTypeRepository skillTypeRepository)
		{
			_skillTypeRepository = skillTypeRepository;
		}

		public async Task<GetSkillTypeResponse> GetAllAsync()
		{
			var skills = await _skillTypeRepository.GetAllAsync();

			return new GetSkillTypeResponse
			{
				Skills = skills
			};
		}
	}
}
