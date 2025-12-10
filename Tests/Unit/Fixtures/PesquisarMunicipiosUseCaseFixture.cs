using AutoFixture;

using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Tests.Unit.Fixtures
{
    public class PesquisarMunicipiosUseCaseFixture
    {
        private readonly Fixture _fixture;
        public PesquisarMunicipiosUseCaseFixture()
        {
            _fixture = new Fixture();
        }

        public PesquisarMunicipiosInputModel CreateInputModel()
        {
            return _fixture.Create<PesquisarMunicipiosInputModel>();
        }

        public PesquisarMunicipiosOutputModel CreateOutputModel()
        {
            return _fixture.Create<PesquisarMunicipiosOutputModel>();
        }
    }
}
