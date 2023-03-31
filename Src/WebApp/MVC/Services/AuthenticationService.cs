using WebApp.MVC.Models;
using WebApp.MVC.Models.AccountViewModels;

namespace WebApp.MVC.Services
{
    public class AuthenticationService : Service, IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public AuthenticationService(HttpClient httpClient, IConfiguration config)
        {
            httpClient.BaseAddress = new Uri(config[config["AuthUrl"]]);

            _httpClient = httpClient;
        }

        public async Task<UserLoginResponse> Login(LoginViewModel userLogin)
        {
            var loginContent = ObtainContent(userLogin);
            var response = await _httpClient.PostAsync(
                "/api/v1/Auth/login",
                loginContent);

            if (!ErrosResponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            };

            return await DeserializeObjectResponse<UserLoginResponse>(response);
        }

        public async Task<UserLoginResponse> Register(RegisterViewModel userRegister)
        {
            var registerContent = ObtainContent(userRegister);

            var response = await _httpClient.PostAsync(
                "/api/identity/register",
                registerContent);

            if (!ErrosResponse(response))
            {
                return new UserLoginResponse
                {
                    ResponseResult = await DeserializeObjectResponse<ResponseResult>(response)
                };
            };

            return await DeserializeObjectResponse<UserLoginResponse>(response);
        }
    }
}
