using API.Models;
using Books.BusinessLogic.DTOs;
using Books.BusinessLogic.Queries;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
		private readonly IMediator _mediator;

		public AuthService(IConfiguration config, IMediator mediator)
        {
            _config = config;
            _mediator = mediator;
        }

        public string GenerateToken(UserDTO employee)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, employee.Username)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserDTO> Authenticate(UserLogin userLogin)
        {
            var currentUser = await _mediator.Send(new GetUserByUsername
			{
				Username = userLogin.Username
			});
            if (currentUser == null)
            {
                return null;
            }
            if(!IsPasswordValid(userLogin.Password, currentUser.Password, currentUser.Salt))
            {
                return null;
            }
            return currentUser;
        }

        private bool IsPasswordValid(string inputPassword, string stringActualPassword, string stringSalt)
        {
            byte[] salt = Convert.FromBase64String(stringSalt);
            byte[] actualPassword = Convert.FromBase64String(stringActualPassword);
            byte[] currentPassword = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(inputPassword), salt, 10000).GetBytes(64);

            return currentPassword.SequenceEqual(actualPassword);
        }
    }
}
