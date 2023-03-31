using System.Text;
using System.Text.Json;
using WebApp.MVC.Models;
using WebApp.MVC.Models.AccountViewModels;

namespace WebApp.MVC.Services
{
    public class AuthenticationService : Service, IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserLoginResponse> Login(LoginViewModel userLogin)
        {
            var loginContent = new StringContent(
                JsonSerializer.Serialize(userLogin),
                Encoding.UTF8,
                "application/json"
                );
            var response = await _httpClient.PostAsync(
                "https://localhost:44346/api/v1/Auth/login",
                loginContent);

            if (!ErrosResponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult =
                    JsonSerializer.Deserialize<ResponseResult>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                };
            };

            return JsonSerializer.Deserialize<UserLoginResponse>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<UserLoginResponse> Register(RegisterViewModel userRegister)
        {
            var registerContent = new StringContent(
                JsonSerializer.Serialize(userRegister),
                Encoding.UTF8,
                "application/json"
                );
            var response = await _httpClient.PostAsync(
                "https://localhost:44346/api/identity/register",
                registerContent);

            if (!ErrosResponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult =
                    JsonSerializer.Deserialize<ResponseResult>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                };
            };

            return JsonSerializer.Deserialize<UserLoginResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}
