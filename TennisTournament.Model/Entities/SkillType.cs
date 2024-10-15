using System.ComponentModel.DataAnnotations;

namespace TennisTournament.Model.Entities
{
	public class SkillType
	{
		[Key]
		public long Id { get; set; }

		public string Description { get; set; }
		public int GenderAdventage { get; set; }
	}
}
