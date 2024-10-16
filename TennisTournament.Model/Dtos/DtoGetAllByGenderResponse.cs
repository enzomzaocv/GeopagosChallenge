namespace TennisTournament.Model.Dtos
{
	public class DtoGetAllByGenderResponse
	{
		public List<DtoGetPlayerResponse> Players { get; set; } = new List<DtoGetPlayerResponse>();
	}

	public class DtoGetPlayerResponse
	{
		public string Name { get; set; }
	}
}
