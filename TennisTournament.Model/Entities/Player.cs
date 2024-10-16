using System.ComponentModel.DataAnnotations;

namespace TennisTournament.Model.Entities
{
	public class Player
	{
		[Key]
		public long IdPlayer { get; set; }
		public int SkillPoints { get; set; }
		public int Gender { get; set; }
		public string Name { get; set; }

		public List<Skill> Skills { get; set; } = new List<Skill>();

		public int CalculateTotalPoints()
		{
			return Skills.Where(p => p.SkillType.GenderAdventage == Gender).Sum(p => p.Value) + SkillPoints;
		}
	}
}
