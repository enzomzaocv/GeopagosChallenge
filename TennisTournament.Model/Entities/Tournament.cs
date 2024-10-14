using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TennisTournament.Model.Entities
{
	public class Tournament
	{
		[Key]
		public long IdTournament { get; set; }

		public int Year { get; set; }
		public long? IdWinner { get; set; }


		[ForeignKey(nameof(IdWinner))]
		public Player Winner { get; set; }

		[ForeignKey(nameof(Match.IdMatch))]
		public List <Match> Matches { get; set; } = new List<Match>();
	}
}
