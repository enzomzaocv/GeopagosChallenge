using Microsoft.AspNetCore.Mvc;
using TennisTournament.Core;
using TennisTournament.Model.Dtos;

namespace TennisTournament.Controllers
{
	[Route("[controller]")]
	public class PlayerController : BaseController
	{
		private readonly IPlayerCore _playerCore;
		private readonly ILogger<PlayerController> _logger;

		public PlayerController(
			IPlayerCore playerCore,
			ILogger<PlayerController> logger)
		{
			this._playerCore = playerCore;
			_logger = logger;
		}

		[HttpPost("Create")]
		public async Task<IActionResult> Create([FromBody] DtoCreatePlayerRequest request)
		{
			if (!ModelState.IsValid) return BadRequest(GetErrorsList());

			await _playerCore.CreateAsync(request);

			return Ok();
		}

		[HttpGet("All")]
		public async Task<IActionResult> GetAll([FromQuery] DtoGetAllByGenderRequest request)
		{
			var result = await _playerCore.GetAllByGenderAsync(request);

			return Ok(result);
		}
	}
}
