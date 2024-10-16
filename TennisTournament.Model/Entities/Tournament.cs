using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TennisTournament.Model.Entities
{
	public class Tournament
	{
		[Key]
		public long IdTournament { get; set; }

		public DateTime Date { get; set; }
		public long IdWinner { get; set; }
		public int Gender { get; set; }


		[ForeignKey(nameof(IdWinner))]
		public Player Winner { get; set; }

		public List<Match> Matches { get; set; } = new List<Match>();
	}
}
