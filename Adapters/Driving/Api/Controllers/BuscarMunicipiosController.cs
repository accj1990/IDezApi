using FluentValidation;

using IDezApi.Api.Dtos.Request;
using IDezApi.Api.Dtos.Response;
using IDezApi.Domain.Enums;

using Microsoft.AspNetCore.Mvc;

namespace IDezApi.Api.Controllers
{
    public class BuscarMunicipiosController(ILogger<BuscarMunicipiosController> logger,
         IValidator<BuscarMunicipiosRequest> buscarMunicipiosValidatior) : ControllerBase
    {
        private readonly ILogger<BuscarMunicipiosController> _logger = logger;
        private readonly IValidator<BuscarMunicipiosRequest> _validator = buscarMunicipiosValidatior;

        [HttpGet]
        [Route("/api/get/BuscarMunicipios")]
        public ActionResult<BuscarMunicipiosResponse> ExecuteAsync([FromBody] BuscarMunicipiosRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("BuscarMunicipiosController: Create method called with request: {@Request}", request);

            if (request is null)
            {
                _logger.LogWarning("CreateUserController: Create method received null request");

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
