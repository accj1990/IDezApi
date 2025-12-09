using FluentValidation;

using IDezApi.Api.Dtos.Request;
using IDezApi.Api.Dtos.Response;
using IDezApi.Domain.Adapters.Driving.Api.Mapping;
using IDezApi.Domain.Enums;

using Microsoft.AspNetCore.Mvc;

namespace IDezApi.Api.Controllers
{
    public class PesquisarMunicipiosController(ILogger<PesquisarMunicipiosController> logger,
         IValidator<BuscarMunicipiosRequest> buscarMunicipiosValidatior,
         IMapperService mapperService) : ControllerBase
    {
        private readonly ILogger<PesquisarMunicipiosController> _logger = logger;
        private readonly IValidator<BuscarMunicipiosRequest> _validator = buscarMunicipiosValidatior;
        private readonly IMapperService _mapper = mapperService;

        [HttpGet]
        [Route("/api/get/PesquisarMunicipios")]
        public ActionResult<BuscarMunicipiosResponse> ExecuteAsync([FromBody] BuscarMunicipiosRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BuscarMunicipiosController: Create method called with request: {@Request}", request);

            if (request is null)
            {
                _logger.LogWarning("BuscarMunicipiosController: Create method received null request");

                return BadRequest(PatternsMessagesValidation.RequestInValid);
            }

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }



            return Ok("BuscarMunicipiosController is operational.");
        }
    }
}
