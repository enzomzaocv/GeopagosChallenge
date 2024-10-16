using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TennisTournament.Exceptions;
using TennisTournament.Utils;
using static Enumerations.Enumerations;

namespace TennisTournament.Model.Dtos
{
	public class DtoSearchTournamentRequest
	{
		[AllowedValues("M", "F", "m", "f", null, "")]
		public string? Gender { get; set; }

		public string Date { get; set; } = string.Empty;
		public string Winner { get; set; } = string.Empty;

		[JsonIgnore]
		public DateTime? DateValue => DateUtils.ParseDateDdMmYyyyNullable(Date);

		[JsonIgnore]
		public int? GenderValue
		{
			get
			{
				if (string.IsNullOrWhiteSpace(Gender)) return null;

				if (Gender.ToUpperInvariant() == "M") return (int)GenderOption.Male;

				if (Gender.ToUpperInvariant() == "F") return (int)GenderOption.Female;

				throw new InvalidFormatException(nameof(Gender));
			}
		}
	}
}