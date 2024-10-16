using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TennisTournament.Exceptions;
using TennisTournament.Utils;
using static Enumerations.Enumerations;

namespace TennisTournament.Model.Dtos
{
	public class DtoPlayTournamentRequest : Gendered
	{
		[Required]
		public List<string> Players { get; set; } = new List<string>();

		[Required]
		public string Date { get; set; }

		[JsonIgnore]
		public DateTime DateValue => DateUtils.ParseDateDdMmYyyy(Date);
	}

	public abstract class Gendered
	{
		[Required]
		[AllowedValues("M", "F", "m", "f")]
		public string Gender { get; set; }

		[JsonIgnore]
		public int GenderValue
		{
			get
			{
				if (Gender.ToUpperInvariant() == "M") return (int)GenderOption.Male;

				if (Gender.ToUpperInvariant() == "F") return (int)GenderOption.Female;

				throw new InvalidFormatException(nameof(Gender));
			}
		}
	}
}
