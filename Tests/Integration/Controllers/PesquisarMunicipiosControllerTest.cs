
using System.Text;

using IDezApi.Api;
using IDezApi.Api.Dtos.Request;
using IDezApi.Tests.Integration.Base;
using IDezApi.Tests.Integration.Configurations;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace IDezApi.Tests.Integration.Controllers
{
    public class PesquisarMunicipiosControllerTest : ControllerBase, IClassFixture<IntegrationTestsWebFactory<Program>>, BaseTestController
    {
        private readonly HttpClient _client;

        public PesquisarMunicipiosControllerTest(IntegrationTestsWebFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }


        [Fact]
        public async Task ShouldReturnSuccess()
        {

            var request = new PesquisarMunicipiosRequest { Uf = "MG" };

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/get/PesquisarMunicipios", content);

            Assert.True(response.IsSuccessStatusCode);

        }

        [Fact]
        public async Task ShouldReturnBadRequestWhenValidationFails()
        {
            // Arrange
            var request = new PesquisarMunicipiosRequest { Uf = "XX" };

            var stringPayload = JsonConvert.SerializeObject(request);

            // Act
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/get/PesquisarMunicipios", content);

            // Assert
            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task ShouldReturnUnprocessableEntityWhenBusinessRuleViolation()
        {
            // Arrange
            var request = new PesquisarMunicipiosRequest { Uf = "XX" };

            var stringPayload = JsonConvert.SerializeObject(request);

            // Act
            var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/get/PesquisarMunicipios", content);

            // Assert
            Assert.False(response.IsSuccessStatusCode);
        }

    }
}
