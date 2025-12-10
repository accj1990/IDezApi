using System.Text;

using IDezApi.Api;
using IDezApi.Api.Dtos.Request;
using IDezApi.Tests.Integration.Base;
using IDezApi.Tests.Integration.Configurations;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace IDezApi.Tests.Integration.Controllers;

public class BuscarMunicipiosControllerTest : ControllerBase, IClassFixture<IntegrationTestsWebFactory<Program>>, BaseTestController

{
    private readonly HttpClient _client;

    public BuscarMunicipiosControllerTest(IntegrationTestsWebFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task ShouldReturnSuccess()
    {

        var request = new BuscarMunicipiosRequest { Uf = "MG" };

        var json = JsonConvert.SerializeObject(request);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("api/get/BuscarMunicipios", content);

        Assert.True(response.IsSuccessStatusCode);

    }

    [Fact]
    public async Task ShouldReturnBadRequestWhenValidationFails()
    {
        // Arrange
        var request = new BuscarMunicipiosRequest { Uf = "XX" };

        var stringPayload = JsonConvert.SerializeObject(request);

        // Act
        var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("/api/get/BuscarMunicipios", content);

        // Assert
        Assert.False(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task ShouldReturnUnprocessableEntityWhenBusinessRuleViolation()
    {
        // Arrange
        var request = new BuscarMunicipiosRequest { Uf = "XX" };

        var stringPayload = JsonConvert.SerializeObject(request);

        // Act
        var content = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        var response = await _client.PostAsync("api/get/BuscarMunicipios", content);

        // Assert
        Assert.False(response.IsSuccessStatusCode);
    }


}
