using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AuthService _authService;
		public AuthController(AuthService authService)
		{
			_authService = authService;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult> Login([FromBody] UserLogin userLogin)
		{
			var user = await _authService.Authenticate(userLogin);
			if (user != null)
			{
				var token = _authService.GenerateToken(user);
				return Ok(new
				{
					Token = token,
					Expires = DateTime.Now.AddMinutes(15)
				});
			}

			return NotFound("user not found");
		}
	}
}
