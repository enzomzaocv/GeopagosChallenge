using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TennisTournament.Exceptions;
using TennisTournament.Resources;
using TennisTournament.Utils;
using static Enumerations.Enumerations;

namespace TennisTournament.Model.Dtos
{
	public class DtoPlayTournamentRequest
	{
		[Required]
		public List<long> Players { get; set; } = new List<long>();

		[Required]
		public string Date { get; set; }

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

				throw new InvalidFormatException(string.Format(Messages.InvalidFormat, nameof(Gender)));
			}
		}

		[JsonIgnore]
		public DateTime DateValue => DateUtils.ParseDateDdMmYyyy(Date);
	}
}
