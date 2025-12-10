using AutoFixture;

using IDezApi.Api.Dtos.Request;
using IDezApi.Api.Dtos.Response;


namespace IDezApi.Tests.Integration.Fixtures
{
    public class BuscarMunicipioRequestFixture
    {

        private readonly Fixture _fixture;
        public BuscarMunicipioRequestFixture()
        {
            _fixture = new Fixture();
        }

        public BuscarMunicipiosRequest CreateRequest()
        {
            return _fixture.Create<BuscarMunicipiosRequest>();
        }

        public BuscarMunicipiosResponse CreateResponse()
        {
            return _fixture.Create<BuscarMunicipiosResponse>();
        }

    }
}
