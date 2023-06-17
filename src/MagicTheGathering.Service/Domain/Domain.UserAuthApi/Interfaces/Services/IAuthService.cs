using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserAuthApi.Interfaces.Services
{
    public interface IAuthService
    {
        string AuthenticateUser(string username, string password);
        ServiceResult RegisterUser(string username, string password);
    }
}
