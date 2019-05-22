using AngularNetCore.BusinessLogic.Interfaces;
using AngularNetCore.Models;
using AngularNetCore.WebApi.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AngularNetCore.WebApi.Controllers
{
    [Route("api/token")]
    public class TokenController:Controller
    {
        private ITokenProvider _tokenProvider;
        private ITokenLogic _tokenLogic;

        public TokenController(ITokenProvider tokenProvider, ITokenLogic tokenLogic)
        {
            _tokenProvider = tokenProvider;
            _tokenLogic = tokenLogic;
        }

        [HttpPost]
        public JsonWebToken Post([FromBody]User userLogin)
        {
            var user = _tokenLogic.ValidateUser(userLogin.Email, userLogin.Password);
            if (user == null) throw new UnauthorizedAccessException();

            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480 //minutes
            };
            return token;
        }
    }
}
