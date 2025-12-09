using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Application.Interfaces;

namespace IDezApi.Application.UseCases.Municipios
{
    public class PesquisarMunicipiosUseCase : IPesquisarMunicipiosUseCase
    {
        private readonly IPesquisarMunicipioService _pesquisarMunicipioService;
        public PesquisarMunicipiosUseCase(IPesquisarMunicipioService pesquisarMunicipioService)
        {
            _pesquisarMunicipioService = pesquisarMunicipioService;
        }
        public Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf)
        {
            try
            {
                return _pesquisarMunicipioService.PesquisarMunicipiosPorUfAsync(uf);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar municípios por UF.", ex);
            }
        }
    }
}
