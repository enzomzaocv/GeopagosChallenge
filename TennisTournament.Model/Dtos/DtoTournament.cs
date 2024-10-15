using System.Text.Json.Serialization;
using TennisTournament.Resources;

namespace TennisTournament.Model.Dtos
{
	public class DtoTournament
	{
		public string Name { get; set; }
		public string Winner { get; set; }
		public DateTime Date { get; set; }

		[JsonPropertyName("date")]
		public string DateLabel => Date.ToString(Formats.DateFormatDdMmYyyy);
	}
}
