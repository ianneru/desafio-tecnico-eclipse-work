using Application.Dtos;
using Application.Facades.Interfaces;
using CorrelationId.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/projetos")]
    public class ProjetosController(ICorrelationContextAccessor correlationContext, ILogger<ProjetosController> logger,
    IProjetoFacade projetoFacade) : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso ao retornar projetos.",
         typeof(ProjetoResponseDto))]
        public async Task<ActionResult<IEnumerable<ProjetoResponseDto>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var result = await projetoFacade.GetAll(cancellationToken);
                return Ok(result);
            }
            catch (ValidationException e)
            {
                logger.LogError(e, "Validation Exception Details. CorrelationId: {correlationId}",
                    correlationContext.CorrelationContext.CorrelationId);

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição Inválida.")]
        [SwaggerResponse((int)HttpStatusCode.Created, "Projeto criado com sucesso.")]
        public async Task<IActionResult> Post([FromBody] ProjetoRequestDto customerRequestDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var id = await projetoFacade.CreateAsync(customerRequestDto, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }
    }
}
