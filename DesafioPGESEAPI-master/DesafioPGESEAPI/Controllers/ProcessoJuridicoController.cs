using DesafioPGESE.Domain.Entities;
using DesafioPGESE.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DesafioPGESEAPI.API.Controllers
{
    [Authorize]
    [Route("api/ProcessoJuridico")]
    [ApiController]
    public class ProcessoJuridicoController : ControllerBase
    {
        private readonly IProcessoJuridicoService _processoJuridicoService;
        private readonly IDistribuicaoProcessoService _distribuicaoProcessoService;
        private readonly IDocumentoService _documentoService;
        private readonly IPrazosService _prazosService;


        public ProcessoJuridicoController(
            IProcessoJuridicoService processoJuridicoService,
            IDistribuicaoProcessoService distribuicaoProcessoService, IDocumentoService documentoService, IPrazosService prazosService)
        {
            _processoJuridicoService = processoJuridicoService;
            _distribuicaoProcessoService = distribuicaoProcessoService;
            _prazosService = prazosService;
            _documentoService = documentoService;
        }

        /// <summary>
        /// Create a new Legal Process
        /// </summary>
        [HttpPost]
        [SwaggerResponse(201, "Processo Jurídico criado com sucesso", typeof(ProcessoJuridico))]
        [SwaggerResponse(400, "Requisição inválida")]
        public async Task<IActionResult> Add([FromBody] ProcessoJuridico processo)
        {
            try
            {
                if (processo == null)
                    return BadRequest(new { message = "Os dados do processo são obrigatórios." });

                await _processoJuridicoService.AddAsync(processo);
                return CreatedAtAction(nameof(GetById), new { id = processo.NumUnico }, processo);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao criar o processo", details = ex.Message });
            }
        }

        /// <summary>
        /// Obtain all Legal Processes from a lawyer
        /// </summary>
        /// <param name="procuradorId">Id of lawyer</param>
        /// <returns>List of legal process of the lawyer</returns>
        [HttpGet]
        [SwaggerResponse(200, "Lista de Processos Jurídicos obtida com sucesso", typeof(IEnumerable<ProcessoJuridico>))]
        public async Task<IActionResult> GetAllByProcuradorAsync(int procuradorId)
        {
            var processos = await _processoJuridicoService.GetAllByProcuradorAsync(procuradorId);
            return Ok(processos);
        }

        /// <summary>
        /// Obtain a Process Juristic by ID
        /// </summary>
        [HttpGet("{id:int}")]
        [SwaggerResponse(200, "Processo Jurídico encontrado", typeof(ProcessoJuridico))]
        [SwaggerResponse(404, "Processo Jurídico não encontrado")]
        public async Task<IActionResult> GetById(Guid numUnico)
        {
            var processo = await _processoJuridicoService.GetByIdAsync(numUnico);
            if (processo == null)
                return NotFound(new { message = "Processo não encontrado." });

            return Ok(processo);
        }

        /// <summary>
        /// Update a existant Process Juristic (include/remove documents).
        /// </summary>
        [HttpPut("{id:int}")]
        [SwaggerResponse(200, "Processo Jurídico atualizado com sucesso")]
        [SwaggerResponse(400, "Requisição inválida")]
        [SwaggerResponse(404, "Processo Jurídico não encontrado")]
        public async Task<IActionResult> Update ([FromBody] ProcessoJuridico processo)
        {
            try
            {
                var existingProcesso = await _processoJuridicoService.GetByIdAsync(processo.NumUnico);
                if (existingProcesso == null)
                    return NotFound(new { message = "Processo não encontrado." });
                await _processoJuridicoService.UpdateAsync(processo);
                return Ok(new { message = "Processo atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao atualizar o processo", details = ex.Message });
            }
        }

        /// <summary>
        /// Delete a Legal Process by ID
        /// </summary>
        [HttpDelete("{id:int}")]
        [SwaggerResponse(200, "Processo Jurídico excluído com sucesso")]
        [SwaggerResponse(404, "Processo Jurídico não encontrado")]
        public async Task<IActionResult> Delete(Guid numUnico)
        {
            var processo = await _processoJuridicoService.GetByIdAsync(numUnico);
            if (processo == null)
                return NotFound(new { message = "Processo não encontrado." });

            await _processoJuridicoService.DeleteAsync(numUnico);
            return Ok(new { message = "Processo excluído com sucesso." });
        }

        /// <summary>
        /// Register a new term for a Legal Process
        /// </summary>
        [HttpPost("{numUnico}/Prazos")]
        [SwaggerResponse(201, "Prazo cadastrado com sucesso")]
        public async Task<IActionResult> CadastrarPrazo(Guid numUnico, [FromBody] Prazo prazo)
        {
            try
            {
                await _prazosService.AddAsync(numUnico, prazo);
                return Ok(new { message = "Prazo cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao cadastrar prazo", details = ex.Message });
            }
        }

        /// <summary>
        /// Register a new document for a Legal Process
        /// </summary>
        [HttpPost("{numUnico}/Documentos")]
        [SwaggerResponse(201, "Documento cadastrado com sucesso")]
        public async Task<IActionResult> CadastrarDocumento(Guid numUnico, [FromBody] Documento documento)
        {
            try
            {
                await _documentoService.AddAsync(numUnico, documento);
                return Ok(new { message = "Documento cadastrado com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao cadastrar documento", details = ex.Message });
            }
        }

        /// <summary>
        /// Transfer a Legal Process to another lawyer
        /// </summary>
        [HttpPost("TransferirProcesso")]
        [SwaggerResponse(200, "Processo transferido com sucesso")]
        public async Task<IActionResult> TransferirProcesso([FromQuery] Guid numUnico, [FromQuery] int procuradorNovoId)
        {
            try
            {
                await _distribuicaoProcessoService.TransferirProcessoAsync(numUnico, procuradorNovoId);
                return Ok(new { message = "Processo transferido com sucesso." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Erro ao transferir processo", details = ex.Message });
            }
        }
    }
}
