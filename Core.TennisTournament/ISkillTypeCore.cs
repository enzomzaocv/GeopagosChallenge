using TennisTournament.Model.Dtos;

namespace TennisTournament.Core
{
	public interface ISkillTypeCore
	{
		Task<GetSkillTypeResponse> GetAllAsync();
	}
}
