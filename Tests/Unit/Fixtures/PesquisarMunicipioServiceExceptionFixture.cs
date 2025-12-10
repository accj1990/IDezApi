using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Adapters.Driven.Integrations.Services;

namespace IDezApi.Tests.Unit.Fixtures
{
    public class PesquisarMunicipioServiceExceptionFixture
    {

        public IPesquisarMunicipioService CreateExceptionService()
        {
            return new PesquisarMunicipioServiceExceptionStub();
        }

        private class PesquisarMunicipioServiceExceptionStub : IPesquisarMunicipioService
        {
            public Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf, CancellationToken cancellationToken)
            {
                throw new Exception("Erro forçado no stub");
            }
        }
    }
}
