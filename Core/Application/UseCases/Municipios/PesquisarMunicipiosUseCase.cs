using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Application.Interfaces;

namespace IDezApi.Application.UseCases.Municipios
{
    public class PesquisarMunicipiosUseCase : IPesquisarMunicipiosUseCase
    {
        PesquisarMunicipiosUseCase() { }
        public Task<List<MunicipioIBGEDto>> PesquisarMunicipiosPorUfAsync(string uf)
        {
            try
            {
                var url = string.Format(_urlBrasilApi, uf);
                var response = await _genericClient.GetAsync<List<MunicipioDto>>(url);
                if (response.Success && response.Data != null)
                {
                    return response.Data;
                }
                else
                {
                    _logger.LogError("Erro ao buscar municípios para a UF {Uf}: {ErrorMessage}", uf, response.ErrorMessage);
                    throw new Exception($"Erro ao buscar municípios para a UF {uf}: {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exceção ao buscar municípios para a UF {Uf}", uf);
                throw;
            }
        }
    }
}
