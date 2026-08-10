using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Text;
using Microsoft.Extensions.Logging;

namespace UserApi.Application.Behaviours
{
    public class LoggingBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
    {

        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Handling {RequestName}",typeof(TRequest).Name);

            var Response = await next();

            _logger.LogInformation("Handled {RequestName}", typeof(TRequest).Name);

            return Response;
        }
    }
}
