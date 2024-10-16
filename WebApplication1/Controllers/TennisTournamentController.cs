using Microsoft.AspNetCore.Mvc;
using TennisTournament.Controllers;
using TennisTournament.Core;
using TennisTournament.Model.Dtos;

namespace WebApplication1.Controllers
{
	[Route("[controller]")]
	public class TennisTournamentController : BaseController
	{
		private readonly ITournamentCore tournamentCore;
		private readonly ILogger<TennisTournamentController> _logger;

		public TennisTournamentController(
			ITournamentCore tournamentCore,
			ILogger<TennisTournamentController> logger)
		{
			this.tournamentCore = tournamentCore;
			_logger = logger;
		}

		[HttpPost("PlayTournament")]
		public async Task<IActionResult> PlayTournament([FromBody] DtoPlayTournamentRequest request)
		{
			if (!ModelState.IsValid) return BadRequest(GetErrorsList());

			var result = await tournamentCore.PlayTournamentAsync(request);

			return Ok();
		}

		[HttpGet("Search")]
		public async Task<IActionResult> SearchTournament([FromQuery] DtoSearchTournamentRequest request)
		{
			var result = await tournamentCore.SearchTournamentAsync(request);

			return Ok(result);
		}
	}
}
