using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using System.Text;

namespace UserApi.Application.Behaviours
{
    public class LoggingBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Console.WriteLine($"Handling : {typeof(TRequest).Name}");

            var Response = await next();

            Console.WriteLine($"Handled : {typeof(TRequest).Name}");

            return Response;
        }
    }
}
