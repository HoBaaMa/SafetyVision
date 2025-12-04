using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using SafetyVision.Application.DTOs.SafetyOfficers;
using SafetyVision.Application.Interfaces;
using SafetyVision.Core.Enums;

namespace SafetyVision.API.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SafetyOfficersController : ControllerBase
    {
        private readonly ISafetyOfficerService _safetyOfficerService;

        public SafetyOfficersController(ISafetyOfficerService safetyOfficerService)
        {
            _safetyOfficerService = safetyOfficerService;
        }
        
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<SafetyOfficerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSafetyOfficersAsync(CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.GetAllAsync(cancellationToken);

            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    _ => StatusCode(500, result.Errors)
                };
            }

            return Ok(result.Value);
        }
        
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(SafetyOfficerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSafetyOfficerAsync([FromBody] PostSafetyOfficerDto postSafetyOfficerDto, CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.CreateAsync(postSafetyOfficerDto, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.Conflict => Conflict(result.Errors),
                    ErrorType.NotFound => NotFound(result.Errors),
                    ErrorType.BadRequest => BadRequest(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return Created("GetSafetyOfficerByIdAsync", result.Value);
        }

        [HttpGet("{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SafetyOfficerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSafetyOfficerByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.GetByIdAsync(id, cancellationToken);
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

        [HttpPut("{id:Guid}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSafetyOfficerAsync([FromRoute] Guid id, [FromBody] PostSafetyOfficerDto postSafetyOfficerDto, CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.UpdateAsync(id, postSafetyOfficerDto, cancellationToken);
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

        [HttpDelete("{id:Guid}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSafetyOfficerAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.DeleteAsync(id, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    ErrorType.NotFound => NotFound(result.Errors),
                    _ => StatusCode(500, result.Errors)
                };
            }
            return NoContent();
        }

        [HttpGet("username/{username:alpha}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SafetyOfficerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSafetyOfficerByUserNameAsync([FromRoute] string username, CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.GetByUserNameAsync(username, cancellationToken);
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
        [ProducesResponseType(typeof(SafetyOfficerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSafetyOfficerByNameAsync([FromRoute] string name, CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.GetByNameAsync(name, cancellationToken);
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

        [HttpGet("role/{roleTitle:alpha}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<SafetyOfficerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSafetyOfficersByRoleTitleAsync([FromRoute] string roleTitle, CancellationToken cancellationToken = default)
        {
            var result = await _safetyOfficerService.GetAllByRoleTitleAsync(roleTitle, cancellationToken);
            if (!result.IsSuccess)
            {
                return result.ErrorType switch
                {
                    _ => StatusCode(500, result.Errors)
                };
            }
            return Ok(result.Value);
        }
    }
}
