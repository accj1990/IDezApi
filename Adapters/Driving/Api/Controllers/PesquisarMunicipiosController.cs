using FluentValidation;

using IDezApi.Api.Dtos.Request;
using IDezApi.Api.Dtos.Response;
using IDezApi.Domain.Adapters.Driving.Api.Mapping;
using IDezApi.Domain.Application.Dtos.Requests;
using IDezApi.Domain.Application.Interfaces;
using IDezApi.Domain.Enums;

using Microsoft.AspNetCore.Mvc;

namespace IDezApi.Api.Controllers
{
    public class PesquisarMunicipiosController(ILogger<PesquisarMunicipiosController> logger,
         IValidator<BuscarMunicipiosRequest> buscarMunicipiosValidatior,
         IMapperService mapperService,
         IPesquisarMunicipiosUseCase pesquisarMunicipiosUseCase) : ControllerBase
    {
        private readonly ILogger<PesquisarMunicipiosController> _logger = logger;
        private readonly IValidator<BuscarMunicipiosRequest> _validator = buscarMunicipiosValidatior;
        private readonly IMapperService _mapper = mapperService;
        private readonly IPesquisarMunicipiosUseCase _pesquisarMunicipiosUseCase = pesquisarMunicipiosUseCase;

        [HttpPost]
        [Route("/api/get/PesquisarMunicipios")]
        public async Task<ActionResult<BuscarMunicipiosResponse>> ExecuteAsync([FromBody] BuscarMunicipiosRequest request, CancellationToken cancellationToken)
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

            var input = _mapper.Map<BuscarMunicipiosRequest, BuscarMunicipiosInput>(request);

            var response = await _pesquisarMunicipiosUseCase.ExecuteAsync(input.Uf, cancellationToken);


            if (response.IsSuccess)
            {
                return Ok(response);
            }

            if (response.BusinessRuleViolation)
            {
                return UnprocessableEntity(response);
            }

            return StatusCode(500, response.Message);
        }
    }
}
