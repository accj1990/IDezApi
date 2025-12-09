using IDezApi.Domain.Adapters.Driven.Integrations.Dto;
using IDezApi.Domain.Common;

using static IDezApi.Domain.Application.Dtos.Responses.PesquisarMunicipiosOutputModel;

namespace IDezApi.Domain.Application.Dtos.Responses
{
    public class PesquisarMunicipiosOutputModel : BaseOutputModel<GetAllMunicipiosIBGE>
    {
        public PesquisarMunicipiosOutputModel() : base() { }

        public GetAllMunicipiosIBGE lista { get; set; } = default!;

        public class GetAllMunicipiosIBGE
        {
            public List<MunicipioIBGEDto> items { get; set; } = default!;

        }
    }
}
