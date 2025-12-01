using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SafetyVision.Application.DTOs.Workers;
using SafetyVision.Application.Interfaces;
using SafetyVision.Core.Enums;

namespace SafetyVision.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<WorkerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllWorkersAsync(CancellationToken cancellationToken = default)
        {
            var workers = await _workerService.GetAllAsync(cancellationToken);
            return Ok(workers.Value);
        }

        [HttpGet("{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WorkerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWorkerByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _workerService.GetByIdAsync(id, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return Ok(result.Value);
        }

        [HttpGet("name/{name:alpha}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WorkerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWorkerByNameAsync([FromRoute] string name, CancellationToken cancellationToken = default)
        {
            var result = await _workerService.GetByNameAsync(name, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return Ok(result.Value);
        }

        [HttpGet("username/{userName:alpha}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(WorkerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetWorkerByUserNameAsync([FromRoute] string userName, CancellationToken cancellationToken = default)
        {
            var result = await _workerService.GetByUserNameAsync(userName, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return Ok(result.Value);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(WorkerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] PostWorkerDto dto, CancellationToken cancellationToken = default)
        {
            var result = await _workerService.CreateAsync(dto, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.Conflict => Conflict(result.Errors),
                    ErrorType.NotFound => NotFound(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }

            return Created("GetWorkerByIdAsync", result.Value);
        }

        [HttpPut("{id:guid}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] PostWorkerDto dto, CancellationToken cancellationToken = default)
        {
            var result = await _workerService.UpdateAsync(id, dto, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(result.Errors),
                    ErrorType.Conflict => Conflict(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _workerService.DeleteAsync(id, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(result.Errors),
                    ErrorType.BadRequest => BadRequest(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return NoContent();
        }

        [HttpGet("departmentId/{deptId:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<WorkerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllWorkersByDepartmentIdAsync([FromRoute] Guid deptId, CancellationToken cancellationToken = default)
        {
            var result = await _workerService.GetByDepartmentIdAsync(deptId, cancellationToken);

            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return Ok(result.Value);
        }
    }
}
