using System.Text.Json.Serialization;
using TennisTournament.Utils;

namespace TennisTournament.Model.Dtos
{
	public class DtoSearchTournamentRequest
	{
		public int? Gender { get; set; }
		public string Date { get; set; } = string.Empty;
		public string Winner { get; set; } = string.Empty;

		[JsonIgnore]
		public DateTime? DateValue => DateUtils.ParseDateDdMmYyyyNullable(Date);
	}
}