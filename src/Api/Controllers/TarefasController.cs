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
    [Route("api/v1/tarefas")]
    public class TarefasController(ICorrelationContextAccessor correlationContext, ILogger<TarefasController> logger,
    ITarefaFacade tarefaFacade) : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso ao retornar tarefa por projeto.",
         typeof(TarefaResponseDto))]
        public async Task<ActionResult<TarefaResponseDto>> Get(long idProjeto,CancellationToken cancellationToken)
        {
            try
            {
                var result = await tarefaFacade.GetByProjeto(idProjeto, cancellationToken);
                return Ok(result);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException e)
            {
                logger.LogError(e, "Validation Exception Details. CorrelationId: {correlationId}",
                    correlationContext.CorrelationContext.CorrelationId);

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Requisição Inválida.")]
        [SwaggerResponse((int)HttpStatusCode.Created, "Projeto criado com sucesso.")]
        public async Task<IActionResult> Post([FromBody] TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var id = await tarefaFacade.CreateAsync(tarefaRequestDto, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }


        [HttpPut("{id}")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Id inválido.")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Tarefa não encontrada")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Tarefa foi atualizada.")]
        public async Task<IActionResult> Put(long id, [FromBody] TarefaRequestDto tarefaRequestDto, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid) 
                    return BadRequest(ModelState);

                if (id <= 0) return 
                        BadRequest(ControllerHelper.CreateProblemDetails("Id", "Id inválido."));

                await tarefaFacade.UpdateAsync(id, tarefaRequestDto, cancellationToken);

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

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Id inválido.")]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Tarefa não encontrada.")]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Tarefa foi deletada.")]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            try
            {
                if (id <= 0) 
                    return BadRequest(ControllerHelper.CreateProblemDetails("Id", "Id inválido."));

                await tarefaFacade.DeleteAsync(id, cancellationToken);

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
