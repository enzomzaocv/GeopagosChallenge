using TennisTournament.Resources;

namespace TennisTournament.Exceptions
{
	public class NotEnoughPlayersException : Exception
	{
		public NotEnoughPlayersException() : base(Messages.NotEnoughPlayers)
		{
		}
	}
}
