using IDezApi.Domain.Adapters.Driven.Integrations;
using IDezApi.Domain.Application.Dtos.Responses;
using IDezApi.Domain.Application.Interfaces;

using static IDezApi.Domain.Application.Dtos.Responses.BuscarMunicipiosOutputModel;


namespace IDezApi.Application.UseCases.Municipios
{
    public class BuscarMunicipiosUseCase : IBuscarMunicipiosUseCase
    {
        private readonly IBuscarMunicipioService _buscarMunicipiosService;

        public BuscarMunicipiosUseCase(IBuscarMunicipioService buscarMunicipiosService)
        {
            _buscarMunicipiosService = buscarMunicipiosService;
        }
        public async Task<BuscarMunicipiosOutputModel> ExecuteAsync(string uf, CancellationToken cancellationToken)
        {
            try
            {
                var items = await _buscarMunicipiosService.BuscarMunicipiosPorUfAsync(uf, cancellationToken);

                var resposta = new BuscarMunicipiosOutputModel()
                {
                    Data = new GetAllMunicipios
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
