using Domain.UserAuthApi.Interfaces.Services;
using Domain.UserAuthApi.Models;
using Domain.UserAuthApi.Interfaces.Repositories;
using System.Threading.Tasks;
using Library.Commons.Results;

namespace Services.UserAuthApi
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResult<string>> AuthenticateUserAsync(string username, string password)
        {
            // Find the user by username in the repository
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null || !user.VerifyPassword(password))
            {
                return ServiceResult<string>.ErrorResult("Invalid credentials");
            }

            // Generate and return the authentication token
            string token = GenerateAuthToken(user);
            return ServiceResult<string>.SuccessResult(token);
        }

        public async Task<ServiceResult<string>> RegisterUserAsync(string username, string password)
        {
            // Check if the username is already taken
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);

            if (existingUser != null)
            {
                return ServiceResult<string>.ErrorResult("Username is already taken.");
            }

            // Create a new user entity
            var newUser = new User(username, password);

            // Save the user in the repository
            await _userRepository.AddUserAsync(newUser);

            return ServiceResult<string>.SuccessResult("User registration successful!");
        }

        // Other helper methods...

        private string GenerateAuthToken(User user)
        {
            // Generate the authentication token based on user details
            // Example code: using JWT authentication

            // Placeholder code
            string token = "generated_token";

            return token;
        }
    }
}
