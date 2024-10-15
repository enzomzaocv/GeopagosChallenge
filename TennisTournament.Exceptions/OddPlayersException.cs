using TennisTournament.Resources;

namespace TennisTournament.Exceptions
{
	public class OddPlayersException : Exception
	{
		public OddPlayersException() : base(Messages.OddPlayers)
		{
		}
	}
}
