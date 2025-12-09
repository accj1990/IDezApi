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
    public class BuscarMunicipiosController(ILogger<BuscarMunicipiosController> logger,
         IValidator<BuscarMunicipiosRequest> buscarMunicipiosValidatior,
         IMapperService mapperService, IBuscarMunicipiosUseCase buscarMunicipiosUseCase) : ControllerBase
    {
        private readonly ILogger<BuscarMunicipiosController> _logger = logger;
        private readonly IValidator<BuscarMunicipiosRequest> _validator = buscarMunicipiosValidatior;
        private readonly IMapperService _mapper = mapperService;
        private readonly IBuscarMunicipiosUseCase _buscarMunicipiosUseCase = buscarMunicipiosUseCase;

        [HttpPost]
        [Route("/api/get/BuscarMunicipios")]
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

            var response = await _buscarMunicipiosUseCase.ExecuteAsync(input.Uf, cancellationToken);

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
