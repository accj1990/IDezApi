using FakeItEasy;

using FluentAssertions;

using IDezApi.Application.UseCases.Municipios;
using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Enums;
using IDezApi.Tests.Unit.Base;
using IDezApi.Tests.Unit.Fixtures;

using Microsoft.Extensions.Logging;

namespace IDezApi.Tests.Unit.UseCase
{
    public class PesquisarMunicipiosUseCaseTest : BaseTestUseCase
    {
        private readonly ILogger<PesquisarMunicipiosUseCase> _logger;
        private readonly IPesquisarMunicipioService _pesquisarMunicipioService;

        public PesquisarMunicipiosUseCaseTest()
        {
            _logger = A.Fake<ILogger<PesquisarMunicipiosUseCase>>();
            _pesquisarMunicipioService = A.Fake<IPesquisarMunicipioService>();
        }

        [Fact]
        public async Task ShouldHandleExceptionWhenExceptionThrown()
        {
            // Arrange
            var fixture = new PesquisarMunicipioServiceExceptionFixture();
            var fakeService = fixture.CreateExceptionService();
            var input = new PesquisarMunicipiosUseCaseFixture().CreateInputModel();
            input.Uf = "XX"; // Invalid UF

            var useCase = new PesquisarMunicipiosUseCase(_logger, fakeService);

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
            var input = new PesquisarMunicipiosUseCaseFixture().CreateInputModel();
            input.Uf = "MG"; // Valid UF

            // Act
            var useCase = new PesquisarMunicipiosUseCase(_logger, _pesquisarMunicipioService);
            var response = await useCase.ExecuteAsync(input.Uf, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.Message.Should().Be(PatternsMessages.MessageSucessUseCaseMunicipios);
            response.IsSuccess.Should().BeTrue();
        }
    }
}
