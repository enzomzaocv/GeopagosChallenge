using System.ComponentModel.DataAnnotations;

namespace TennisTournament.Model.Dtos
{
	public class DtoCreatePlayerRequest : Gendered
	{
		[Required]
		[MaxLength(50)]
		[MinLength(3)]
		public string Name { get; set; }

		[Required]
		[Range(1, 100)]
		public int SkillPoints { get; set; }

		public List<DtoRequestSkill> Skills { get; set; } = new List<DtoRequestSkill>();
	}

	public class DtoRequestSkill
	{
		[Required]
		public long IdSkill { get; set; }

		[Required]
		[Range(1, 100)]
		public int Value { get; set; }
	}
}
