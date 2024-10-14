using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TennisTournament.Model.Entities
{
	public class Match
	{
		[Key]
		public long IdMatch { get; set; }

		public long IdPlayer1 { get; set; }
		public long IdPlayer2 { get; set; }
		public long? IdWinner { get; set; }
		public int Stage { get; set; }

		[ForeignKey(nameof(IdPlayer1))]
		public Player Player1 { get; set; }

		[ForeignKey(nameof(IdPlayer2))]
		public Player Player2 { get; set; }

		[ForeignKey(nameof(IdWinner))]
		public Player Winner { get; set; }
	}
}
