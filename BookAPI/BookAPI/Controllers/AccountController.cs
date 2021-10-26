using BookAPI.Domain.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration config, ITokenService tokenService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _tokenService = tokenService;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (!_roleManager.RoleExistsAsync("User").Result)
                    {
                        IdentityRole role = new IdentityRole
                        {
                            Name = "User",
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            return BadRequest("Something went wrong");
                        }
                    }else if (!_roleManager.RoleExistsAsync("Reseller").Result)
                    {
                        IdentityRole role = new IdentityRole
                        {
                            Name = "Reseller",
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            return BadRequest("Something went wrong");
                        }
                    }
                    
                    if (model.IsReseller)
                    {
                         _userManager.AddToRoleAsync(user, "Reseller").Wait();
                    }
                    else
                    {
                        _userManager.AddToRoleAsync(user, "User").Wait();
                    }
                    return Ok("Account Registered");
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result =  _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false).Result;
                if (result.Succeeded)
                {
                    // Get Role
                    generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), _config["Jwt:Audience"].ToString(), new IdentityUser { UserName = model.Email }, "User");
                    if( generatedToken !=null)
                    {
                        HttpContext.Session.SetString("Token", generatedToken);
                    }
                    return Ok(new { Message = "Login Successful", Token = generatedToken });
                }
                else
                {
                    return Unauthorized("Incorrect Credentials");

                }
            }
            return BadRequest("Something went wrong");

        }
    }
}
