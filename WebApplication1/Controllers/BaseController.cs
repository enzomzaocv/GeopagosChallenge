using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TennisTournament.Controllers
{
	[ApiController, AllowAnonymous]
	public class BaseController : ControllerBase
	{
		protected List<string> GetErrorsList()
		{
			if (ModelState.IsValid) return new List<string>();

			var errors = new List<string>();

			foreach (var values in ModelState.Values)
			{
				errors.AddRange(values.Errors.Select(valuesError => valuesError.ErrorMessage));
			}

			return errors;
		}
	}
}
