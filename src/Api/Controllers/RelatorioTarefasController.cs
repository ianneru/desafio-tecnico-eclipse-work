using Application.Dtos;
using Application.Facades.Interfaces;
using CorrelationId.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/relatorio-tarefas")]
    public class RelatorioTarefasController(ICorrelationContextAccessor correlationContext, ILogger<RelatorioTarefasController> logger,
    IRelatorioTarefaFacade relatorioTarefaFacade) : ControllerBase
    {
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, "Sucesso ao retornar relatório de tarefas.",
         typeof(RelatorioTarefaResponseDto))]
        public async Task<ActionResult<RelatorioTarefaResponseDto>> GetTarefasConcluidasUltimos30Dias(UsuarioRequestDto usuario,CancellationToken cancellationToken)
        {
            try
            {
                var result = await relatorioTarefaFacade.GetTarefasConcluidasUltimos30Dias(usuario,cancellationToken);
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
