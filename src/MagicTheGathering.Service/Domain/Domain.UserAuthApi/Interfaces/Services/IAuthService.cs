using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Commons.Results;


namespace Domain.UserAuthApi.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ServiceResult<string>> AuthenticateUserAsync(string username, string password);
        Task<ServiceResult<string>> RegisterUserAsync(string username, string password);   
    }
}
