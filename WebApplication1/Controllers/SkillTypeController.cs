using Microsoft.AspNetCore.Mvc;
using TennisTournament.Core;

namespace TennisTournament.Controllers
{
	[Route("[controller]")]
	public class SkillTypeController : BaseController
	{
		private readonly ISkillTypeCore _skillTypeCore;

		public SkillTypeController(ISkillTypeCore skillTypeCore)
		{
			_skillTypeCore = skillTypeCore;
		}

		[HttpGet("All")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _skillTypeCore.GetAllAsync();

			return Ok(result);
		}
	}
}
