using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TennisTournament.Exceptions;
using TennisTournament.Resources;

namespace TennisTournament.Controllers
{
	public class ErrorController : BaseController
	{
		/// <summary>
		/// Catches all the unhandled errors.
		/// </summary>
		/// <returns>The error detail.</returns>
		[AllowAnonymous, ApiExplorerSettings(IgnoreApi = true), HttpGet, HttpPost, HttpPut, HttpDelete, Route("/error")]
		public IActionResult Error()
		{
			var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

			GetErrorData(context.Error, out var message, out var errorCode);

			// Save error 

			return Problem(
				message,
				statusCode: errorCode,
				title: "Error");
		}

		#region Private Methods

		private static void GetErrorData(Exception ex, out string message, out int errorCode)
		{
			message = ex.Message;

			switch (ex)
			{
				case InvalidSkillException _:
				case InvalidFormatException _:
				case NotEnoughPlayersException _:
				case OddPlayersException _:
					errorCode = StatusCodes.Status400BadRequest;
					break;
				default:
					message = Messages.UnexpectedError;
					errorCode = StatusCodes.Status500InternalServerError;
					break;
			}
		}

		#endregion
	}
}
