using Api.Helpers;
using Application.Dtos;
using Application.Facades.Interfaces;
using CorrelationId.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/historico-tarefas")]
    public class TarefasHistoricosController(ICorrelationContextAccessor correlationContext, ILogger<TarefasHistoricosController> logger,
    ITarefaHistoricoFacade tarefaHistoricoFacade) : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso ao retornar histórico da tarefa.",
         typeof(TarefaResponseDto))]
        public async Task<ActionResult<IEnumerable<TarefaHistoricoResponseDto>>> Get(long idTarefa,CancellationToken cancellationToken)
        {
            try
            {
                var result = await tarefaHistoricoFacade.GetByTarefa(idTarefa, cancellationToken);
                return Ok(result);
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException e)
            {
                logger.LogError(e, "Validation Exception Details. CorrelationId: {correlationId}",
                    correlationContext.CorrelationContext.CorrelationId);

                return BadRequest(e.Message);
            }
        }
    }
}
