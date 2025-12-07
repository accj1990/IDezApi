using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Adapters.Driven.Integrations.GenericClientHttp;
using IDezApi.Domain.Adapters.Driven.Integrations.Keycloak;
using IDezApi.Domain.Common;

namespace IDezApi.KeyCloak.Service
{
    public class KeycloakService : IKeycloakService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _authority;
        private readonly string _audience;
        private readonly string _tokenUrl;
        private readonly string _managementUsersUrl;
        private readonly string _logoutUrl;
        private readonly ILogger<KeycloakService> _logger;
        private readonly IGenericClientHttp _genericClient;

        public KeycloakService(
            IConfiguration configuration,
            ILogger<KeycloakService> logger,
            IGenericClientHttp genericClient)
        {
            _clientId = configuration["KeyCloak:ClientId"]!;
            _clientSecret = configuration["KeyCloak:ClientSecret"]!;
            _authority = configuration["KeyCloak:Authority"]!;
            _audience = configuration["KeyCloak:Audience"]!;

            _tokenUrl = $"{_authority}/protocol/openid-connect/token";
            _logoutUrl = $"{_authority}/protocol/openid-connect/logout";
            _managementUsersUrl = configuration["KeyCloak:UsersEndpoint"]!;//$"{_authority}/users";

            _logger = logger;
            _genericClient = genericClient;
        }

        public async Task<BaseResponse<AcessTokenDto>> Login(string Username, string password, CancellationToken cancellationToken)
        {
            try
            {

                _logger.LogInformation("Login user {Username} against Keycloak", Username);

                var content = new Dictionary<string, string>{
                    {"grant_type", "password"},
                    {"username", Username},
                    {"password", password},
                    {"client_id", _clientId},
                    {"client_secret", _clientSecret},
                    {"audience", _audience},
                    {"scope", "openid" }
                };

                var result = await _genericClient.PostFormAsync<AcessTokenDto>(_tokenUrl, content, cancellationToken);

                if (result == null)
                    return new BaseResponse<AcessTokenDto>().Fail("Resposta nula do servidor");

                return new BaseResponse<AcessTokenDto>().Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BaseResponse<AcessTokenDto>().Fail(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Logout(string Username, string IdToken, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Logout user {Username} against Keycloak", Username);

                var content = new Dictionary<string, string>{
                    {"grant_type", "password"},
                    {"client_id", _clientId},
                    {"client_secret", _clientSecret},
                    {"audience", _audience},
                    {"scope", "openid" }
                };

                var logoutUrl = _logoutUrl + "?id_token_hint=" + IdToken;

                var result = await _genericClient.PostFormAsync<string>(logoutUrl, content, cancellationToken);

                if (result == null)
                    return new BaseResponse<string>().Fail("Resposta nula do servidor");

                return new BaseResponse<string>().Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BaseResponse<string>().Fail(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> RegisterUser(
            string userName,
            string password,
            string accountId,
            string userId,
            string programRole,
            CancellationToken cancellationToken,
            string acceptedPlataformTermsAccountId = "")
        {
            try
            {
                _logger.LogInformation("RegisterUser user {Username} against Keycloak", userName);

                var payload = new KeycloakUser(
                    userName,
                    password,
                    accountId,
                    userId,
                    programRole,
                    acceptedPlataformTermsAccountId
                );

                var accessTokenSA = await GetAccessTokenServiceAccountAsync(cancellationToken);

                var headers = new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {accessTokenSA.AcessToken}" }
                };

                var response = await _genericClient.PostAsync<string>(
                    _managementUsersUrl,
                    payload,
                    headers);

                return new BaseResponse<string>().Success("Usuário registrado com sucesso no Keycloak.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new BaseResponse<string>().Fail(ex.Message);
            }
        }

        public async Task<AcessTokenDto> GetAccessTokenServiceAccountAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetAccessToken against Keycloak");

            var content = new Dictionary<string, string>{
                { "grant_type", "client_credentials" },
                { "client_id", _clientId },
                { "client_secret", _clientSecret },
                { "scope", "openid" }
            };

            var token = await _genericClient.PostFormAsync<AcessTokenDto>(_tokenUrl, content, cancellationToken);

            if (token == null)
                throw new Exception("Falha ao obter token do service account");

            return token;
        }

    }
}
