using Microsoft.AspNetCore.Mvc;
using TennisTournament.Core;
using TennisTournament.Model.Dtos;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TennisTournamentController : ControllerBase
	{
		private readonly ITournamentCore tournamentCore;
		private readonly ILogger<TennisTournamentController> _logger;

		public TennisTournamentController(ILogger<TennisTournamentController> logger)
		{
			_logger = logger;
		}

		[HttpPost("PlayTournament")]
		public async Task<IActionResult> PlayTournament([FromBody]DtoPlayTournamentRequest request)
		{

			var result = await tournamentCore.PlayTournamentAsync(request);

			return Ok();
		}

		[HttpGet("Search")]
		public async Task<IActionResult> SearchTournament([FromQuery] DtoSearchTournamentRequest request)
		{

			var result = await tournamentCore.SearchTournamentAsync(request);

			return Ok();
		}
	}
}
