using AutoFixture;

using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Dtos.Responses;

namespace IDezApi.Tests.Unit.Fixtures
{
    public class BuscarMunicipiosUseCaseFixture
    {
        private readonly Fixture _fixture;
        public BuscarMunicipiosUseCaseFixture()
        {
            _fixture = new Fixture();
        }

        public BuscarMunicipiosInputModel CreateInputModel()
        {
            return _fixture.Create<BuscarMunicipiosInputModel>();
        }

        public BuscarMunicipiosOutputModel CreateOutputModel()
        {
            return _fixture.Create<BuscarMunicipiosOutputModel>();
        }
    }
}
