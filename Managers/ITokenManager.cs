using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2.Entities;

namespace test2.Managers
{
    public interface ITokenManager
    {
        Task<string> GenerateToken(User user);
    }
}
