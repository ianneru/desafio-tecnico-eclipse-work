using Application.Dtos;
using Application.Facades.Interfaces;
using CorrelationId.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/comentarios")]
    public class ComentariosController(ICorrelationContextAccessor correlationContext, ILogger<ComentariosController> logger,
    ITarefaComentarioFacade tarefaComentarioFacade) : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso ao retornar comentarios por tarefa.",
         typeof(TarefaResponseDto))]
        public async Task<ActionResult<IEnumerable<TarefaResponseDto>>> Get(long idTarefa,CancellationToken cancellationToken)
        {
            try
            {
                var result = await tarefaComentarioFacade.GetByTarefa(idTarefa, cancellationToken);
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
        [SwaggerResponse((int)HttpStatusCode.Created, "Comentário criado com sucesso.")]
        public async Task<IActionResult> Post([FromBody] TarefaComentarioRequestDto tarefaComentarioRequestDto,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var id = await tarefaComentarioFacade.CreateAsync(tarefaComentarioRequestDto, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id }, new { id });
        }
    }
}
