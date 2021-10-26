using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, string audience, IdentityUser user, string role);
        bool ValidateToken(string key, string issuer, string audience, string token);
    }
}
