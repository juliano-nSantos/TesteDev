using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Applications.Application.Interface;
using API.Filters;
using API.Models.ConfigFilters;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.V1
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IApplicationServiceClientes _applicationServiceCliente;

        public ClienteController(IApplicationServiceClientes applicationServiceClientes)
        {
            _applicationServiceCliente = applicationServiceClientes;
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao consultar motorista por código")]
        [SwaggerResponse(statusCode: 404, description: "Dados não encontrado")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", type: typeof(GenericErrorViewModel))]
        [CustomModelStateValidation]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromHeader] int id)
        {
            try
            {
                var cliente = await _applicationServiceCliente.GetByIdAsync(id);

                if (cliente == null)
                    return NotFound("Dados do cliente não encontrado! ");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError
                , ex.Message);
            }
        }
    }
}