using Api.Infrastructure.Logging;
using MediatR;

namespace Api.Features.AppStatus;

public class GetApplicationStatus
{
    public partial record Query : IRequest<StatusResult>;

    public class Handler : IRequestHandler<Query, StatusResult>
    {
        private readonly ILogger<Handler> _logger;

        public Handler(
            ILogger<Handler> logger)
        {
            _logger = logger;
        }

        public async Task<StatusResult> Handle(Query query, CancellationToken cancellationToken)
        {
            using (_logger.BeginNamedScope(nameof(GetApplicationStatus)))
            {
                _logger.LogInformation("Starting to get application status");

                await Task.CompletedTask;
                return new StatusResult
                {
                    Status = "Ok"
                };
            }
        }
    }

    public class StatusResult
    {
        public string Status { get; set; } = string.Empty;
    }
}
