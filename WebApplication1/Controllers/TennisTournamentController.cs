using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TennisTournamentController : ControllerBase
	{
		private readonly ILogger<TennisTournamentController> _logger;

		public TennisTournamentController(ILogger<TennisTournamentController> logger)
		{
			_logger = logger;
		}
	}
}
