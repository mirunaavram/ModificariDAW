using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Managers;
using test2.Models;

namespace test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private /*readonly*/ IAuthenticationManager authenticationManager;

        public AuthenticationController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel registerModel)
        {

            try
            {
                await authenticationManager.Signup(registerModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Something failed");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                var tokens = await authenticationManager.Login(loginModel);
                if (tokens != null)
                {
                    return Ok(tokens);
                }

                else
                {
                    return BadRequest("Failed to login"); //basic mod de a spune frontendului ca n-a mers bine
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Something failed");
            }


        }

    }
}
