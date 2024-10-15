using TennisTournament.Resources;

namespace TennisTournament.Exceptions
{
	public class InvalidFormatException : Exception
	{
		public InvalidFormatException(string field) : base(string.Format(Messages.InvalidFormat, field))
		{
		}
	}
}
