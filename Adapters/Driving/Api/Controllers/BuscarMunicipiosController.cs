using IDezApi.Api.Dtos.Response;

using Microsoft.AspNetCore.Mvc;

namespace IDezApi.Api.Controllers
{
    public class BuscarMunicipiosController(ILogger<BuscarMunicipiosController> logger) : ControllerBase
    {
        private readonly ILogger<BuscarMunicipiosController> _logger = logger;

        [HttpGet]
        [Route("/api/get/BuscarMunicipios")]
        public async ActionResult<BuscarMunicipiosResponse> ExecuteAsync()
        {
            _logger.LogInformation("BuscarMunicipiosResponse: Create method called with request");



            return Ok("BuscarMunicipiosController is operational.");
        }
    }
}
