using TennisTournament.Resources;

namespace TennisTournament.Exceptions
{
	public class InvalidSkillException : Exception
	{
		public InvalidSkillException() : base(Messages.InvalidSkill)
		{
		}
	}
}
