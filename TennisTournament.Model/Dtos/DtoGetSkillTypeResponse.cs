namespace TennisTournament.Model.Dtos
{
	public class GetSkillTypeResponse
	{
		public List<DtoSkillInfo> Skills { get; set; }
	}

	public class DtoSkillInfo
	{
		public string Denomination { get; set; }
		public long Id { get; set; }
	}
}
