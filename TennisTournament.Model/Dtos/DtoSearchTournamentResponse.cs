namespace TennisTournament.Model.Dtos
{
	public class DtoSearchTournamentResponse
	{
		public List<DtoTournament> List { get; set; } = new List<DtoTournament>();
		public int Count { get; set; }
	}
}
