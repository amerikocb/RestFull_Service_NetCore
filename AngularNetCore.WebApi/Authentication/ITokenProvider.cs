using AngularNetCore.Models;
using Microsoft.IdentityModel.Tokens;
using System;

namespace AngularNetCore.WebApi.Authentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
       
    }
}
