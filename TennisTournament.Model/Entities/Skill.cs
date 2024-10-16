using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TennisTournament.Model.Entities
{
	public class Skill
	{
		[Key]
		public long IdSkill { get; set; }

		public long IdType { get; set; }
		public int Value { get; set; }
		public long IdPlayer { get; set; }

		[ForeignKey(nameof(IdType))]
		public SkillType SkillType { get; set; }

		[ForeignKey(nameof(IdPlayer))]
		public Player Player { get; set; }
	}
}
