using TennisTournament.Model.Dtos;

namespace TennisTournament.Core
{
	public interface IPlayerCore
	{
		Task<DtoGetAllByGenderResponse> GetAllByGenderAsync(DtoGetAllByGenderRequest request);
		Task CreateAsync(DtoCreatePlayerRequest request);
	}
}
