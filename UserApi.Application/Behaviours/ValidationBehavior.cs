using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace UserApi.Application.Behaviours
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> Validators)
        {
            _validators = Validators;
        }

        public async Task<TResponse> Handle(
            TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var ValidationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = ValidationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }

            return await next();

        }
      


    }
}
