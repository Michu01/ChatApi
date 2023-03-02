using System.IdentityModel.Tokens.Jwt;

using ChatApi.DTOs;
using ChatApi.Models;
using ChatApi.Services;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<UserDTO> userManager;

        private readonly JwtGenerator jwtGenerator;

        public UsersController(UserManager<UserDTO> userManager, JwtGenerator jwtGenerator)
        {
            this.userManager = userManager;
            this.jwtGenerator = jwtGenerator;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<string>> SignUp(SignUpData signUpData)
        {
            if (signUpData.Password != signUpData.ConfirmPassword)
            {
                return BadRequest();
            }

            UserDTO user = new()
            {
                UserName = signUpData.UserName
            };

            IdentityResult result = await userManager.CreateAsync(user, signUpData.Password);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            string token = await jwtGenerator.Generate(user);

            return token;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<string>> SignIn(SignInData signInData)
        {
            if (await userManager.FindByNameAsync(signInData.UserName) is not UserDTO user ||
                !await userManager.CheckPasswordAsync(user, signInData.Password))
            {
                return BadRequest();
            }

            string token = await jwtGenerator.Generate(user);

            return token;
        }
    }
}
