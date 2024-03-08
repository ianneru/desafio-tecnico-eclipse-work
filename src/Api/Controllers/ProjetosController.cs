using Api.Helpers;
using Application.Dtos;
using Application.Facades.Interfaces;
using CorrelationId.Abstractions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
            catch (Domain.Exceptions.ValidationException e)
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

        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Id inválido.")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Tarefa não encontrada")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Tarefa foi atualizada.")]
        public async Task<IActionResult> Put(long id, [FromBody] ProjetoRequestDto projetoRequestDto, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id <= 0) return
                        BadRequest(ControllerHelper.CreateProblemDetails("Id", "Id inválido."));

                await projetoFacade.UpdateAsync(id, projetoRequestDto, cancellationToken);

                return NoContent();
            }
            catch (EntityNotFoundException e)
            {
                logger.LogError(e, "Entity Not Found Exception. CorrelationId: {correlationId}",
                    correlationContext.CorrelationContext.CorrelationId);

                return NotFound();
            }
            catch (Domain.Exceptions.ValidationException e)
            {
                logger.LogError(e, "Validation Exception. CorrelationId: {correlationId}",
                    correlationContext.CorrelationContext.CorrelationId);

                return BadRequest(e.Message);
            }
        }
    }
}
