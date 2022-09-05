using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Models;

namespace test2.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(RegisterModel registerModel); //imi trimite emailul, parola si ce rol
        Task<TokensModel> Login(LoginModel loginModel);
    }
}
