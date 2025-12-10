using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

namespace IDezApi.Tests.Unit.Fixtures
{
    public class BuscarMunicipioServiceExceptionFixture
    {
        public IBuscarMunicipioService CreateExceptionService()
        {
            return new BuscarMunicipioServiceExceptionStub();
        }

        private class BuscarMunicipioServiceExceptionStub : IBuscarMunicipioService
        {
            public Task<List<MunicipioDto>> BuscarMunicipiosPorUfAsync(string uf, CancellationToken cancellationToken)
            {
                throw new Exception("Erro forçado no stub");
            }
        }
    }
}
