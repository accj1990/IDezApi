using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Application.Dtos.Responses;
using IDezApi.Domain.Application.Interfaces;

using static IDezApi.Domain.Application.Dtos.Responses.PesquisarMunicipiosOutputModel;

namespace IDezApi.Application.UseCases.Municipios
{
    public class PesquisarMunicipiosUseCase : IPesquisarMunicipiosUseCase
    {
        private readonly IPesquisarMunicipioService _pesquisarMunicipioService;
        public PesquisarMunicipiosUseCase(IPesquisarMunicipioService pesquisarMunicipioService)
        {
            _pesquisarMunicipioService = pesquisarMunicipioService;
        }
        public async Task<PesquisarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _pesquisarMunicipioService.PesquisarMunicipiosPorUfAsync(uf);

                var resposta = new PesquisarMunicipiosOutputModel()
                {
                    Data = new GetAllMunicipiosIBGE
                    {
                        items = items
                    },
                    Message = "Municipios successfully retrieved",
                    IsSuccess = true
                };

                return resposta;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pesquisar municípios por UF.", ex);
            }
        }
    }
}
