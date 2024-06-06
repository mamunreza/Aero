using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Api.Features.AppStatus.GetApplicationStatus;

namespace Api.Features.AppStatus;

[ApiController]
[Route("App/[controller]")]
public class StatusController : ControllerBase
{
    private readonly ISender _sender;

    public StatusController(ISender sender)
    {
        _sender = sender;
    }

    /// <remarks>
    /// Get status of the application
    /// </remarks>
    [HttpGet(Name = "getStatus")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(StatusResult))]
    public async Task<ActionResult<StatusResult>> GetApplicationStatusAsync(
        [FromQuery] Query query,
        CancellationToken cancellationToken)
    {
        return Ok(await _sender.Send(query, cancellationToken));
    }
}