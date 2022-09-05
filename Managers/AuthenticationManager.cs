using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;
using test2.Models;

namespace test2.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {

        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly ITokenManager tokenManager;

        public AuthenticationManager(UserManager<User> userManager,SignInManager<User> signInManager, ITokenManager tokenManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenManager = tokenManager;
        }
        //private static string registerModel;
        public async Task Signup(RegisterModel registerModel)
        {
            var user = new User //fix entitatea din baza
            {
                Email = registerModel.Email,
                UserName = registerModel.Email

            };

            var result = await userManager.CreateAsync(user, registerModel.Password); //hashuieste identity parola
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.RoleId);
            }
        }
        public async Task<TokensModel> Login(LoginModel loginModel)
        {
            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user !=null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user,loginModel.Password,false); //aveam true, dar am modfi 23.01
                if (result.Succeeded)
                {
                    var token = await tokenManager.GenerateToken(user);

                    return new TokensModel
                    {
                        AccessToken = token
                    };
                }               
                
            }
            return null; 
        }

        
    }
}
