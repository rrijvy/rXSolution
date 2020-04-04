using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuth.Services
{
    public interface IUserService
    {
        bool Login(UserAuth userAuth);
        bool Logout(UserAuth userAuth);
        bool ChangePassword(UserAuth userAuth);
    }
}
