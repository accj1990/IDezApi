using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;

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
