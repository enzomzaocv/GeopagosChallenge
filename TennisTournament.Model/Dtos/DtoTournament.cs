using System.Text.Json.Serialization;
using TennisTournament.Resources;

namespace TennisTournament.Model.Dtos
{
	public class DtoTournament
	{
		public string Winner { get; set; }

		[JsonIgnore]
		public DateTime Date { get; set; }

		[JsonPropertyName("date")]
		public string DateLabel => Date.ToString(Formats.DateFormatDdMmYyyy);
	}
}
