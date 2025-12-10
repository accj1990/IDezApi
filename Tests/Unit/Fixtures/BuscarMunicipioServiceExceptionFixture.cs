using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Adapters.Driven.Integrations.Services;

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
