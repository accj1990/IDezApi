using FakeItEasy;

using FluentAssertions;

using IDezApi.Application.UseCases.Municipios;
using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Enums;
using IDezApi.Tests.Unit.Base;
using IDezApi.Tests.Unit.Fixtures;

using Microsoft.Extensions.Logging;

namespace IDezApi.Tests.Unit.UseCase;

public class BuscarMunicipiosUseCaseTest : BaseTestUseCase
{
    private readonly ILogger<BuscarMunicipiosUseCase> _logger;
    private readonly IBuscarMunicipioService _buscarMunicipioService;

    public BuscarMunicipiosUseCaseTest()
    {
        _logger = A.Fake<ILogger<BuscarMunicipiosUseCase>>();
        _buscarMunicipioService = A.Fake<IBuscarMunicipioService>();
    }

    [Fact]
    public async Task ShouldHandleExceptionWhenExceptionThrown()
    {
        // Arrange
        var fixture = new BuscarMunicipioServiceExceptionFixture();
        var fakeService = fixture.CreateExceptionService();
        var input = new BuscarMunicipiosUseCaseFixture().CreateInputModel();
        input.Uf = "XX"; // Invalid UF

        var useCase = new BuscarMunicipiosUseCase(_logger, fakeService);

        // Act
        var response = await useCase.ExecuteAsync(input.Uf, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.IsSuccess.Should().BeFalse();
        response.Message.Should().Be(PatternsMessages.MessageErrorUseCaseMunicipios);

    }

    [Fact]
    public async Task ShouldWhenSuccess()
    {
        // Arrange
        var input = new BuscarMunicipiosUseCaseFixture().CreateInputModel();
        input.Uf = "MG"; // Valid UF
        // Act
        var useCase = new BuscarMunicipiosUseCase(_logger, _buscarMunicipioService);
        var response = await useCase.ExecuteAsync(input.Uf, CancellationToken.None);

        // Assert
        response.Should().NotBeNull();
        response.Message.Should().Be(PatternsMessages.MessageSucessUseCaseMunicipios);
        response.IsSuccess.Should().BeTrue();
    }
}
