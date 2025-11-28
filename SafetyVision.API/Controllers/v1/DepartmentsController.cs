using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SafetyVision.Application.DTOs.Departments;
using SafetyVision.Application.Interfaces;
using SafetyVision.Core.Enums;

namespace SafetyVision.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAllDepartments(CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetAllAsync(cancellationToken);
            
            if (!result.IsSuccess)
            {
                return StatusCode(500, result.Errors);
            }
            
            return Ok(result.Value);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDepartmentById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _departmentService.GetByIdAsync(id, cancellationToken);

            if (!result.IsSuccess) return result.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result.Errors),
                _ => StatusCode(500, result.Errors)
            };

            return Ok(result.Value);
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(DepartmentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddAsync([FromBody] PostDepartmentDto dto, CancellationToken cancellationToken)
        {
            var result = await _departmentService.CreateAsync(dto, cancellationToken);

            if (!result.IsSuccess) return result.ErrorType switch
            {
                ErrorType.Conflict => Conflict(result.Errors),
                _ => StatusCode(500, result.Errors)
            };
            
            return CreatedAtAction(nameof(GetDepartmentById), new {Id = result.Value?.Id}, result.Value);
        }

        [HttpDelete("{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var result = await _departmentService.DeleteAsync(id, cancellationToken);
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

        [HttpPut("{id:Guid}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] PostDepartmentDto dto, CancellationToken cancellationToken)
        {
            var result = await _departmentService.UpdateAsync(id, dto, cancellationToken);

            if (!result.IsSuccess) return result.ErrorType switch
            {
                ErrorType.NotFound => NotFound(result.Errors),
                ErrorType.Conflict => Conflict(result.Errors),
                _ => StatusCode(500, result.Errors)
            };

            return NoContent();
        }
    }
}
