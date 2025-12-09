using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Common;

using static IDezApi.Domain.Application.Dtos.Responses.BuscarMunicipiosOutputModel;

namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class BuscarMunicipiosOutputModel : BaseOutputModel<GetAllMunicipios>
    {
        public BuscarMunicipiosOutputModel() : base() { }

        public GetAllMunicipios lista { get; set; } = default!;

        public class GetAllMunicipios
        {
            public List<MunicipioDto> items { get; set; } = default!;

        }
    }
}
