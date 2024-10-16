using TennisTournament.Model.Dtos;
using TennisTournament.Model.Entities;

namespace TennisTournament.Repository
{
	public interface ISkillTypeRepository : IRepository<SkillType>
	{
		Task<bool> CheckIdsAsync(List<long> list);
		Task<List<DtoSkillInfo>> GetAllAsync();
	}
}
